using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBoundary : MonoBehaviour
{
    public static float mazeLeft = -80.0f; // Half of the maze width
    public static float mazeRight = 80.0f; // Half of the maze width
    public static float mazeTop = 80.0f;   // Half of the maze height
    public static float mazeBottom = -80.0f; // Half of the maze height

    public float internalLeft;
    public float internalRight;
    public float internalTop;
    public float internalBottom;

    public float speed = 5f;  // Adjust the speed as needed
    private CharacterController controller;

    private float turnSmoothTime = 0.1f;  // Adjust the smooth time as needed
    private float turnSmoothVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        internalLeft = mazeLeft;
        internalRight = mazeRight;
        internalTop = mazeTop;
        internalBottom = mazeBottom;

        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveVector = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Check for collisions with walls and maze boundaries
            if (!IsColliding(moveVector))
            {
                controller.Move(moveVector * speed * Time.deltaTime);
            }
        }
    }

    bool IsColliding(Vector3 moveVector)
    {
        float distance = 0.5f;  // Adjust the distance based on your needs
        RaycastHit hit;

        // Perform a raycast in the move direction to check for collisions
        if (Physics.Raycast(transform.position, moveVector, out hit, distance))
        {
            if (hit.collider.CompareTag("Cube"))
            {
                // Collision with a wall detected
                return true;
            }
        }

        // Check if the player is outside the maze boundaries
        Vector3 newPosition = transform.position + moveVector * speed * Time.deltaTime;
        if (newPosition.x < mazeLeft || newPosition.x > mazeRight || newPosition.z < mazeBottom || newPosition.z > mazeTop)
        {
            return true;
        }

        return false;
    }
}
