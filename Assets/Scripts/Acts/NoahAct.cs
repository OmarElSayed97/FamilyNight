using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Act = Structs.Act;
using Action = Structs.Action;
using UnityEngine.UI;


//l_Act_Noah.Add(a_SeeNoah); 0 
//      l_Act_Noah.Add(a_SeeOrigami); 1
//    l_Act_Noah.Add(a_NoahBlameFather); 2
//   l_Act_Noah.Add(a_chooseNoahOnly); 3
///  l_Act_Noah.Add(a_chooseSarahOnly); 4
//  l_Act_Noah.Add(a_chooseRPS); 5 
// l_Act_Noah.Add(a_chooseRock); 6
// l_Act_Noah.Add(a_choosePaper); 7 
///l_Act_Noah.Add(a_chooseScissor); 8
//l_Act_Noah.Add(a_LeaveRoomNoah); 9



public class NoahAct : MonoBehaviour
{


    Action a_Action_0;
    Action a_Action_1;
    Action a_Action_2;
    Action a_Action_3;
    Action a_Action_4;
    Action a_Action_5;
    Action a_Action_6;
    Action a_Action_7;
    Action a_Action_8;
    Action a_Action_9;

    public static bool NoahSeen;
    public static bool OrigamiSeen;
    public static bool MakeDecision;
    public static bool PlayRPS;

    bool showed_decision_rps;


    GameObject g_DboxObj;

    [SerializeField]
    GameObject DBoxprefab;

    [SerializeField]
    private GameObject g_Elevator;

    [SerializeField]
    private GameObject g_NoahCharacter;

    private Animator anim;
    private bool isAnim1Played;
    private bool isAnim2Played;
    
    GameObject g_threeChoiceCanv;


    [SerializeField]
    GameObject ThreeChoice;




