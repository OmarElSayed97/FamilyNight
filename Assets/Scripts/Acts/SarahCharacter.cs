using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SarahCharacter : MonoBehaviour
{
    private AudioSource audioSource;


    [SerializeField]
    AudioClip HittingWall;

    [SerializeField]
    AudioClip JumpScare;


    private bool IsClipPlayed;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void PlayHeadHitAudio()
    {
        audioSource.clip = HittingWall;
        audioSource.Play();
    }

    private void Update()
    {
        if(SarahAct.SarahSeen && !IsClipPlayed)
        {
            IsClipPlayed = true;
            audioSource.clip = JumpScare;
            audioSource.Play();
        }
    }
}
