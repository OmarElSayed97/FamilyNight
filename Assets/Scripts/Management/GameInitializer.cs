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
   

    public List<Dialogue> l_SarahD;
    public List<Dialogue> l_WonderingD;
    public List<Dialogue> l_SarahVoiceD;


    public List<Dialogue> l_enteringNoahRoomD;
    public List<Dialogue> l_seeOrigamiD;
    public List<Dialogue> l_blamingD;

    public List<Dialogue> l_SeeBed;
    public List<Dialogue> l_SeePoster;
    public List<Dialogue> l_SeeSarah;

    public List<Dialogue> l_SeeBedD;
    public List<Dialogue> l_SeePosterD;
    public List<Dialogue> l_SeeSarahD;

  


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
        Action a_LeaveRoomSarah = new Action(ActionsNames.LEAVE_ROOM_SARAH);

        Action a_SeeNoah = new Action(ActionsNames.SEE_NOAH, l_enteringNoahRoomD);
        Action a_SeeOrigami = new Action(ActionsNames.SEE_ORIGAMI, l_seeOrigamiD);
        Action a_NoahBlameFather = new Action(ActionsNames.NOAH_BLAME_FATHER, l_blamingD);
        Action a_TakeDecisionNoah = new Action(ActionsNames.TAKE_DECISION_NOAH);
        Action a_LeaveRoomNoah = new Action(ActionsNames.LEAVE_ROOM_NOAH);

        Action a_TalkToUnknown = new Action(ActionsNames.TALK_UNKNOWN_CHARACTER);
        Action a_GoElevator = new Action(ActionsNames.GO_ELEVATOR);
        Action a_GoesRightFloor = new Action(ActionsNames.GOES_RIGHT_FLOOR);
        Action a_GoesWrongFloor = new Action(ActionsNames.GOES_WRONG_FLOOR);

        l_Act_Entrance.Add(a_Wondering);
        l_Act_Entrance.Add(a_ListenSarahVoice);

        l_Act_Sarah.Add(a_SeeBed);
        l_Act_Sarah.Add(a_SeePotser);
        l_Act_Sarah.Add(a_SeeSarah);
        l_Act_Sarah.Add(a_TakeDecisionSarah);
        l_Act_Sarah.Add(a_LeaveRoomSarah);

        l_Act_Noah.Add(a_SeeNoah);
        l_Act_Noah.Add(a_SeeOrigami);
        l_Act_Noah.Add(a_NoahBlameFather);
        l_Act_Noah.Add(a_TakeDecisionNoah);
        l_Act_Noah.Add(a_LeaveRoomNoah);

        l_Act_Wife.Add(a_TalkToUnknown);
        l_Act_Wife.Add(a_GoElevator);
        l_Act_Wife.Add(a_GoesRightFloor);
        l_Act_Wife.Add(a_GoesWrongFloor);


    }

    private void InitializeDialogues()
    {
        l_WonderingD = new List<Dialogue>();
        l_SarahVoiceD = new List<Dialogue>();


      

        l_SeeBed = new List<Dialogue>();
        l_SeePoster = new List<Dialogue>();
        l_SeeSarah = new List<Dialogue>();

        l_SeeBedD = new List<Dialogue>();
        l_SeePosterD = new List<Dialogue>();
        l_SeeSarahD = new List<Dialogue>();

       

        l_SarahD = new List<Dialogue>();

        Dialogue d_Wondering1 = new Dialogue("I'm hoooooome, I want the dinner ready in 5 min \n OR YOU WILL ALL GET GROUNDED", img_Father_Angry);
        Dialogue d_Wondering2 = new Dialogue("Sarah...... , Noah.......", img_Father_Angry);
        Dialogue d_Wondering3 = new Dialogue("Where is everyone?! \nYou better show up RIGHT NOW!", img_Father_Angry);

        Dialogue d_SarahVoice1 = new Dialogue("Sarah??!", img_Father);
        Dialogue d_SarahVoice2 = new Dialogue("Is that you?? \nThis Laugh sounded really creepy (Thinking)", img_Father);
       


        Dialogue d_SeeBed = new Dialogue("OMG!!! \n Shes not here", img_Father);
        Dialogue d_SeePoster = new Dialogue("Are these her favorite movies!", img_Father);
        Dialogue d_SeeSarah1 = new Dialogue("Saraaaah, Whats happening?? \n What are you doing in the corner there?????", img_Father);
        Dialogue d_SeeSarah2 = new Dialogue("You haven't loved me truly. \n You dont even know my favorite movies", img_Daugther);
        Dialogue d_SeeSarah3 = new Dialogue("What do you want me to do?", img_Father);
        Dialogue d_SeeSarah4 = new Dialogue("Tell me what whats my favorite movie", img_Daugther);






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