    // Start is called before the first frame update
    void Start()
    {

        anim = g_NoahCharacter.GetComponent<Animator>();


        GameInitializer.StateInstance.e_CurrentAct = Act.NOAH_ROOM;
        GameInitializer.StateInstance.l_Actions = GameInitializer.l_Act_Noah;
        a_Action_0 = GameInitializer.StateInstance.l_Actions[0]; //SEE_NOAH
        a_Action_1 = GameInitializer.StateInstance.l_Actions[1]; //SEE_ORIGAMI
        a_Action_2 = GameInitializer.StateInstance.l_Actions[2]; // NOAH_BLAME_FATHER
        a_Action_3 = GameInitializer.StateInstance.l_Actions[3]; // choose noah only
        a_Action_4 = GameInitializer.StateInstance.l_Actions[4]; // choose sarah only
        a_Action_5 = GameInitializer.StateInstance.l_Actions[5]; // play rps
        a_Action_6 = GameInitializer.StateInstance.l_Actions[6]; // choose rock
        a_Action_7 = GameInitializer.StateInstance.l_Actions[7]; // choose paper
        a_Action_8 = GameInitializer.StateInstance.l_Actions[8]; // choose scissor
        a_Action_9 = GameInitializer.StateInstance.l_Actions[9]; // LEAVE_ROOM_NOAH

        NoahSeen = false;
        OrigamiSeen = false;
        MakeDecision = false;
        PlayRPS = false;
        showed_decision_rps = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameInitializer.StateInstance.e_CurrentAct == Act.NOAH_ROOM)
        {

            if (NoahSeen && !a_Action_0.isStarted  && !a_Action_0.isCompleted && (a_Action_1.isCompleted || ! a_Action_1.isStarted) )
            {
                Debug.Log("should start action 0");
                a_Action_0.isStarted = true;
                g_DboxObj = DBox.InitializeDBox(DBoxprefab, a_Action_0.l_DialogueBoxes);
                a_Action_0.isPlaying = true;
            }
            if (a_Action_0.isStarted && a_Action_0.isPlaying && !a_Action_0.isCompleted && (a_Action_1.isCompleted || !a_Action_1.isStarted))
            {
                TraverseDBox(0);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_0.l_DialogueBoxes.Count))
                {
                    a_Action_0.isCompleted = true;
                }
            }

            if (OrigamiSeen && !a_Action_1.isStarted  && !a_Action_1.isCompleted && (a_Action_0.isCompleted || !a_Action_0.isStarted))
            {

                Debug.Log("should start action 1");
                a_Action_1.isStarted = true;
                g_DboxObj = DBox.InitializeDBox(DBoxprefab, a_Action_1.l_DialogueBoxes);
                a_Action_1.isPlaying = true;

              
            }
            if (a_Action_1.isStarted && a_Action_1.isPlaying && !a_Action_1.isCompleted && (a_Action_0.isCompleted || !a_Action_0.isStarted))
            {

                TraverseDBox(1);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == 1 && !isAnim1Played)
                {

                    anim.SetTrigger("SonStands");
                    g_NoahCharacter.transform.position = new Vector3(g_NoahCharacter.transform.position.x, g_NoahCharacter.transform.position.y + 1, g_NoahCharacter.transform.position.z - 1);
                    isAnim1Played = true;
                }

                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_1.l_DialogueBoxes.Count))
                {
                    anim.SetTrigger("SonTurn");
                    a_Action_1.isCompleted = true;
                }
            }

            if (!a_Action_2.isStarted && !a_Action_2.isPlaying && !a_Action_2.isCompleted && a_Action_0.isCompleted && a_Action_1.isCompleted)
            {
                a_Action_2.isStarted = true;
                g_DboxObj = DBox.InitializeDBox(DBoxprefab, a_Action_2.l_DialogueBoxes);
                a_Action_2.isPlaying = true;

            }
            if (a_Action_2.isStarted && a_Action_2.isPlaying && !a_Action_2.isCompleted)
            {
                TraverseDBox(2);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_2.l_DialogueBoxes.Count))
                {
                    a_Action_2.isCompleted = true;

                    g_threeChoiceCanv = Instantiate(ThreeChoice);
                    Transform panel = g_threeChoiceCanv.transform.GetChild(0);

                    Transform button1 = panel.transform.GetChild(0);
                    Transform button2 = panel.transform.GetChild(1);
                    Transform button3 = panel.transform.GetChild(2);

                    Transform text1 = button1.transform.GetChild(0);
                    Transform text2 = button2.transform.GetChild(0);
                    Transform text3 = button3.transform.GetChild(0);


                    text1.gameObject.GetComponent<Text>().text = "Take me only\n press 1";
                    text2.gameObject.GetComponent<Text>().text = "Take my sister\n press 2";
                    text3.gameObject.GetComponent<Text>().text = "Play Rock Paper Scissor\n press3";
                   
                }
            }


            if (Input.GetKeyDown(KeyCode.Alpha1) && a_Action_2.isCompleted && !a_Action_5.isCompleted)
            {

                a_Action_3.isStarted = true;
                Destroy(g_threeChoiceCanv);
                g_DboxObj = DBox.InitializeDBox(DBoxprefab, a_Action_3.l_DialogueBoxes);
                a_Action_3.isPlaying = true;

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && a_Action_2.isCompleted && !a_Action_5.isCompleted)
            {
                a_Action_4.isStarted = true;
                Destroy(g_threeChoiceCanv);
                g_DboxObj = DBox.InitializeDBox(DBoxprefab, a_Action_4.l_DialogueBoxes);
                a_Action_4.isPlaying = true;

            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && a_Action_2.isCompleted && !a_Action_5.isCompleted)
            {
                a_Action_5.isStarted = true;
                Destroy(g_threeChoiceCanv);
                g_DboxObj = DBox.InitializeDBox(DBoxprefab, a_Action_5.l_DialogueBoxes);
                a_Action_5.isPlaying = true;
            }


            if (a_Action_3.isPlaying && ! a_Action_3.isCompleted)
            {
                TraverseDBox(3);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_3.l_DialogueBoxes.Count))
                {
                    a_Action_3.isCompleted = true;
                    GameInitializer.StateInstance.isHasSon = true;
                }
            }

           
            if (a_Action_4.isPlaying && !a_Action_4.isCompleted)
            {
                TraverseDBox(4);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_4.l_DialogueBoxes.Count))
                {
                    a_Action_4.isCompleted = true;
                    GameInitializer.StateInstance.isHasDaughter = true;
                }
            }

            if (a_Action_5.isPlaying && !a_Action_5.isCompleted)
            {
                TraverseDBox(5);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_5.l_DialogueBoxes.Count))
                {
                    a_Action_5.isCompleted = true;
                }
            }

            if (a_Action_5.isCompleted && !showed_decision_rps)
            {
                g_threeChoiceCanv = Instantiate(ThreeChoice);
                Transform panel = g_threeChoiceCanv.transform.GetChild(0);

                Transform button1 = panel.transform.GetChild(0);
                Transform button2 = panel.transform.GetChild(1);
                Transform button3 = panel.transform.GetChild(2);

                Transform text1 = button1.transform.GetChild(0);
                Transform text2 = button2.transform.GetChild(0);
                Transform text3 = button3.transform.GetChild(0);


                text1.gameObject.GetComponent<Text>().text = "ROCK\n press 1";
                text2.gameObject.GetComponent<Text>().text = "PAPER\n press 2";
                text3.gameObject.GetComponent<Text>().text = "SCISSOR\n press3";

                showed_decision_rps = true;

            }

            if (a_Action_5.isCompleted && showed_decision_rps && Input.GetKeyDown(KeyCode.Alpha1))
            {
                a_Action_6.isStarted = true;
                Destroy(g_threeChoiceCanv);
                g_DboxObj = DBox.InitializeDBox(DBoxprefab, a_Action_6.l_DialogueBoxes);
                a_Action_6.isPlaying = true;
            }
            else if (a_Action_5.isCompleted && showed_decision_rps && Input.GetKeyDown(KeyCode.Alpha2))
                {
                    a_Action_7.isStarted = true;
                    Destroy(g_threeChoiceCanv);
                    g_DboxObj = DBox.InitializeDBox(DBoxprefab, a_Action_7.l_DialogueBoxes);
                    a_Action_7.isPlaying = true;
                }
            else if (a_Action_5.isCompleted && showed_decision_rps && Input.GetKeyDown(KeyCode.Alpha3))
            {
                a_Action_8.isStarted = true;
                Destroy(g_threeChoiceCanv);
                g_DboxObj = DBox.InitializeDBox(DBoxprefab, a_Action_8.l_DialogueBoxes);
                a_Action_8.isPlaying = true;
            }

            if (a_Action_6.isPlaying && !a_Action_6.isCompleted)
            {
                TraverseDBox(6);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_6.l_DialogueBoxes.Count))
                {
                    a_Action_6.isCompleted = true;
                    GameInitializer.StateInstance.isHasDaughter = true;
                    GameInitializer.StateInstance.isHasSon = true;
                }
            }
            if (a_Action_7.isPlaying && !a_Action_7.isCompleted)
            {
                TraverseDBox(7);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_7.l_DialogueBoxes.Count))
                {
                    a_Action_7.isCompleted = true;
                    GameInitializer.StateInstance.isHasDaughter = true;
                    GameInitializer.StateInstance.isHasSon = true;
                }
            }

            if (a_Action_8.isPlaying && !a_Action_8.isCompleted)
            {
                TraverseDBox(8);
                if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_8.l_DialogueBoxes.Count))
                {
                    a_Action_8.isCompleted = true;
                
                }
            }

            if (a_Action_0.isCompleted && a_Action_1.isCompleted && a_Action_2.isCompleted &&
                (a_Action_3.isCompleted || a_Action_4.isCompleted || a_Action_5.isCompleted) &&
                a_Action_6.isCompleted || a_Action_7.isCompleted || a_Action_8.isCompleted)
            {
                a_Action_9.isStarted = true;
                //    g_DboxObj = DBox.InitializeDBox(DBoxprefab, a_Action_9.l_DialogueBoxes);
                //  a_Action_9.isPlaying = true;
                g_Elevator.SetActive(true);
            }



            //if (a_Action_9.isPlaying && !a_Action_9.isCompleted)
            //{
            //    TraverseDBox(9);
            //    if (g_DboxObj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex == (a_Action_9.l_DialogueBoxes.Count))
            //    {
            //     //   a_Action_9.isCompleted = true;
            
                    
            //    }
            //}


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
