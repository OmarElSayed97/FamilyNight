using System;
using System.Collections.Generic;
using UnityEngine;

namespace Structs
{
    public class Action
        {
            public ActionsInitializer.ActionsNames e_ActionName;
            public bool isPlayed;
            public bool isCompleted;
            public List<GameObject> l_PrefabsUsedInAct;
            public List<List<int>> l_DialogueBoxes;

            public Action(ActionsInitializer.ActionsNames actionName)
            {
                e_ActionName = actionName;
                isCompleted = false;
                isPlayed = false;
                l_DialogueBoxes = null;
                l_PrefabsUsedInAct = null;
            }
            
        }
}

