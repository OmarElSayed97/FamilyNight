using UnityEngine.Playables;
using UnityEngine;
using System.Collections;
using Act = Structs.Act;

public class FinaleAct : MonoBehaviour
{
    [SerializeField]
    private GameObject FinaleTimeline;

    [SerializeField]
    private GameObject FinaleTimeline2;

    [SerializeField]
    private GameObject DBoxprefab;

    
    private GameObject g_DboxObj;
    private bool isTimelinePlayed;

    // Start is called before the first frame update
    void Start()
    {
        GameInitializer.StateInstance.e_CurrentAct = Act.FINALE;
        GameInitializer.StateInstance.l_Actions = GameInitializer.l_Act_Finale;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameInitializer.StateInstance.e_CurrentAct == Structs.Act.FINALE)
        {
            if (!GameInitializer.StateInstance.l_Actions[0].isStarted && !GameInitializer.StateInstance.l_Actions[0].isCompleted)
            {
                GameInitializer.StateInstance.l_Actions[0].isStarted = true;
                g_DboxObj = DBox.InitializeDBox(DBoxprefab, GameInitializer.StateInstance.l_Actions[0].l_DialogueBoxes);
                GameInitializer.StateInstance.l_Actions[0].isPlaying = true;
            }
            if (GameInitializer.StateInstance.l_Actions[0].isStarted && GameInitializer.StateInstance.l_Actions[0].isPlaying && !GameInitializer.StateInstance.l_Actions[0].isCompleted)
            {
                TraverseDBox(0);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (GameInitializer.StateInstance.l_Actions[0].l_DialogueBoxes.Count))
                {
                    GameInitializer.StateInstance.l_Actions[0].isCompleted = true;
                    StartCoroutine(PlayFinalScene());
 ;
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


    IEnumerator PlayFinalScene()
    {
        FinaleTimeline.GetComponent<PlayableDirector>().Play();
        yield return new WaitForSeconds((float)FinaleTimeline.GetComponent<PlayableDirector>().duration);
       
        FinaleTimeline2.SetActive(true);
    }
}
