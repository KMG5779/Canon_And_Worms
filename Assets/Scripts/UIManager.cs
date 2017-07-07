using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

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
    public float xPos;
    public bool once;
    public SpringPanel springPanel;
    public int canonBall;
    int tempHp;
    public int hpMax;
    string userJson;
    bool find;
	// Use this for initialization
	void Start () {
        TextAsset data = Resources.Load("Temp") as TextAsset;
        Dictionary<string, object> userData;
        userJson = data.text;
        userData = Json.Deserialize(userJson) as Dictionary<string, object>;
        stage.text = userData["stageNum"].ToString();
        coin.text = userData["coin"].ToString() + "/5";
        cash.text = userData["cash"].ToString();
        gold.text = userData["gold"].ToString();
        material.text = userData["material"].ToString();
        tempHp = (int)canon.hp / 10;
        hpMax = (int)canon.hp;
        hp.text = tempHp.ToString();
        springPanel = GameObject.FindObjectOfType<SpringPanel>();
        find = false;
    }
	
	// Update is called once per frame
	void Update () {
        tempHp = (int)canon.hp / 10;
        hpBar.value = canon.hp / hpMax;
        hp.text = tempHp.ToString();
        if (tempHp < 0)
            tempHp = 0;
        if (once)
        {
            springPanel = GameObject.FindObjectOfType<SpringPanel>();
            if(springPanel)
            {
                find = true;
                once = false;
            }
        }
        if (find)
        {


            xPos = springPanel.target.x;
            if (xPos > 410)
                canonBall = 1;
            else if (xPos > 270)
                canonBall = 2;
            else if (xPos > 130)
                canonBall = 3;
            else if (xPos > -3)
                canonBall = 4;
            else if (xPos > -150)
                canonBall = 5;
            else if (xPos > -290)
                canonBall = 6;
            else if (xPos > -430)
                canonBall = 7;
            switch (canonBall)
            {
                case 1:
                    Debug.Log("첫번째 포탄!");
                    canon.selectBomb = 1;
                    break;
                case 2:
                    Debug.Log("두번째 포탄!");
                    canon.selectBomb = 2;
                    break;
                case 3:
                    canon.selectBomb = 3;
                    Debug.Log("세번째 포탄!");
                    break;
                case 4:
                    canon.selectBomb = 4;
                    break;
                case 5:
                    canon.selectBomb = 5;
                    break;
                case 6:
                    canon.selectBomb = 6;
                    break;
                case 7:
                    canon.selectBomb = 7;
                    break;
            }
        }
    }
}
