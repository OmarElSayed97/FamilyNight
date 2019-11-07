using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Structs
{
    public class Action
        {
            public GameInitializer.ActionsNames e_ActionName;
            public bool isPlaying;
            public bool isCompleted;
            public bool isStarted;
            public List<GameObject> l_PrefabsUsedInAct;
            public List<Dialogue> l_DialogueBoxes;

            public Action(GameInitializer.ActionsNames actionName)
            {
                e_ActionName = actionName;
                isCompleted = false;
                isPlaying = false;
                isStarted = false;
                l_DialogueBoxes = new List<Dialogue>();
                l_PrefabsUsedInAct = new List<GameObject>();
            }

        public Action(GameInitializer.ActionsNames actionName, List<Dialogue> dialogues)
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
        public Enum e_CurrentAct;
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
}

