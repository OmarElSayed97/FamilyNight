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
        if (Physics.Raycast(transform.position, transform.forward, out hit, 20))
        {
            Debug.DrawRay(transform.position, transform.forward*20);
            if (hit.collider.gameObject.name == "door")
            {
                hit.collider.gameObject.SetActive(false);
                Debug.Log("Door Touched");
            }

            if (hit.collider.gameObject.name == "Bed")
            {
                SarahAct.BedSeen = true;
                Debug.Log("Bed Seen");
            }
            if (hit.collider.gameObject.name == "Sarah")
            {
                SarahAct.SarahSeen = true;
                Debug.Log("Sarah");
            }
            if (hit.collider.gameObject.name == "Posters")
            {
                SarahAct.PostersSeen = true;
                Debug.Log("Posters");
            }

            if (hit.collider.gameObject.name == "Son@Sitting Idle")
            {
                NoahAct.NoahSeen = true;
                Debug.Log("Noah");
            }
            if (hit.collider.gameObject.name == "Desk1_Polygon")
            {
                NoahAct.OrigamiSeen = true;
                Debug.Log("Origami");
            }


        }

    }
}
