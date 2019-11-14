using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLightController : MonoBehaviour
{

    [SerializeField]
    public GameObject SarahDoor;
    [SerializeField]
    public GameObject SarahDoorLight;
    [SerializeField]
    public AudioSource audioSource;
    [SerializeField]
    public GameObject NoahDoor;
    [SerializeField]
    public GameObject ElevatorDoorLight;
    [SerializeField]
    public GameObject Elevator;

    private bool isInsideElevator;
   

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
            if (hit.collider.gameObject.name == "SarahDoor1")
            {
                Destroy(SarahDoorLight);
                SarahDoor.GetComponent<Animator>().Play("DoorOpening1");
                audioSource.Play();
                hit.collider.gameObject.name = "SarahDoorOpened";
            }
            if (hit.collider.gameObject.name == "NoahDoor1")
            {
                NoahDoor.GetComponent<Animator>().Play("DoorOpening1");
                audioSource.Play();
                hit.collider.gameObject.name = "NoahDoorOpened";
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
            if ((hit.collider.gameObject.name == "Door1" || hit.collider.gameObject.name == "Door2") && !isInsideElevator && GameInitializer.StateInstance.e_CurrentAct == Structs.Act.ELEVATOR)
            {
                isInsideElevator = true;
                ElevatorAct.ElevatorSeen = true;
                Destroy(ElevatorDoorLight);
                Elevator.GetComponent<Animator>().Play("ElevatorOpening");
            }
           

        }

    }
}
