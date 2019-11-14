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
    }

   
}
