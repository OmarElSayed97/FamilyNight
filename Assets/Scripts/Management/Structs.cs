﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Structs
{
    public class Action
        {
            public ActionsNames e_ActionName;
            public bool isPlaying;
            public bool isCompleted;
            public bool isStarted;
            public List<GameObject> l_PrefabsUsedInAct;
            public List<Dialogue> l_DialogueBoxes;

            public Action(ActionsNames actionName)
            {
                e_ActionName = actionName;
                isCompleted = false;
                isPlaying = false;
                isStarted = false;
                l_DialogueBoxes = new List<Dialogue>();
                l_PrefabsUsedInAct = new List<GameObject>();
            }

        public Action(ActionsNames actionName, List<Dialogue> dialogues)
        {
            
            e_ActionName = actionName;
            isCompleted = false;
            isPlaying = false;
            isStarted = false;
            l_DialogueBoxes = new List<Dialogue>();
            foreach (Dialogue d in dialogues)
            {
                l_DialogueBoxes.Add(d);
            }
            
            l_PrefabsUsedInAct = new List<GameObject>(); ;
        }



    }

    public class Dialogue
    {
       public string s_Text;
       public Sprite img_CharacterPhoto;


        public Dialogue(string text, Sprite photo)
        {
            s_Text = text;
            img_CharacterPhoto = photo;
        }
    }


    public class State
    {
        public Vector3 v_FatherPos;
        public bool isHasSon, isHasDaughter, isHasWife;
        public Act e_CurrentAct;
        public List<Action> l_Actions;


        public State()
        {
            v_FatherPos = new Vector3(0, 0, 0);
            isHasSon = false;
            isHasDaughter = false;
            isHasWife = false;
            l_Actions = new List<Action>();
        }
    }


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
    
    public enum Act
    {
         ENTRANCE,
         SARAH_ROOM,
         NOAH_ROOM,
         ELEVATOR,
         FINALE
    }

}

