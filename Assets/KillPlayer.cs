﻿using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Destroy(transform.parent.gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
