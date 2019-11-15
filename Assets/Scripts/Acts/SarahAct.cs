using System.Collections;
using Act = Structs.Act;
using Action = Structs.Action;
using UnityEngine;
using UnityEngine.UI;

public class SarahAct : MonoBehaviour
{
    [SerializeField] 
    private GameObject DBoxprefab;

    [SerializeField] 
    private GameObject g_SarahCharacter;
    
    [SerializeField] 
    private GameObject g_TwoChoiceCanvas;

    [SerializeField] 
    private GameObject Management;

    [SerializeField] 
    private AudioClip DecisionAudioClip;
    
    [SerializeField] 
    private AudioClip SoundTrackAudioClip;
    
    private AudioSource MainAudioSource;

    private Animator anim;

    
    [SerializeField] 
    private GameObject g_NoahRoom;
    
    private GameObject g_Canvas;
    private Transform t_Panel;
    private Transform t_Button1;
    private Transform t_Text1;
    private Transform t_Button2;
    private Transform t_Text2;
    
    private GameObject g_DboxObj;
    
    Action a_Action_0;
    Action a_Action_1;
    Action a_Action_2;
    Action a_Action_3;
    Action a_Action_4;
    Action a_Action_5;

    public static bool BedSeen;
    public static bool PostersSeen;
    public static bool SarahSeen;
    private bool IsAnim1Played;
    private bool IsAnim2Played;




