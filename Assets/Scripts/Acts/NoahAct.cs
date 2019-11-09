using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Act = Structs.Act;
using Action = Structs.Action;



//# SEE_NOAH,
//# SEE_ORIGAMI,
//# NOAH BLAME FATHER
//# TAKE_DECISION_NOAH,
//# LEAVE_ROOM_NOAH



public class NoahAct : MonoBehaviour
{


    Action a_Action_0;
    Action a_Action_1;
    Action a_Action_2;
    Action a_Action_3;
    Action a_Action_4;

    public static bool NoahSeen;
    public static bool OrigamiSeen;
    public static bool MakeDecision;
    public static bool PlayRPS;


    GameObject g_DboxObj;

    [SerializeField]
    GameObject DBoxprefab;

    // Start is called before the first frame update
    void Start()
    {
        GameInitializer.StateInstance.e_CurrentAct = Act.NOAH_ROOM;
        GameInitializer.StateInstance.l_Actions = GameInitializer.l_Act_Noah;
        a_Action_0 = GameInitializer.StateInstance.l_Actions[0]; //SEE_NOAH
        a_Action_1 = GameInitializer.StateInstance.l_Actions[1]; //SEE_ORIGAMI
        a_Action_2 = GameInitializer.StateInstance.l_Actions[2]; // NOAH_BLAME_FATHER
        a_Action_3 = GameInitializer.StateInstance.l_Actions[3]; //TAKE_DECISION_NOAH
        a_Action_4 = GameInitializer.StateInstance.l_Actions[4]; // LEAVE_ROOM_NOAH
        NoahSeen = false;
        OrigamiSeen = false;
        MakeDecision = false;
        PlayRPS = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameInitializer.StateInstance.e_CurrentAct == Act.NOAH_ROOM)
        {
       
     
            if (NoahSeen && !a_Action_0.isStarted && !a_Action_0.isPlaying && !a_Action_0.isCompleted)
            {
                StartCoroutine(SeeNoah());

                if (a_Action_0.isStarted && a_Action_0.isPlaying && !a_Action_0.isCompleted)
                {
                    TraverseDBox(0);
                    if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_0.l_DialogueBoxes.Count))
                    {
                        a_Action_0.isCompleted = true;
                    }
                }
            }

            if (OrigamiSeen && !a_Action_1.isStarted && !a_Action_1.isPlaying && !a_Action_1.isCompleted && a_Action_0.isCompleted)
            {
                a_Action_1.isStarted = true;
                g_DboxObj = DBox.InitializeDBox(DBoxprefab, a_Action_1.l_DialogueBoxes);
                a_Action_1.isPlaying = true;

                if (a_Action_1.isStarted && a_Action_1.isPlaying && !a_Action_1.isCompleted)
                {
                    TraverseDBox(1);
                    if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_1.l_DialogueBoxes.Count))
                    {
                        a_Action_1.isCompleted = true;
                    }
                }
            }

            if (  !a_Action_2.isStarted && !a_Action_2.isPlaying && !a_Action_2.isCompleted && a_Action_0.isCompleted && a_Action_1.isCompleted)
            {
                a_Action_2.isStarted = true;
                g_DboxObj = DBox.InitializeDBox(DBoxprefab, a_Action_2.l_DialogueBoxes);
                a_Action_2.isPlaying = true;

                if (a_Action_2.isStarted && a_Action_2.isPlaying && !a_Action_2.isCompleted)
                {
                    TraverseDBox(2);
                    if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_2.l_DialogueBoxes.Count))
                    {
                        a_Action_2.isCompleted = true;
                    }
                }
            }




        }
    }

    IEnumerator SeeNoah()
    {
        yield return new WaitForSeconds(1f);
        a_Action_0.isStarted = true;
        g_DboxObj = DBox.InitializeDBox(DBoxprefab, a_Action_0.l_DialogueBoxes);
        a_Action_0.isPlaying = true;

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
