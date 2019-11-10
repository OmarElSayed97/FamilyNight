using UnityEngine;
using Action = Structs.Action;
using Act = Structs.Act;

public class ElevatorAct : MonoBehaviour
{
    [SerializeField] 
    private GameObject DBoxprefab;
    
    private GameObject g_DboxObj;
    
    Action a_Action_0;
    Action a_Action_1;
    Action a_Action_2;
    Action a_Action_3;
    Action a_Action_4;

    // Start is called before the first frame update
    void Start()
    {
        GameInitializer.StateInstance.e_CurrentAct = Act.ELEVATOR;
        GameInitializer.StateInstance.l_Actions = GameInitializer.l_Act_Elevator;
        a_Action_0 = GameInitializer.StateInstance.l_Actions[0];
        a_Action_1 = GameInitializer.StateInstance.l_Actions[1];
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
            if (!a_Action_1.isStarted && !a_Action_1.isCompleted && a_Action_0.isCompleted)
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