    // Start is called before the first frame update
    void Start()
    {
        MainAudioSource = Management.GetComponent<AudioSource>();
        GameInitializer.StateInstance.e_CurrentAct = Act.SARAH_ROOM;
        GameInitializer.StateInstance.l_Actions = GameInitializer.l_Act_Sarah;
        a_Action_0 = GameInitializer.StateInstance.l_Actions[0];
        a_Action_1 = GameInitializer.StateInstance.l_Actions[1];
        a_Action_2 = GameInitializer.StateInstance.l_Actions[2];
        a_Action_3 = GameInitializer.StateInstance.l_Actions[3];
        a_Action_4 = GameInitializer.StateInstance.l_Actions[4];
        a_Action_5 = GameInitializer.StateInstance.l_Actions[5];
        BedSeen = false;
        PostersSeen = false;
        SarahSeen = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameInitializer.StateInstance.e_CurrentAct == Act.SARAH_ROOM)
        {
            if (BedSeen && !a_Action_0.isStarted && !a_Action_0.isCompleted)
            {
                a_Action_0.isStarted = true;
                g_DboxObj =  DBox.InitializeDBox(DBoxprefab, a_Action_0.l_DialogueBoxes);
                a_Action_0.isPlaying = true;
            }
            if (a_Action_0.isStarted && a_Action_0.isPlaying && !a_Action_0.isCompleted)
            {
                TraverseDBox(0);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_0.l_DialogueBoxes.Count))
                {
                    a_Action_0.isCompleted = true;
                }
            }
            if (PostersSeen && !a_Action_1.isStarted && !a_Action_1.isCompleted && a_Action_0.isCompleted)
            {
                a_Action_1.isStarted = true;
                g_DboxObj =  DBox.InitializeDBox(DBoxprefab, a_Action_1.l_DialogueBoxes);
                a_Action_1.isPlaying = true;
            }
            if (a_Action_1.isStarted && a_Action_1.isPlaying && !a_Action_1.isCompleted)
            {
                TraverseDBox(1);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_1.l_DialogueBoxes.Count))
                {
                    a_Action_1.isCompleted = true;
                }
            }

            if (a_Action_0.isCompleted && a_Action_1.isCompleted)
            {
                g_SarahCharacter.SetActive(true);
                anim = g_SarahCharacter.GetComponent<Animator>();
               

            }

            if (a_Action_0.isCompleted && a_Action_1.isCompleted && SarahSeen && !a_Action_2.isPlaying)
            {
                a_Action_2.isStarted = true;
                g_DboxObj =  DBox.InitializeDBox(DBoxprefab, a_Action_2.l_DialogueBoxes);
                a_Action_2.isPlaying = true;
            }
            if (a_Action_2.isStarted && a_Action_2.isPlaying && !a_Action_2.isCompleted)
            {
                TraverseDBox(2);
                
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_2.l_DialogueBoxes.Count))
                {
                    a_Action_2.isCompleted = true;
                }
               

                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == 1 && !IsAnim1Played)
                {
                    
                   anim.SetTrigger("SarahStands");
                   g_SarahCharacter.transform.position = new Vector3(g_SarahCharacter.transform.position.x, g_SarahCharacter.transform.position.y + 2, g_SarahCharacter.transform.position.z);
                   IsAnim1Played = true;
                }

                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == 4 && !IsAnim2Played)
                {

                    anim.SetTrigger("SarahSuicides");
                    g_SarahCharacter.transform.position = new Vector3(g_SarahCharacter.transform.position.x, g_SarahCharacter.transform.position.y, g_SarahCharacter.transform.position.z);

                    g_SarahCharacter.transform.rotation = new Quaternion(g_SarahCharacter.transform.rotation.x, g_SarahCharacter.transform.rotation.y + 180, g_SarahCharacter.transform.rotation.z,0);
                    IsAnim2Played = true;
                }
            }

            if (a_Action_0.isCompleted && a_Action_1.isCompleted && a_Action_2.isCompleted && !a_Action_3.isStarted)
            {
                MainAudioSource.clip = DecisionAudioClip;
                MainAudioSource.Play();
                a_Action_3.isStarted = true;
                g_Canvas = Instantiate(g_TwoChoiceCanvas);
                t_Panel = g_Canvas.transform.GetChild(0);
                
                t_Button1 = t_Panel.GetChild(0);
                t_Text1 = t_Button1.GetChild(0);
                t_Button2 = t_Panel.GetChild(1);
                t_Text2 = t_Button2.GetChild(0);
                
                t_Text1.gameObject.GetComponent<Text>().text = "Harry Potter \n Press 1 to choose";
                t_Text2.gameObject.GetComponent<Text>().text = "Lord Of The Rings \n Press 2 to choose";
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && a_Action_3.isStarted  && !a_Action_4.isPlaying)
            {
                MainAudioSource.clip = SoundTrackAudioClip;
                MainAudioSource.Play();
                GameInitializer.StateInstance.isHasDaughter = true;
                Destroy(g_Canvas);
                a_Action_3.isCompleted = true;

                a_Action_4.isStarted = true;
                g_DboxObj =  DBox.InitializeDBox(DBoxprefab, a_Action_4.l_DialogueBoxes);
                a_Action_4.isPlaying = true;
            }

            if (a_Action_3.isCompleted && a_Action_4.isStarted && !a_Action_4.isCompleted)
            {
                TraverseDBox(4);
                
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_4.l_DialogueBoxes.Count))
                {
                    a_Action_4.isCompleted = true;
                    g_SarahCharacter.SetActive(false);
                }

            }
            if (Input.GetKeyDown(KeyCode.Alpha2)&& a_Action_3.isStarted && !a_Action_5.isPlaying )
            {
                MainAudioSource.clip = SoundTrackAudioClip;
                MainAudioSource.Play();
                Destroy(g_Canvas);
                a_Action_3.isCompleted = true;

                anim.SetTrigger("SarahDying");
                g_SarahCharacter.transform.position = new Vector3(g_SarahCharacter.transform.position.x, g_SarahCharacter.transform.position.y - 2, g_SarahCharacter.transform.position.z - 0.5f);
                a_Action_5.isStarted = true;
                g_DboxObj =  DBox.InitializeDBox(DBoxprefab, a_Action_5.l_DialogueBoxes);
                a_Action_5.isPlaying = true;
            }
            if (a_Action_3.isCompleted && a_Action_5.isStarted && !a_Action_5.isCompleted)
            {
                TraverseDBox(5);
                
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_5.l_DialogueBoxes.Count))
                {
                    a_Action_5.isCompleted = true;
                }
            }

            if (a_Action_0.isCompleted && a_Action_1.isCompleted && a_Action_2.isCompleted && a_Action_3.isCompleted &&
                a_Action_4.isCompleted ||
                a_Action_0.isCompleted && a_Action_1.isCompleted && a_Action_2.isCompleted && a_Action_3.isCompleted &&
                a_Action_5.isCompleted)
            {
                g_NoahRoom.SetActive(true);

               
            }
        }
        
    }
    
    void TraverseDBox(int i)
    {
        if (Input.GetKeyDown(KeyCode.Space) && g_DboxObj != null)
        {
            DBox.CreateSeqDBox(g_DboxObj, GameInitializer.StateInstance.l_Actions[i].l_DialogueBoxes, g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex);
            g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex++;
        }
    }

    
}
