using System;
using System.Collections.Generic;
using UnityEngine;
using Action = Structs.Action;

public class ActionsInitializer : MonoBehaviour
{
    public static List<Action> l_Act_Entrance;
    public static List<Action> l_Act_Sarah;
    public static List<Action> l_Act_Noah;
    public static List<Action> l_Act_Elevator;
    public static List<Action> l_Act_Wife;
    
    
    public enum ActionsNames
    {
        WONDERING,
        LISTEN_SARAH_VOICE,
        SEE_BED,
        SEE_POSTER,
        SEE_SARAH,
        TAKE_DECISION_SARAH,
        LEAVE_ROOM_SARAH,
        SEE_ORIGAMI,
        TAKE_DECISION_NOAH,
        PLAY_RPS,
        LEAVE_ROOM_NOAH,
        TALK_UNKNOWN_CHARACTER,
        GO_ELEVATOR,
        GOES_RIGHT_FLOOR,
        GOES_WRONG_FLOOR
    }
    
    private void initializeActions()
    {
        Action a_Wondering = new Action(ActionsNames.WONDERING);
        Action a_ListenSarahVoice = new Action(ActionsNames.LISTEN_SARAH_VOICE);
        Action a_SeeBed = new Action(ActionsNames.SEE_BED);
        Action a_SeePotser = new Action(ActionsNames.SEE_POSTER);
        Action a_SeeSarah = new Action(ActionsNames.SEE_SARAH);
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
    
    private void Awake()
    {
        l_Act_Entrance = new List<Action>();
        l_Act_Sarah = new List<Action>();
        l_Act_Noah = new List<Action>();
        l_Act_Elevator = new List<Action>();
        initializeActions();
    }
}
