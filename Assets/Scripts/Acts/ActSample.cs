using UnityEngine;

public class ActSample : MonoBehaviour
{
    
    GameObject obj;


    [SerializeField]
    GameObject DBoxprefab;

   
    // Start is called before the first frame update
    void Start()
    {
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && obj == null)
        {
            obj = DBox.InitializeDBox(DBoxprefab, GameInitializer.StateInstance.l_Actions[0].l_DialogueBoxes); ;
        }
        if (Input.GetKeyDown(KeyCode.Space) && obj!= null)
        {
            
            DBox.CreateSeqDBox(obj, GameInitializer.StateInstance.l_Actions[0].l_DialogueBoxes,
                obj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex);
           
            obj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex++;
        }
    }
}
