using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormInfo : MonoBehaviour {
    public int WormId;
    public int WormCount,wormInc;
    public GameManager gm;
    public UILabel Count;
    public int displayCount;
    // Use this for initialization
    void Start () {
        gm = GameObject.FindObjectOfType<GameManager>();
        Count=GetComponentInChildren<UILabel>();
        switch(WormId)
        {
            case 5101:
                WormCount = gm.worm1Limit;
                wormInc = gm.worm1Num;
                break;
            case 5102:
                WormCount = gm.worm2Limit;
                wormInc = gm.worm2Num;
                break;
            case 5103:
                WormCount = gm.worm3Limit;
                wormInc = gm.worm3Num;
                break;
            case 5104:
                WormCount = gm.worm4Limit;
                wormInc = gm.worm4Num;
                break;
            case 5105:
                WormCount = gm.worm5Limit;
                wormInc = gm.worm5Num;
                break;
            case 5106:
                WormCount = gm.worm6Limit;
                wormInc = gm.worm6Num;
                break;
            case 5107:
                WormCount = gm.worm7Limit;
                wormInc = gm.worm7Num;
                break;
            case 5108:
                WormCount = gm.worm8Limit;
                wormInc = gm.worm8Num;
                break;
            case 5109:
                WormCount = gm.worm9Limit;
                wormInc = gm.worm9Num;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (WormCount != 0)
        {


            switch (WormId)
            {
                case 5101:
                    wormInc = gm.worm1Num;
                    break;
                case 5102:
                    wormInc = gm.worm2Num;
                    break;
                case 5103:
                    wormInc = gm.worm3Num;
                    break;
                case 5104:
                    wormInc = gm.worm4Num;
                    break;
                case 5105:
                    wormInc = gm.worm5Num;
                    break;
                case 5106:
                    wormInc = gm.worm6Num;
                    break;
                case 5107:
                    wormInc = gm.worm7Num;
                    break;
                case 5108:
                    wormInc = gm.worm8Num;
                    break;
                case 5109:
                    wormInc = gm.worm9Num;
                    break;
            }
            displayCount = WormCount - wormInc;
            Count.text = displayCount.ToString();
        }
	}
}
