using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
    
{
    public bool stopRight;
    public bool stopLeft;
    public bool stopTop;
    public bool stopDown;
    public float playerSpeed = 7.0f;

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
            SceneManager.LoadScene("SampleScene1");
        }
    }
}

