using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLightController : MonoBehaviour
{

    private bool isFlashLightEnabeled;

    public GameObject go_flashLight;
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
            isFlashLightEnabeled = !isFlashLightEnabeled;
        }

        if (isFlashLightEnabeled)
            go_flashLight.SetActive(true);
        else
            go_flashLight.SetActive(false);
    }
}
