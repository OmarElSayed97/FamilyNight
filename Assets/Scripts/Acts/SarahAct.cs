using System.Collections;
using Act = Structs.Act;
using Action = Structs.Action;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SarahAct : MonoBehaviour
{
    [SerializeField] 
    private GameObject DBoxprefab;

    [SerializeField] 
    private GameObject g_SarahCharacter;
    
    [SerializeField] 
    private GameObject g_TwoChoiceCanvas;

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




    // Start is called before the first frame update
    void Start()
    {
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
            }

            if (a_Action_0.isCompleted && a_Action_1.isCompleted && a_Action_2.isCompleted && !a_Action_3.isStarted)
            {
                a_Action_3.isStarted = true;
                g_Canvas = Instantiate(g_TwoChoiceCanvas);
                t_Panel = g_Canvas.transform.GetChild(0);
                
                t_Button1 = t_Panel.GetChild(0);
                t_Text1 = t_Button1.GetChild(0);
                t_Button2 = t_Panel.GetChild(1);
                t_Text2 = t_Button2.GetChild(0);
                
                t_Text1.gameObject.GetComponent<Text>().text = "Right Movie \n Press 1 to choose";
                t_Text2.gameObject.GetComponent<Text>().text = "Wrong Movie \n Press 2 to choose";
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && a_Action_3.isStarted)
            {
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
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)&& a_Action_3.isStarted)
            {
                Destroy(g_Canvas);
                a_Action_3.isCompleted = true;
                
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
