using System;
using UnityEngine;
using Action = Structs.Action;

public class State : MonoBehaviour
{
    private Vector3 v_FatherPos;
    private bool isHasSon, isHasDaughter, isHasWife; 
    private Enum e_CurrentAct;
    private Action a_Actions;
}
