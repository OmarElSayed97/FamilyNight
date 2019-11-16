using System.Collections;
using UnityEngine.Playables;
using UnityEngine;

public class ElevatorCollider : MonoBehaviour
{

    [SerializeField]
    GameObject g_Elevator;

    [SerializeField]
    AudioClip audio_ElevatorSound;
    [SerializeField]
    AudioClip audio_GunshotSound;
    [SerializeField]
    private GameObject FinaleAct;
    [SerializeField]
    private GameObject Father;


    private Animator anim;
    private bool isFloorChosen;
    private bool WentDown;

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = Father.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        ElevatorAct.InElevator = true;
        if (GameInitializer.StateInstance.e_CurrentAct == Structs.Act.ELEVATOR && (ElevatorAct.IsBasementFloorChosen))
        {
            

            g_Elevator.GetComponent<Animator>().Play("ElevatorGoingDown");

            if (!WentDown)
            {
                WentDown = true;
                audioSource.clip = audio_ElevatorSound;
                audioSource.Play();
            }
        }
        if (GameInitializer.StateInstance.e_CurrentAct == Structs.Act.ELEVATOR && (ElevatorAct.IsFirstFloorChosen) && !isFloorChosen)
        {
            isFloorChosen = true;
            audioSource.clip = audio_GunshotSound;
            audioSource.Play();

            if(GameInitializer.StateInstance.isHasDaughter || GameInitializer.StateInstance.isHasSon)
            {
                Debug.Log("EnteredFinalScene");
                StartCoroutine(PlayFinalScene());
            }
            else
            {
                StartCoroutine(FatherDying());
            }
           
        }



    }

    private void OnTriggerExit(Collider other)
    {
        ElevatorAct.InElevator = false;
     
    }

    IEnumerator PlayFinalScene()
    {
        yield return new WaitForSeconds(1f);
        FinaleAct.SetActive(true);
    }
    IEnumerator FatherDying()
    {
        yield return new WaitForSeconds(2f);
       
        audioSource.clip = audio_GunshotSound;
        audioSource.Play();
        anim.Play("FatherDying");
    }
}
