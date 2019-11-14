﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SarahCharacter : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void PlayHeadHitAudio()
    {
        audioSource.Play();
    }
}
