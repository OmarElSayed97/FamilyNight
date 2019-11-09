using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLightController : MonoBehaviour
{

  
   // public GameObject lightObject;
   // public float maxEnergy;
  //  public float currentEnergy;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
           
            Debug.DrawRay(transform.position, transform.forward*10);
            if (hit.collider.gameObject.name == "door")
            {
                hit.collider.gameObject.SetActive(false);
                Debug.Log("Door Touched");
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

    }
}
