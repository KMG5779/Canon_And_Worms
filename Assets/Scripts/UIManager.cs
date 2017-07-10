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
    public int hpMax,id;
    string userJson;
    bool find;
    public TextAsset data;
    public Dictionary<string, object> userData;
    // Use this for initialization
    void Awake()
    {
        data = Resources.Load(id.ToString()) as TextAsset;
        userJson = data.text;
        userData = Json.Deserialize(userJson) as Dictionary<string, object>;
        stage.text = userData["stageNum"].ToString();
        coin.text = userData["coin"].ToString() + "/5";
        cash.text = userData["cash"].ToString();
        gold.text = userData["gold"].ToString();
        material.text = userData["material"].ToString();
    }
    void Start () {
        
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
            if (xPos > 690)
                canonBall = 1;
            else if (xPos > 550)
                canonBall = 2;
            else if (xPos > 410)
                canonBall = 3;
            else if (xPos > 270)
                canonBall = 4;
            else if (xPos > 130)
                canonBall = 5;
            else if (xPos > -10)
                canonBall = 6;
            else if (xPos > -150)
                canonBall = 7;
            else if (xPos > -290)
                canonBall = 8;
            else if (xPos > -430)
                canonBall = 9;
            else if (xPos > -570)
                canonBall = 10;
            else if (xPos > -710)
                canonBall = 11;
            switch (canonBall)
            {
                case 1:
                    canon.selectBomb = 1;
                    break;
                case 2:
                    canon.selectBomb = 2;
                    break;
                case 3:
                    canon.selectBomb = 3;
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
                case 8:
                    canon.selectBomb = 8;
                    break;
                case 9:
                    canon.selectBomb = 9;
                    break;
                case 10:
                    canon.selectBomb = 10;
                    break;
                case 11:
                    canon.selectBomb = 11;
                    break;
            }
        }
    }

    public void ExitStage()
    {
        Application.LoadLevel("Main");
    }

}
