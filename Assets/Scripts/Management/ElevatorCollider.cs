using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorCollider : MonoBehaviour
{

    [SerializeField]
    GameObject g_Elevator;

    [SerializeField]
    AudioClip audio_ElevatorSound;
    [SerializeField]
    AudioClip audio_GunshotSound;

    private bool WentDown;

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        ElevatorAct.InElevator = true;
        if (GameInitializer.StateInstance.e_CurrentAct == Structs.Act.ELEVATOR && (ElevatorAct.IsBasementFloorChosen))
        {
            

            g_Elevator.GetComponent<Animator>().Play("ElevatorGoingDown");

            if (!WentDown)
            {
                WentDown = true;
                audioSource.clip = audio_ElevatorSound;
                audioSource.Play();
            }
        }
        if (GameInitializer.StateInstance.e_CurrentAct == Structs.Act.ELEVATOR && (ElevatorAct.IsFirstFloorChosen))
        {
            audioSource.clip = audio_GunshotSound;
            audioSource.Play();
        }



    }


    

    private void OnTriggerExit(Collider other)
    {
        ElevatorAct.InElevator = false;
     
    }
}
