using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController charcontr_controller;
    public float float_speed = 12f;
    public float float_gravity = -9.81f;

    //public Transform transform_groundCheck;
    public float float_groundDistance = 0.4f;
    public LayerMask layermask_groundMask;

    private bool isFlashLightEnabeled;

    public Animator anim;
    public AudioSource audioSource;

    public AudioClip FlashlightClip;
    public AudioClip FootStepClip;



    public GameObject go_flashLight;

    Vector3 velocity;
    bool bool_isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //bool_isGrounded = Physics.CheckSphere(transform_groundCheck.position, float_groundDistance, layermask_groundMask);

        if (bool_isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        charcontr_controller.Move(move * float_speed * Time.deltaTime);

        velocity.y += float_gravity * Time.deltaTime;
        charcontr_controller.Move(velocity * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.F))
        {    
            isFlashLightEnabeled = !isFlashLightEnabeled;
            audioSource.clip = FlashlightClip;
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {            
            anim.SetBool("HoldingFlashLight", true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetBool("HoldingFlashLight", false);
        }

        if (isFlashLightEnabeled)
            go_flashLight.SetActive(true);
        else
            go_flashLight.SetActive(false);
    }


    void FootStep()
    {
        audioSource.clip = FootStepClip;
        audioSource.Play();
    }

   
}
