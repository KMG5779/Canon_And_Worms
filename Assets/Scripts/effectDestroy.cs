﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectDestroy : MonoBehaviour {
    public float time;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, time);
	}
	
	// Update is called once per frame
	
}
