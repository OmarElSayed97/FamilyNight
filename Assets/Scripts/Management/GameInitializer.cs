using System;using System.Collections.Generic;
using UnityEngine;
using Action = Structs.Action;
using Dialogue = Structs.Dialogue;
using State = Structs.State;
using ActionsNames = Structs.ActionsNames;
using Act = Structs.Act;


public class GameInitializer : MonoBehaviour
{
    public static List<Action> l_Act_Entrance;
    public static List<Action> l_Act_Sarah;
    public static List<Action> l_Act_Noah;
    public static List<Action> l_Act_Elevator;
    public static List<Action> l_Act_Wife;
   
    
    public List<Dialogue> l_WonderingD;
    public List<Dialogue> l_SarahVoiceD;


    public List<Dialogue> l_enteringNoahRoomD;
    public List<Dialogue> l_seeOrigamiD;
    public List<Dialogue> l_blamingD;

    public List<Dialogue> l_SeeBedD;
    public List<Dialogue> l_SeePosterD;
    public List<Dialogue> l_SeeSarahD;
    public List<Dialogue> l_LeaveRoomWithSarah;
    public List<Dialogue> l_LeaveRoomWithOutSarah;
    public List<Dialogue> l_TalkToUnknownWithChild;
    public List<Dialogue> l_TalkToUnknownWithOutChild;



    [SerializeField]
    private Sprite img_Daugther;
    [SerializeField]
    private Sprite img_Daugther_Good;
    [SerializeField]
    private Sprite img_Son;
    [SerializeField]
    private Sprite img_Son_Good;
    [SerializeField]
    private Sprite img_Father;
    [SerializeField]
    private Sprite img_Father_Angry;
    [SerializeField]
    private Sprite img_UnknownCharacter;

    public static State StateInstance;

    
    private void InitializeActions()
    {       
        Action a_Wondering = new Action(ActionsNames.WONDERING, l_WonderingD);
        Action a_ListenSarahVoice = new Action(ActionsNames.LISTEN_SARAH_VOICE, l_SarahVoiceD);

        Action a_SeeBed = new Action(ActionsNames.SEE_BED,l_SeeBedD);
        Action a_SeePotser = new Action(ActionsNames.SEE_POSTER, l_SeePosterD);
        Action a_SeeSarah = new Action(ActionsNames.SEE_SARAH, l_SeeSarahD);
        Action a_TakeDecisionSarah = new Action(ActionsNames.TAKE_DECISION_SARAH);
        Action a_LeaveRoomWithSarah = new Action(ActionsNames.LEAVE_ROOM_WITH_SARAH, l_LeaveRoomWithSarah);
        Action a_LeaveRoomWithOutSarah = new Action(ActionsNames.LEAVE_ROOM_WITH_OUT_SARAH, l_LeaveRoomWithOutSarah);

        Action a_SeeNoah = new Action(ActionsNames.SEE_NOAH, l_enteringNoahRoomD);
        Action a_SeeOrigami = new Action(ActionsNames.SEE_ORIGAMI, l_seeOrigamiD);
        Action a_NoahBlameFather = new Action(ActionsNames.NOAH_BLAME_FATHER, l_blamingD);
        Action a_TakeDecisionNoah = new Action(ActionsNames.TAKE_DECISION_NOAH);
        Action a_LeaveRoomNoah = new Action(ActionsNames.LEAVE_ROOM_NOAH);

        Action a_TalkToUnknownWithChild = new Action(ActionsNames.TALK_UNKNOWN_CHARACTER_WITH_CHILD,l_TalkToUnknownWithChild);
        Action a_TalkToUnknownWithOutChild = new Action(ActionsNames.TALK_UNKNOWN_CHARACTER_WITH_OUT_CHILD, l_TalkToUnknownWithOutChild);
        Action a_GoElevator = new Action(ActionsNames.GO_ELEVATOR);
        Action a_GoesRightFloor = new Action(ActionsNames.GOES_RIGHT_FLOOR);
        Action a_GoesWrongFloor = new Action(ActionsNames.GOES_WRONG_FLOOR);

        l_Act_Entrance.Add(a_Wondering);
        l_Act_Entrance.Add(a_ListenSarahVoice);

        l_Act_Sarah.Add(a_SeeBed);
        l_Act_Sarah.Add(a_SeePotser);
        l_Act_Sarah.Add(a_SeeSarah);
        l_Act_Sarah.Add(a_TakeDecisionSarah);
        l_Act_Sarah.Add(a_LeaveRoomWithSarah);
        l_Act_Sarah.Add(a_LeaveRoomWithOutSarah);

        l_Act_Noah.Add(a_SeeNoah);
        l_Act_Noah.Add(a_SeeOrigami);
        l_Act_Noah.Add(a_NoahBlameFather);
        l_Act_Noah.Add(a_TakeDecisionNoah);
        l_Act_Noah.Add(a_LeaveRoomNoah);

       l_Act_Elevator.Add(a_TalkToUnknownWithChild);
       l_Act_Elevator.Add(a_TalkToUnknownWithOutChild);
       l_Act_Elevator.Add(a_GoElevator);
       l_Act_Elevator.Add(a_GoesRightFloor);
       l_Act_Elevator.Add(a_GoesWrongFloor);


    }

