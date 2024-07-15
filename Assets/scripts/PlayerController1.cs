using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController1 : MonoBehaviour
    
{
    //public float moveSpeed = 3;
    //public float leftrightSpeed = 4;
    public bool jump = false;
    public bool slide = false;


    private bool canMove = true;

    public Animator anim;

     void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if(canMove){
        transform.Translate(0, 0, 0.1f);


        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            slide = true;
        }
        else
        {
            slide = false;
        }


        if (jump == true)
        {
            anim.SetBool("isjump", jump);
            transform.Translate(0, 0.3f, 0.1f);
        }
         else if (jump == false)
        {
            anim.SetBool("isjump", jump);
        }


        if (slide == true)
        {
            anim.SetBool("isslide", slide);
            transform.Translate(0, 0, 0.1f);
        }
        else if (slide == false)
        {
            anim.SetBool("isslide", slide);
        }
        }
    }

    public void StopMovement()
    {
        canMove = false;
    }

    // Method to resume player movement
    public void ResumeMovement()
    {
        canMove = true;
    }
}
