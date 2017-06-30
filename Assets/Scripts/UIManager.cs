using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public GameManager gm;
    public CanonScript canon;
    public UILabel score;
    public UILabel hp;
    public UILabel stage;
    public UILabel gold;
    public UILabel cash;
    public UILabel material;
    public UILabel coin;
    public UISlider hpBar;
    int tempHp;
    int hpMax;
	// Use this for initialization
	void Start () {
        score.text = PlayerPrefs.GetInt("Score", 0).ToString();
        stage.text = gm.stageNum.ToString();
        gold.text = PlayerPrefs.GetInt("Gold", 0).ToString();
        cash.text = PlayerPrefs.GetInt("Cash", 0).ToString();
        material.text = PlayerPrefs.GetInt("Material", 0).ToString();
        //coin.text = PlayerPrefs.GetInt("Coin", 0).ToString() + "/" + gm.coin;
        tempHp = (int)canon.hp / 10;
        hpMax = (int)canon.hp;
        hp.text = tempHp.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        tempHp = (int)canon.hp / 10;
        hpBar.value = canon.hp / hpMax;
        hp.text = tempHp.ToString();
        if (tempHp < 0)
            tempHp = 0;
    }
}
