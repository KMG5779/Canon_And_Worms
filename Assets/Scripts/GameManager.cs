using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public CanonScript canon;
	// Use this for initialization
	void Awake () {
        
        stageNum = PlayerPrefs.GetInt("Stage", 1);
        coin = 5;
	}
	
	// Update is called once per frame
	void Update () {
        if (win)
        {
            Time.timeScale = 0;
            PlayerPrefs.SetInt("Gold", rewardGold[stageNum]);
            PlayerPrefs.SetInt("Coin", rewardCoin[stageNum]+5);
            PlayerPrefs.SetInt("Material", rewardMaterial[stageNum]);
            PlayerPrefs.SetInt("Cash", rewardCash[stageNum]);
            stageNum++;
            win = false;
        }
        if(canon.hp<=0)
        {
            Debug.Log("You loser!");
            Time.timeScale = 0;
        }
            
	}
}