    private void InitializeDialogues()
    {
        l_WonderingD = new List<Dialogue>();
        l_SarahVoiceD = new List<Dialogue>();
        
        l_SeeBedD = new List<Dialogue>();
        l_SeePosterD = new List<Dialogue>();
        l_SeeSarahD = new List<Dialogue>();
        l_LeaveRoomWithSarah = new List<Dialogue>();
        l_LeaveRoomWithOutSarah = new List<Dialogue>();
        
        
       
        

        Dialogue d_Wondering1 = new Dialogue("I'm hoooooome, I want the dinner ready in 5 min \n OR YOU WILL ALL GET GROUNDED", img_Father_Angry);
        Dialogue d_Wondering2 = new Dialogue("Sarah...... , Noah.......", img_Father_Angry);
        Dialogue d_Wondering3 = new Dialogue("Where is everyone?! \nYou better show up RIGHT NOW!", img_Father_Angry);

        Dialogue d_SarahVoice1 = new Dialogue("Sarah??!", img_Father);
        Dialogue d_SarahVoice2 = new Dialogue("Is that you?? \nThis Laugh sounded really creepy (Thinking)", img_Father);
        
        Dialogue d_SeeBed = new Dialogue("OMG!!! \n Shes not here", img_Father);
        Dialogue d_SeePoster = new Dialogue("What are these?", img_Father);
        Dialogue d_SeeSarah1 = new Dialogue("Saraaaah\nWhats happening?\nWhat are you doing in the corner over there?????", img_Father);
        Dialogue d_SeeSarah2 = new Dialogue("You have never loved me enough\nYou literally know nothing about me", img_Daugther);
        Dialogue d_SeeSarah3 = new Dialogue("What do you want me to do?", img_Father);
        Dialogue d_SeeSarah4 = new Dialogue("Can you atleast mention my favorite movie!!", img_Daugther);
        Dialogue d_LeaveRoomWithSarah = new Dialogue("Thanks God,\nYou are FINALLY BACK\n Lets Go find your brother", img_Father);
        Dialogue d_LeaveRoomWithOutSarah = new Dialogue("SARAAAAAAAAAH!!!", img_Father_Angry);

        Dialogue d_TalkToUnknownWithChild1 = new Dialogue("Heyyy You!",img_UnknownCharacter);
        Dialogue d_TalkToUnknownWithChild2 = new Dialogue("Good Job, so far\n But did you wonder where is your wife??",img_UnknownCharacter);
        Dialogue d_TalkToUnknownWithChild3 = new Dialogue("Uhhhh??? \n Who's that, WHERE IS SHE?????????",img_Father_Angry);
        Dialogue d_TalkToUnknownWithChild4 = new Dialogue("GO check her out in the First Floor",img_UnknownCharacter);
        Dialogue d_TalkToUnknownWithOutChild1 = new Dialogue("Heyyy You!",img_UnknownCharacter);
        Dialogue d_TalkToUnknownWithOutChild2 = new Dialogue("Did you wonder where is your wife??",img_UnknownCharacter);
        Dialogue d_TalkToUnknownWithOutChild3 = new Dialogue("Uhhhh??? \n Who's that, WHERE IS SHE?????????",img_Father_Angry);
        Dialogue d_TalkToUnknownWithOutChild4 = new Dialogue("Hahahaha :D \n I feel pitty for you \n GO check her out in the basement floor",img_UnknownCharacter);



        l_WonderingD.Add(d_Wondering1);
        l_WonderingD.Add(d_Wondering2);
        l_WonderingD.Add(d_Wondering3);
        l_SarahVoiceD.Add(d_SarahVoice1);
        l_SarahVoiceD.Add(d_SarahVoice2);
        
        l_SeeBedD.Add(d_SeeBed);
        l_SeePosterD.Add(d_SeePoster);
        l_SeeSarahD.Add(d_SeeSarah1);
        l_SeeSarahD.Add(d_SeeSarah2);
        l_SeeSarahD.Add(d_SeeSarah3);
        l_SeeSarahD.Add(d_SeeSarah4);
        l_LeaveRoomWithSarah.Add(d_LeaveRoomWithSarah);
        l_LeaveRoomWithOutSarah.Add(d_LeaveRoomWithOutSarah);

        l_TalkToUnknownWithChild.Add(d_TalkToUnknownWithChild1);
        l_TalkToUnknownWithChild.Add(d_TalkToUnknownWithChild2);
        l_TalkToUnknownWithChild.Add(d_TalkToUnknownWithChild3);
        l_TalkToUnknownWithChild.Add(d_TalkToUnknownWithChild4);
        l_TalkToUnknownWithOutChild.Add(d_TalkToUnknownWithOutChild1);
        l_TalkToUnknownWithOutChild.Add(d_TalkToUnknownWithOutChild2);
        l_TalkToUnknownWithOutChild.Add(d_TalkToUnknownWithOutChild3);
        l_TalkToUnknownWithOutChild.Add(d_TalkToUnknownWithOutChild4);
        
        // dialogues for noah
        l_enteringNoahRoomD = new List<Dialogue>();
        l_seeOrigamiD = new List<Dialogue>();
        l_blamingD = new List<Dialogue>();

        Dialogue d_enteringNoahRoom1 = new Dialogue("Noah!\nThank God you're Ok!", img_Father);
        Dialogue d_enteringNoahRoom2 = new Dialogue("son why are you not answering?", img_Father);  // 1st action

        Dialogue d_seeOrigami3 = new Dialogue("What'up with all those origamis\nSome of them are flying too!", img_Father); //2nd

        Dialogue d_blaming1 = new Dialogue("Oh now you remember i exist?", img_Son);
        Dialogue d_blaming2 = new Dialogue("Remember when we used to favor Sarah over me all the time?", img_Son);
        Dialogue d_blaming3 = new Dialogue("WELL I HAVE NEVER FORGOTTEN", img_Son);
        Dialogue d_blaming4 = new Dialogue("Let's solve this out later son!\n come on, come with me, let us escape now!", img_Father); //2nd
        Dialogue d_blaming5 = new Dialogue("No this time is on me..\nLET'S PLAY!", img_Son);

        l_enteringNoahRoomD.Add(d_enteringNoahRoom1);
        l_enteringNoahRoomD.Add(d_enteringNoahRoom2);

        l_seeOrigamiD.Add(d_seeOrigami3);

        l_blamingD.Add(d_blaming1);
        l_blamingD.Add(d_blaming2);
        l_blamingD.Add(d_blaming3);
        l_blamingD.Add(d_blaming4);
        l_blamingD.Add(d_blaming5);






    }

    private void Start()
    {
      
        l_Act_Entrance = new List<Action>();
        l_Act_Sarah = new List<Action>();
        l_Act_Noah = new List<Action>();
        l_Act_Elevator = new List<Action>();
        l_Act_Wife = new List<Action>();
        InitializeDialogues();
        InitializeActions();
        
        StateInstance = new State();
        StateInstance.e_CurrentAct = Act.ENTRANCE;
        StateInstance.l_Actions = l_Act_Entrance;
      
    }

    
}
