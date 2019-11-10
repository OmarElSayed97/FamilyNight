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
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3))
        {
            Debug.DrawRay(transform.position, transform.forward*10);
            if (hit.collider.gameObject.name == "door")
            {
                hit.collider.gameObject.SetActive(false);
            }

            if (hit.collider.gameObject.name == "Bed")
            {
                SarahAct.BedSeen = true;
            }
            if (hit.collider.gameObject.name == "Sarah")
            {
                SarahAct.SarahSeen = true;
            }
            if (hit.collider.gameObject.name == "Posters")
            {
                SarahAct.PostersSeen = true;
            }

            if (hit.collider.gameObject.name == "Son@Sitting Idle")
            {
                NoahAct.NoahSeen = true;
                Debug.Log("Seen noah");
            }
            if (hit.collider.gameObject.name == "Desk1_Polygon")
            {
                NoahAct.OrigamiSeen = true;
                Debug.Log("seen Origami");
            }
            if (hit.collider.gameObject.name == "Door1" || hit.collider.gameObject.name == "Door2" )
            {
                ElevatorAct.ElevatorSeen = true;
                hit.collider.gameObject.SetActive(false);
            }


        }

    }
}
