using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayTest : MonoBehaviour {
    public GameObject[] array;
    public GameObject obj;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < array.Length; i++)
            array[i] = Instantiate(obj);
        
	}
	
	// Update is called once per frame
	void Update () { }
	
}
