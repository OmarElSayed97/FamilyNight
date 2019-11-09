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

            if (hit.collider.gameObject.name == "Noah")
            {
                NoahAct.NoahSeen = true;
            }
            if (hit.collider.gameObject.name == "Origami")
            {
                NoahAct.OrigamiSeen = true;
            }


        }

    }
}
