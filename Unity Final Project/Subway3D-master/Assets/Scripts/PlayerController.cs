using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 direction;
    public static float forwardSpeed;
    public float maxSpeed;
    private int desiredLane = 1; // 0: left 1: middel 2: right
    public float laneDistance = 4; // the distance between two lanes 
    public float jumpForce;
    public float Gravity = -20;
    public static int pos;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        forwardSpeed = 15;
        pos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted) return;

        direction.z = forwardSpeed;
        pos = (int)transform.position.z;

        // Gather the inputs on which lane we should be 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++; // 2: right 
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--; // 0: left 
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        // Calculate where we should be in the future 

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        } else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        // we will change this line to give some smoothness
        // transform.position = targetPosition;
        if (transform.position == targetPosition) return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted) return;

        // Check if the CharacterController component is present
        if (controller != null)
        {
            controller.Move(direction * Time.fixedDeltaTime);
        }
        else
        {
            // Log an error if the CharacterController is missing
            Debug.LogError("CharacterController component is missing on the Player game object.");
        }
    }
    private void Jump()
    {
        direction.y = jumpForce;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }
}
