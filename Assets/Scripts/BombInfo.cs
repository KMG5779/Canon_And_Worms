using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInfo : MonoBehaviour {
    public GameObject bomb;
    public int bombID;
    public int bombLimit;
    public UILabel bombCount;
    public GameManager gm;
	// Use this for initialization
	void Start () {

        bombCount = GetComponentInChildren<UILabel>();
    }
	
	// Update is called once per frame
	void Update () {
        bombCount.text = bombLimit.ToString();
	}
}
