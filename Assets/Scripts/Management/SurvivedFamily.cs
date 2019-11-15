using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivedFamily : MonoBehaviour
{
    [SerializeField]
    GameObject Father;
    [SerializeField]
    GameObject Sarah;
    [SerializeField]
    GameObject Noah;
    [SerializeField]
    GameObject Mother;

    [SerializeField]
    GameObject Vcam1;
    [SerializeField]
    GameObject Vcam2;
    [SerializeField]
    GameObject Vcam3;
    [SerializeField]
    GameObject Vcam4;

    [SerializeField]
    GameObject Basement;

    [SerializeField]
    private GameObject Plane;

    [SerializeField]
    private GameObject Terrain;
    [SerializeField]
    private GameObject Elevator;

    // Start is called before the first frame update
    void Start()
    {
        if (GameInitializer.StateInstance.isHasDaughter)
        {
            Sarah.SetActive(true);
        }
        if (GameInitializer.StateInstance.isHasSon)
        {
            Noah.SetActive(true);
        }
        if (GameInitializer.StateInstance.isHasWife)
        {
            Mother.SetActive(true);
        }
        Vcam1.SetActive(false);
        Vcam2.SetActive(false);
        Vcam3.SetActive(false);
        Vcam4.SetActive(false);
        Basement.SetActive(false);
        Elevator.GetComponent<Animator>().enabled = false;
        Plane.transform.localPosition = new Vector3(-8.1f, -0.1f, -23f);
        Terrain.transform.localPosition = new Vector3(-673f, 0f, 400f );
    }

   
}
