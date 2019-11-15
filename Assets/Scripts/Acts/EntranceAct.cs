using System.Collections;
using Act = Structs.Act;
using UnityEngine;
using UnityEngine.Playables;
using System;

public class EntranceAct : MonoBehaviour
{

    GameObject g_DboxObj;
    


    [SerializeField]
    GameObject DBoxprefab;
    [SerializeField]
    private GameObject SarahRoom;

    [SerializeField]
    public GameObject SarahDoorLight;

    [SerializeField]
    private GameObject Timeline1;

    [SerializeField]
    private GameObject Cameras;

    [SerializeField]
    private GameObject FlashLightCanvas;

    
    public static GameObject go_FlashLightCanvas;   


    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(PlayCutScene1());
        audioSource = GetComponent<AudioSource>();

    }

   

    // Update is called once per frame
    void Update()
    {
        if(GameInitializer.StateInstance.e_CurrentAct == Act.ENTRANCE)
        {
            if (GameInitializer.StateInstance.l_Actions[0].isPlaying && !GameInitializer.StateInstance.l_Actions[0].isCompleted)
            {

                TraverseDBox(0);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (GameInitializer.StateInstance.l_Actions[0].l_DialogueBoxes.Count))
                {
                    GameInitializer.StateInstance.l_Actions[0].isCompleted = true;
                }
            }

            if (!GameInitializer.StateInstance.l_Actions[1].isStarted && !GameInitializer.StateInstance.l_Actions[1].isCompleted && GameInitializer.StateInstance.l_Actions[0].isCompleted)
            {
                GameInitializer.StateInstance.l_Actions[1].isStarted = true;


                StartCoroutine(PlayClip());



            }

            if (GameInitializer.StateInstance.l_Actions[1].isPlaying && !GameInitializer.StateInstance.l_Actions[1].isCompleted && GameInitializer.StateInstance.l_Actions[0].isCompleted)
            {

                TraverseDBox(1);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (GameInitializer.StateInstance.l_Actions[1].l_DialogueBoxes.Count))
                {
                    GameInitializer.StateInstance.l_Actions[1].isCompleted = true;
                }
            }

            if (GameInitializer.StateInstance.l_Actions[0].isCompleted && GameInitializer.StateInstance.l_Actions[1].isCompleted)
            {
                SarahDoorLight.SetActive(true);
                go_FlashLightCanvas = Instantiate(FlashLightCanvas);
                SarahRoom.SetActive(true);
            }
        }    
    }

    private IEnumerator PlayClip()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        GameInitializer.StateInstance.l_Actions[1].isPlaying = true;
        g_DboxObj = DBox.InitializeDBox(DBoxprefab, GameInitializer.StateInstance.l_Actions[1].l_DialogueBoxes);

    }

    IEnumerator StartWondering()
    {
        yield return new WaitForSeconds(2f);

        g_DboxObj =  DBox.InitializeDBox(DBoxprefab, GameInitializer.StateInstance.l_Actions[0].l_DialogueBoxes);
        GameInitializer.StateInstance.l_Actions[0].isPlaying = true;      
    }

    

    void TraverseDBox(int i)
    {
        if (Input.GetKeyDown(KeyCode.Space) && g_DboxObj != null)
        {
            DBox.CreateSeqDBox(g_DboxObj, GameInitializer.StateInstance.l_Actions[i].l_DialogueBoxes, g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex);
            g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex++;
        }
    }


    public IEnumerator PlayCutScene1()
    {
        PlayableDirector director = Timeline1.GetComponent<PlayableDirector>();
        director.Play();
        yield return new WaitForSeconds((float)director.duration);
        director.enabled = false;
        Cameras.SetActive(false);
        StartCoroutine(StartWondering());
    }
}
