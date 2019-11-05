using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBox : MonoBehaviour
{
    [SerializeField]
    private GameObject DBoxPrefab;

    private void Start()
    {
        Instantiate(DBoxPrefab);
    }
}


