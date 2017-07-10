using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using System.IO;
public class GameManager : MonoBehaviour {
    public int stageNum;
    public int[] wormNum;
    public Vector3[] wormHousePos;
    public float[] delay;
    public int[] wormLimit;
    public int[] worm2Limit;
    public int[] worm3Limit;
    public int[] wormNumLimit;
    public int[] rewardGold;
    public int[] rewardCoin;
    public int[] rewardMaterial;
    public int[] rewardCash;
    public int[] bombNum;
    public bool win,lose;
    public int coin;
    public int tmpCoin, tmpCash, tmpGold, tmpMaterial;
    public CanonScript canon;
    public UIManager UI;
    public WormHouse house1, house2;
    
	// Use this for initialization
	void Start () {

        stageNum=int.Parse(UI.userData["stageNum"].ToString());
        coin = int.Parse(UI.userData["coin"].ToString());
	}
	
	// Update is called once per frame
	void Update () {
        if (house1.win&&house2.win)
        {
            Time.timeScale = 0;
            tmpMaterial = (int)UI.userData["Material"] + rewardMaterial[stageNum];
            UI.userData["Material"] = tmpMaterial;
            tmpCash = (int)UI.userData["Cash"] + rewardCash[stageNum];
            UI.userData["Cash"] = tmpCash;
            tmpGold = (int)UI.userData["Gold"] + rewardGold[stageNum];
            UI.userData["Gold"] = tmpGold;
            tmpCoin = (int)UI.userData["coin"] + rewardCoin[stageNum];
            if (tmpCoin > 5)
                tmpCoin = 5;
            UI.userData["coin"] = tmpCoin;
            stageNum++;
            UI.userData["stageNum"] = stageNum;
            string userdata=Json.Serialize(UI.userData);
            File.WriteAllText(Application.dataPath + @"\Resources\" + UI.id.ToString() + ".json", userdata);
            //팝업창 띄우기
            win = false;
        }
        if(canon.hp<=0)
        {
            Debug.Log("You loser!");
            Time.timeScale = 0;
        }
            
	}
}
