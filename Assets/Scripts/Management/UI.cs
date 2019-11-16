using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
   [SerializeField] 
   private GameObject MainMenuPanel;

   [SerializeField] 
   private GameObject LeftCornerButton;

    [SerializeField]
    private GameObject CreditsPanel;

    [SerializeField] 
   private GameObject Entrance;
   
   [SerializeField] 
   private GameObject MenuCamera;
   
   [SerializeField] 
   private GameObject Cameras;

   [SerializeField] 
   private AudioClip MenuSoundtrack;
    
   [SerializeField] 
   private AudioClip SoundTrackAudioClip;
    
   private AudioSource MainAudioSource;

   private void Start()
   {
      MainAudioSource = GetComponent<AudioSource>();
   }

   public void startGame()
   {
      MainMenuPanel.SetActive(false);
      LeftCornerButton.SetActive(true);
      MenuCamera.SetActive(false);
      MainAudioSource.clip = SoundTrackAudioClip;
      MainAudioSource.Play();
      Cameras.SetActive(true);
      Entrance.SetActive(true);
      
   }

   public void TopLeftButton()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      MainMenuPanel.SetActive(true);
      LeftCornerButton.SetActive(false);
      Entrance.SetActive(false);
      MainAudioSource.clip = MenuSoundtrack;
      MainAudioSource.Play();
      MenuCamera.SetActive(true);
   }
   
   public void Quit()
   {
      Application.Quit();
   }


   public void ViewCredits()
    {
        MainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);

    }
}
