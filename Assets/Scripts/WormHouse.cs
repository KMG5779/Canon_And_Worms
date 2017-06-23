﻿using UnityEngine;
using System.Collections;

public class WormHouse : MonoBehaviour {
    public GameObject WormHead,Worm;
    public float WormNum,delay,rotationDelay,Wormlimit,rotationLimit;
	// Use this for initialization
	void Start () {
        StartCoroutine("CreateWorm");
        StartCoroutine("RotateHouse");
    }
	
	// Update is called once per frame
	IEnumerator CreateWorm()
    {
        while(WormNum < Wormlimit)
        {
            yield return new WaitForSeconds(delay);
            GameObject tmpHead = Instantiate(WormHead) as GameObject;
            GameObject tmpWorm = Instantiate(Worm) as GameObject;
            tmpHead.transform.position = transform.position;
            tmpHead.transform.rotation = transform.rotation;
            tmpWorm.transform.position = tmpHead.transform.position;
            tmpWorm.GetComponent<WormScript>().head = tmpHead.GetComponent<WormHeadScript>();
            tmpHead.GetComponent<WormHeadScript>().Worms.Add(tmpWorm);
            tmpHead.GetComponent<WormHeadScript>().length++;
            tmpHead.GetComponent<WormHeadScript>().initWorms();
            WormNum++;

        }
        
         
    }
    IEnumerator RotateHouse()
    {
        while(WormNum < Wormlimit)
        {
            
            transform.eulerAngles = new Vector3(Random.RandomRange(0,rotationLimit), transform.rotation.y, transform.rotation.z);
            yield return new WaitForSeconds(rotationDelay);
        }
            
    }
}