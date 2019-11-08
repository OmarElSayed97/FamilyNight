﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    public float Speed;

    [SerializeField]
    float JumpForce;

    private Rigidbody rb;
    private bool IsGrounded = true;
    // Update is called once per frame


    private void Start()
    {
       
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            if (hit.collider.gameObject.name == "door")
            {

                hit.collider.gameObject.SetActive(false);
            }

            if (hit.collider.gameObject.name == "Bed")
            {
                Debug.Log("Bed Seen");
            }
            if (hit.collider.gameObject.name == "Sarah")
            {
                Debug.Log("Sarah");
            }
            if (hit.collider.gameObject.name == "Posters")
            {
                Debug.Log("Posters");
            }

        }





        ///////////////////////////////////////////////////////////////////////////////////////////////////////


        PlayerMovement();
        
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    void PlayerMovement()
    {
        //animator.SetTrigger("Walk");
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        
        Vector3 playerMovement = new Vector3(horizontal, 0f, vertical) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }


    void Jump()
    {
        RaycastHit hit;
        if (IsGrounded)
        {
            rb.AddForce(new Vector3(0, 2, 0) * JumpForce, ForceMode.Impulse);
            IsGrounded = false;
            if (Physics.Raycast(transform.position + new Vector3(0, 0, 0), transform.TransformDirection(Vector3.forward), out hit, 10))
            {
                if (hit.collider.gameObject.tag == "Obstacle")
                {
                    Debug.Log("SS");
                    GameObject Obstacle = hit.collider.gameObject;
                    Climb();

                }
            }
        }
        else
        {
            
        }
            

    }

    private void Climb()
    {
        RaycastHit hit;
        while (Physics.Raycast(transform.position + new Vector3(0, 0, 0), transform.TransformDirection(Vector3.forward), out hit, 25))
        {
            transform.Translate(transform.TransformDirection(Vector3.up * Speed * Time.deltaTime));
        }
        transform.Translate(transform.TransformDirection(Vector3.forward));

    }

    private void OnCollisionStay(Collision collision)
    {
        IsGrounded = true;
    }
}
