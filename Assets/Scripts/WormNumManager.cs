using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormNumManager : MonoBehaviour {
    public WormHouse wormHouse1, wormHouse2;
    public GameManager gm;
    public float limit;
    public int count;
    public bool once;
	// Use this for initialization
	void Start () {
        once = true;
	}
	
	// Update is called once per frame
	void Update () {
        count = GameObject.FindGameObjectsWithTag("WormHead").Length;
        if (count >= limit)
        {
            wormHouse1.createWorm = false;
            wormHouse2.createWorm = false;
        }
        else
        {
            wormHouse1.createWorm = true;
            wormHouse2.createWorm = true;
        }
       if(wormHouse1.win&&wormHouse2.win&&once&&count==0)
        {
            gm.win = true;
            once = false;
        }

	}
}
