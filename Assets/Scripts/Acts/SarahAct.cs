using Act = Structs.Act;
using Action = Structs.Action;
using UnityEngine;

public class SarahAct : MonoBehaviour
{
    Action a_Action_0;
    Action a_Action_1;
    Action a_Action_2;
    Action a_Action_3;
    Action a_Action_4;

    public static bool BedSeen;
    public static bool PostersSeen;
    public static bool SarahSeen;




    // Start is called before the first frame update
    void Start()
    {
        GameInitializer.StateInstance.e_CurrentAct = Act.SARAH_ROOM;
        GameInitializer.StateInstance.l_Actions = GameInitializer.l_Act_Sarah;
        a_Action_0 = GameInitializer.StateInstance.l_Actions[0];
        a_Action_1 = GameInitializer.StateInstance.l_Actions[1];
        a_Action_2 = GameInitializer.StateInstance.l_Actions[2];
        a_Action_3 = GameInitializer.StateInstance.l_Actions[3];
        a_Action_4 = GameInitializer.StateInstance.l_Actions[4];
        BedSeen = false;
        PostersSeen = false;
        SarahSeen = false;


    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
