using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using System.IO;
public class GameManager : MonoBehaviour {
    public int stageNum;
    public int worm1Num;
    public int worm2Num;
    public int worm3Num;
    public int worm4Num;
    public int worm5Num;
    public int worm6Num;
    public int worm7Num;
    public int worm8Num;
    public int worm9Num;
    public float delay;
    public int worm1Limit;
    public int worm2Limit;
    public int worm3Limit;
    public int worm4Limit;
    public int worm5Limit;
    public int worm6Limit;
    public int worm7Limit;
    public int worm8Limit;
    public int worm9Limit;
    public int wormNumLimit;
    public int rewardGold;
    public int rewardCoin;
    public int rewardMaterial;
    public int rewardCash;
    public bool win,lose;
    public int coin;
    public int tmpCoin, tmpCash, tmpGold, tmpMaterial;
    public CanonScript canon;
    public UIManager UI;
    public WormHouse house1, house2;
    public UILabel RewardGold, RewardMaterial;
    public WormNumManager wormWin;
    public GameObject ResultPopUp;
    public BombInfo[] bombs;
    public UIScrollView scroll;
    public UILabel resultGold, resultMaterial, resultScore, resultStage, resultCash, resultCoin;
    
	// Use this for initialization
	void Start () {
        bombs = GameObject.FindObjectsOfType<BombInfo>();
        canon = GameObject.FindObjectOfType<CanonScript>();
        StageSingleTon.StageDB();
        stageNum = PlayerPrefs.GetInt("stageNum", 1);
        worm1Limit=int.Parse(StageSingleTon.stageData[stageNum - 1]["worm1count"].ToString());
        worm2Limit = int.Parse(StageSingleTon.stageData[stageNum - 1]["worm2count"].ToString());
        worm3Limit = int.Parse(StageSingleTon.stageData[stageNum - 1]["worm3count"].ToString());
        worm4Limit = int.Parse(StageSingleTon.stageData[stageNum - 1]["worm4count"].ToString());
        worm5Limit = int.Parse(StageSingleTon.stageData[stageNum - 1]["worm5count"].ToString());
        worm6Limit = int.Parse(StageSingleTon.stageData[stageNum - 1]["worm6count"].ToString());
        worm7Limit = int.Parse(StageSingleTon.stageData[stageNum - 1]["worm7count"].ToString());
        worm8Limit = int.Parse(StageSingleTon.stageData[stageNum - 1]["worm8count"].ToString());
        worm9Limit = int.Parse(StageSingleTon.stageData[stageNum - 1]["worm9count"].ToString());
        rewardGold = int.Parse(StageSingleTon.stageData[stageNum - 1]["reward_gold"].ToString());
        rewardCoin = int.Parse(StageSingleTon.stageData[stageNum - 1]["reward_coin"].ToString());
        rewardMaterial = int.Parse(StageSingleTon.stageData[stageNum - 1]["reward_material"].ToString());
        rewardCash = int.Parse(StageSingleTon.stageData[stageNum - 1]["reward_cash"].ToString());
        for (int i=0;i<bombs.Length;i++)
        {
            switch(bombs[i].bombID)
            {
                case 2001:
                    bombs[i].bombLimit = int.Parse(StageSingleTon.stageData[stageNum - 1]["canonBall1Count"].ToString());
                    break;
                case 2002:
                    bombs[i].bombLimit = int.Parse(StageSingleTon.stageData[stageNum - 1]["canonBall2Count"].ToString());
                    break;
                case 2003:
                    bombs[i].bombLimit = int.Parse(StageSingleTon.stageData[stageNum - 1]["canonBall3Count"].ToString());
                    break;
                case 2004:
                    bombs[i].bombLimit = int.Parse(StageSingleTon.stageData[stageNum - 1]["canonBall4Count"].ToString());
                    break;
                case 2005:
                    bombs[i].bombLimit = int.Parse(StageSingleTon.stageData[stageNum - 1]["canonBall5Count"].ToString());
                    break;
                case 2006:
                    bombs[i].bombLimit = int.Parse(StageSingleTon.stageData[stageNum - 1]["canonBall6Count"].ToString());
                    break;
                case 2007:
                    bombs[i].bombLimit = int.Parse(StageSingleTon.stageData[stageNum - 1]["canonBall7Count"].ToString());
                    break;
                case 2008:
                    bombs[i].bombLimit = int.Parse(StageSingleTon.stageData[stageNum - 1]["canonBall8Count"].ToString());
                    break;
                case 2009:
                    bombs[i].bombLimit = int.Parse(StageSingleTon.stageData[stageNum - 1]["canonBall9Count"].ToString());
                    break;
                case 2010:
                    bombs[i].bombLimit = int.Parse(StageSingleTon.stageData[stageNum - 1]["canonBall10Count"].ToString());
                    break;
                case 2011:
                    bombs[i].bombLimit = 0;
                    break;
            }
        }
        stageNum =PlayerPrefs.GetInt("stageNum",1);
        coin = PlayerPrefs.GetInt("coin");
        RewardGold.text = rewardGold.ToString();
        RewardMaterial.text = rewardMaterial.ToString();
        ResultPopUp.SetActive(false);
        win = false;
        //for (int i = 0; i < bombs.Length; i++)
        //{
        //    if (bombs[i].bombLimit == 0)
        //        bombs[i].gameObject.SetActive(false);
        //}
        //StartCoroutine(CheckBombs());
    }
	
