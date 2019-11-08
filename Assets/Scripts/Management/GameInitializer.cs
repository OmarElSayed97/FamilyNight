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

    public  List<Dialogue> l_SarahD;
    public  List<Dialogue> l_WonderingD;
    public List<Dialogue> l_SarahVoiceD;
    [SerializeField]
    private Sprite img_Daugther;
    [SerializeField]
    private Sprite img_Son;
    [SerializeField]
    private Sprite img_Father;
    [SerializeField]
    private Sprite img_UnknownCharacter;

    public static State StateInstance;

    
    private void InitializeActions()
    {       
        Action a_Wondering = new Action(ActionsNames.WONDERING, l_WonderingD);
        Action a_ListenSarahVoice = new Action(ActionsNames.LISTEN_SARAH_VOICE, l_SarahVoiceD);

        Action a_SeeBed = new Action(ActionsNames.SEE_BED,l_SarahD);
        Action a_SeePotser = new Action(ActionsNames.SEE_POSTER);
        Action a_SeeSarah = new Action(ActionsNames.SEE_SARAH, l_SarahD);
        Action a_TakeDecisionSarah = new Action(ActionsNames.TAKE_DECISION_SARAH);
        Action a_LeaveRoomSarah = new Action(ActionsNames.LEAVE_ROOM_SARAH);

        Action a_SeeOrigami = new Action(ActionsNames.SEE_ORIGAMI);
        Action a_TakeDecisionNoah = new Action(ActionsNames.TAKE_DECISION_NOAH);
        Action a_PlayRPS = new Action(ActionsNames.PLAY_RPS);
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

        l_Act_Noah.Add(a_SeeOrigami);
        l_Act_Noah.Add(a_TakeDecisionNoah);
        l_Act_Noah.Add(a_PlayRPS);
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

        l_SarahD = new List<Dialogue>();

        Dialogue d_Wondering1 = new Dialogue("I'm hoooooome, I want the dinner ready in 5 min \n OR YOU WILL ALL GET GROUNDED", img_Daugther);
        Dialogue d_Wondering2 = new Dialogue("Sarah...... , Noah.......", img_Daugther);
        Dialogue d_Wondering3 = new Dialogue("Where is everyone?! \nYou better show up RIGHT NOW!", img_Daugther);
        Dialogue d_SarahVoice1 = new Dialogue("Sarah??!", img_Son);
        Dialogue d_SarahVoice2 = new Dialogue("Is that you?? \nThis Laugh sounded really creepy (Thinking)", img_Son);
       


        Dialogue d_Daughter = new Dialogue("Hello, I'm your Sister --> Sama ;)", img_Daugther);
        Dialogue d_Son = new Dialogue("Hi, How are you doing", img_Son);
        l_SarahD.Add(d_Daughter);
        l_SarahD.Add(d_Son);

        l_WonderingD.Add(d_Wondering1);
        l_WonderingD.Add(d_Wondering2);
        l_WonderingD.Add(d_Wondering3);
        l_SarahVoiceD.Add(d_SarahVoice1);
        l_SarahVoiceD.Add(d_SarahVoice2);

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
