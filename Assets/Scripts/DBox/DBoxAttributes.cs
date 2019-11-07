using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DBoxAttributes : MonoBehaviour
{
    [SerializeField]
    public Image DBoxImage;
    [SerializeField]
    public TMP_Text DBoxText;

    [HideInInspector]
    public int i_CurrentDialogueIndex;
    
}
