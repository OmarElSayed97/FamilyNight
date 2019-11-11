using System.Collections;
using Act = Structs.Act;
using UnityEngine;

public class EntranceAct : MonoBehaviour
{

    GameObject g_DboxObj;
    


    [SerializeField]
    GameObject DBoxprefab;
    [SerializeField]
    private GameObject SarahRoom;

    [SerializeField]
    private GameObject NoahRoom;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWondering());

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


                StartCoroutine(WaitingAfterAct(2));



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
                   SarahRoom.SetActive(true);
            }
        }    
    }


    IEnumerator StartWondering()
    {
        yield return new WaitForSeconds(2f);

        g_DboxObj =  DBox.InitializeDBox(DBoxprefab, GameInitializer.StateInstance.l_Actions[0].l_DialogueBoxes);
        GameInitializer.StateInstance.l_Actions[0].isPlaying = true;      
    }

    IEnumerator WaitingAfterAct(float sec)
    {
        yield return new WaitForSeconds(sec);
        GameInitializer.StateInstance.l_Actions[1].isPlaying = true;
        g_DboxObj = DBox.InitializeDBox(DBoxprefab, GameInitializer.StateInstance.l_Actions[1].l_DialogueBoxes);

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
