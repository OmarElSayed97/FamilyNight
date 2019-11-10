using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ElevatorAct.InElevator = true;
    }

    private void OnTriggerExit(Collider other)
    {
        ElevatorAct.InElevator = false;
    }
}
