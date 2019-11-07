using System.Collections.Generic;
using UnityEngine;
using Dialogue = Structs.Dialogue; 
public class DBox : MonoBehaviour
{
    

    private void Start()
    {
      
    }
    
    public static GameObject InitializeDBox(GameObject dboxPrefab, List<Dialogue> dialogues)
    {
        GameObject obj = Instantiate(dboxPrefab)as GameObject;
        obj.GetComponent<DBoxAttributes>().i_CurrentDialogueIndex = 0;
        obj.GetComponent<DBoxAttributes>().DBoxText.text = dialogues[0].s_Text;
        obj.GetComponent<DBoxAttributes>().DBoxImage.sprite = dialogues[0].img_CharacterPhoto;
        return obj;
    }

    public static void CreateSeqDBox(GameObject dbox, List<Dialogue> dialogues, int index)
    {
        if (index+1 == dialogues.Count)
        {
            Destroy(dbox);
        }
        else
        {
            dbox.GetComponent<DBoxAttributes>().DBoxText.text = dialogues[index+1].s_Text;
            dbox.GetComponent<DBoxAttributes>().DBoxImage.sprite = dialogues[index+1].img_CharacterPhoto;
        }
       
        
    }  
}


