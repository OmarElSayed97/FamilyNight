using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Action = Structs.Action;
using Act = Structs.Act;

public class ElevatorAct : MonoBehaviour
{
    [SerializeField] 
    private GameObject DBoxprefab;
    
    [SerializeField] 
    private GameObject g_TwoChoiceCanvas;

    [SerializeField]
    private GameObject g_Basement;

    [SerializeField] 
    private GameObject Management;

    [SerializeField] 
    private AudioClip DecisionAudioClip;
    
    [SerializeField] 
    private AudioClip SoundTrackAudioClip;
    
    private AudioSource MainAudioSource;

    private GameObject g_DboxObj;
   
    private Animator HouseAnim;
    public static bool ElevatorSeen;
    public static bool InElevator;
    
    Action a_Action_0;
    Action a_Action_1;
    Action a_Action_2;
    Action a_Action_3;
    Action a_Action_4;

    private GameObject g_Canvas;
    private Transform t_Panel;
    private Transform t_Button1;
    private Transform t_Text1;
    private Transform t_Button2;
    private Transform t_Text2;

    public static bool IsBasementFloorChosen;
    public static bool IsFirstFloorChosen;

    // Start is called before the first frame update
    void Start()
    {
        MainAudioSource = Management.GetComponent<AudioSource>();
        GameInitializer.StateInstance.e_CurrentAct = Act.ELEVATOR;
        GameInitializer.StateInstance.l_Actions = GameInitializer.l_Act_Elevator;
        a_Action_0 = GameInitializer.StateInstance.l_Actions[0];
        a_Action_2 = GameInitializer.StateInstance.l_Actions[2];
        a_Action_3 = GameInitializer.StateInstance.l_Actions[3];
        a_Action_4 = GameInitializer.StateInstance.l_Actions[4];
    }

    // Update is called once per frame
    void Update()
    {
        if (GameInitializer.StateInstance.e_CurrentAct == Act.ELEVATOR)
        {
            if (!a_Action_0.isStarted && !a_Action_0.isCompleted)
            {
                a_Action_0.isStarted = true;
                StartCoroutine(WaitingBeforeAct1(1));
            }
            if (a_Action_0.isStarted && a_Action_0.isPlaying && !a_Action_0.isCompleted)
            {
                TraverseDBox(0);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_0.l_DialogueBoxes.Count))
                {
                    a_Action_0.isCompleted = true;
                }
            }
            
            if (InElevator && !a_Action_2.isStarted && !a_Action_2.isCompleted && a_Action_0.isCompleted )
            {
                a_Action_2.isStarted = true;
               
                StartCoroutine(WaitingInElevator(1));
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && a_Action_2.isStarted)
            {
                MainAudioSource.clip = SoundTrackAudioClip;
                MainAudioSource.Play();
                IsBasementFloorChosen = true;
                Destroy(g_Canvas);
                a_Action_2.isCompleted = true;
                GameInitializer.StateInstance.isHasWife = true;
                StartCoroutine(FinaleActWait(3));
               
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && a_Action_2.isStarted)
            {
                MainAudioSource.clip = SoundTrackAudioClip;
                MainAudioSource.Play();
                IsFirstFloorChosen = true;
                Destroy(g_Canvas);
                a_Action_2.isCompleted = true;
            }
        }
    }
    
    IEnumerator WaitingBeforeAct1(float sec)
    {
        yield return new WaitForSeconds(sec);
        
                
        g_DboxObj =  DBox.InitializeDBox(DBoxprefab, a_Action_0.l_DialogueBoxes);
        a_Action_0.isPlaying = true;
    }
  
    IEnumerator WaitingInElevator(float sec)
    {
       
        yield return new WaitForSeconds(sec);
        a_Action_2.isPlaying = true;
        MainAudioSource.clip = DecisionAudioClip;
        MainAudioSource.Play();
        g_Canvas = Instantiate(g_TwoChoiceCanvas);
        t_Panel = g_Canvas.transform.GetChild(0);
       
        t_Button1 = t_Panel.GetChild(0);
        t_Text1 = t_Button1.GetChild(0);
        t_Button2 = t_Panel.GetChild(1);
        t_Text2 = t_Button2.GetChild(0);
                
        t_Text1.gameObject.GetComponent<Text>().text = "Go To Basement \nPress 1 to choose";
        t_Text2.gameObject.GetComponent<Text>().text = "Go To First Floor \nPress 2 to choose";
    }
    void TraverseDBox(int i)
    {
        if (Input.GetKeyDown(KeyCode.Space) && g_DboxObj != null)
        {
            DBox.CreateSeqDBox(g_DboxObj, GameInitializer.StateInstance.l_Actions[i].l_DialogueBoxes, g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex);
            g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex++;
        }
    }

    IEnumerator FinaleActWait(float sec)
    {
        yield return new WaitForSeconds(sec);

        g_Basement.SetActive(true);
    }
}
