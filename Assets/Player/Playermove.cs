using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playermove : MonoBehaviour
{/*
    public float moveSpeed = 3;
    public float leftrightSpeed = 4;
    public float topBoundary = 90.0f;   // Adjust the top boundary as needed
    public float bottomBoundary = -90.0f; // Adjust the bottom boundary as needed

    public bool stopright;
    public bool stopleft;
    public bool stoptop;
    public bool stopbottom;
    void Update()
    {
        MovePlayer();
    }
    private void FixedUpdate(){
        stopright=Physics.Raycast(transform.position,Vector3.right, .67f);
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Move forward
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed, Space.World);

        // Move left or right
        transform.Translate(Vector3.left * Time.deltaTime * leftrightSpeed * horizontal);

        // Clamp player position to stay within boundaries
        float clampedZ = Mathf.Clamp(transform.position.z, bottomBoundary, topBoundary);
        transform.position = new Vector3(transform.position.x, transform.position.y, clampedZ);
    }
    */
 
    public bool stopRight;
    public bool stopLeft;
    public bool stopTop;
    public bool stopDown;
    public float playerSpeed = 2.0f;

    void FixedUpdate()
    {
        stopRight = Physics.Raycast(transform.position, Vector3.right, 0.67f);
        stopLeft = Physics.Raycast(transform.position, Vector3.left, 0.67f);
        stopTop = Physics.Raycast(transform.position, Vector3.forward, 0.67f);
        stopDown = Physics.Raycast(transform.position, Vector3.back, 0.67f);
    }

    void Update()
    {
        if (!stopRight)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * playerSpeed * Time.deltaTime;
            }
        }
        if (!stopLeft)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * playerSpeed * Time.deltaTime;
            }
        }
        if (!stopTop)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.forward * playerSpeed * Time.deltaTime;
            }
        }
        if (!stopDown)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.back * playerSpeed * Time.deltaTime;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("move"))
        {
            Debug.Log("Player entered the EndPlaneTrigger");
            
            // Load the "sampleScene1" scene
            SceneManager.LoadScene("SampleScene2");
        }
    }
}



