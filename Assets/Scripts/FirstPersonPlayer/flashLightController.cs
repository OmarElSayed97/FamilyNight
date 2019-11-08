using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLightController : MonoBehaviour
{

    private bool flashLightEnabeled;

    public GameObject flashLight;
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashLightEnabeled = !flashLightEnabeled;
        }

        if (flashLightEnabeled)
            flashLight.SetActive(true);
        else
            flashLight.SetActive(false);
    }
}
