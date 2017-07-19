using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollValueCheck : MonoBehaviour {

    public float scrollvaleu;
    public float scrolllevel;
    public float levelpervalue;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scrollvaleu = gameObject.GetComponent<UIScrollBar>().value;
        scrollvaleu = gameObject.GetComponent<UIScrollBar>().numberOfSteps;
        levelpervalue = scrollvaleu / scrollvaleu;
    }
}