	// Update is called once per frame
	void Update () {
        if (win)
        {
            Time.timeScale = 0;
            resultGold.text = rewardGold.ToString();
            resultCash.text = rewardCash.ToString();
            resultMaterial.text = rewardMaterial.ToString();
            resultCoin.text = rewardCoin.ToString();
            resultScore.text = UI.score.text;
            resultStage.text = UI.stage.text;
            ResultPopUp.SetActive(true);
            tmpMaterial = int.Parse(UI.material.text) + rewardMaterial;
            UI.material.text = tmpMaterial.ToString();
            tmpCash = int.Parse(UI.cash.text) + rewardCash;
            UI.cash.text = tmpCash.ToString();
            tmpGold = int.Parse(UI.gold.text) + rewardGold;
            UI.gold.text = tmpGold.ToString();
            tmpCoin = UI.coinValue + rewardCoin;
            if (tmpCoin > 5)
                tmpCoin = 5;
            UI.coin.text = tmpCoin.ToString();
            
            stageNum++;
            PlayerPrefs.SetInt("stageNum",stageNum);
            PlayerPrefs.SetInt("gold", tmpGold);
            PlayerPrefs.SetInt("cash", tmpCash);
            PlayerPrefs.SetInt("material", tmpMaterial);
            PlayerPrefs.SetInt("coin", tmpCoin);
            if (PlayerPrefs.GetInt("bestScore") < int.Parse(UI.score.text))
                PlayerPrefs.SetInt("bestScore", int.Parse(UI.score.text));
            //string userdata=Json.Serialize(UI.userData);
            //if (Application.platform == RuntimePlatform.Android)
            //    File.WriteAllText(Application.persistentDataPath+ "/Resources/" + UI.id.ToString() + ".json", userdata);
            //else if (Application.platform == RuntimePlatform.WindowsEditor)
            //    File.WriteAllText(Application.dataPath+ "/Resources/" + UI.id.ToString() + ".json", userdata);
            //팝업창 띄우기
            Time.timeScale = 0;
            win = false;
        }
        if(canon.hp<=0)
        {
            Debug.Log("You loser!");
            Time.timeScale = 0;
        }
            
	}
    //IEnumerator CheckBombs()
    //{
    //    for (int i = 0; i < bombs.Length; i++)
    //    {
    //        if (bombs[i].bombLimit == 0)
    //        {
    //            Destroy(bombs[i].gameObject);
    //            scroll.ResetPosition();
    //        }
                
    //    }
    //    yield return new WaitForSeconds(0.1f); 
    //}
}
