using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using System.IO;

public class UserInfoDisplayer : MonoBehaviour {
    public int id;
    public UILabel coin, cash, gold, material;
    public UILabel bestStageRank, bestStage, bestScoreRank, bestScore;
    public UILabel selectedCanonName, selectedCanonLevel, selectedCanonHp, selectedCanonDelay,
        selectedCanonPower, selectedCanonScale, selectedCanonHeal, selectedCanonSpeed;
    public string userJson,canonJson;
    Dictionary<string, object> userData;
    public bool pressOnce;
    // Use this for initialization
    void Start () {
        TextAsset data = Resources.Load(id.ToString()) as TextAsset;
        userJson = data.text;
        userData = Json.Deserialize(userJson) as Dictionary<string, object>;
        bestStage.text = userData["stageNum"].ToString();
        bestScore.text = userData["bestScore"].ToString();
        coin.text = userData["coin"].ToString() + "/5";
        cash.text = userData["cash"].ToString();
        gold.text = userData["gold"].ToString();
        material.text = userData["material"].ToString();
        if(int.Parse(userData["canonID"].ToString())==0)
        {
            selectedCanonName.text = "";
            selectedCanonLevel.text = "";
            selectedCanonHp.text = "";
            selectedCanonDelay.text = "";
            selectedCanonPower.text = "";
            selectedCanonScale.text = "";
            selectedCanonHeal.text = "";
        }
        else
        {
            TextAsset canonData = Resources.Load(userData["canonID"].ToString()) as TextAsset;
            Dictionary<string, object> userCanonData;
            canonJson = canonData.text;
            userCanonData = Json.Deserialize(canonJson) as Dictionary<string, object>;
            selectedCanonName.text = userCanonData["CanonName"].ToString();
            selectedCanonLevel.text = userCanonData["CanonLevel"].ToString();
            selectedCanonHp.text = userCanonData["CanonHp"].ToString();
            selectedCanonPower.text = userCanonData["CanonPower"].ToString();
            selectedCanonDelay.text = userCanonData["CanonDelay"].ToString();
            selectedCanonHeal.text = userCanonData["CanonHeal"].ToString();
            selectedCanonScale.text = userCanonData["CanonScale"].ToString();
            selectedCanonSpeed.text = userCanonData["CanonSpeed"].ToString();

        }
        pressOnce = true;
        //stageNum = int.Parse(userData["stageNum"].ToString());
        //gold = int.Parse(userData["gold"].ToString());
        //cash = int.Parse(userData["cash"].ToString());
        //material = int.Parse(userData["material"].ToString());

    }
	
	// Update is called once per frame
    public void MoveInventory()
    {
        Application.LoadLevel(2);
    }
    public void MoveShop()
    {
        Application.LoadLevel(3);
    }
    public void GameStart()
    {
        if(pressOnce)
        {
            int tmp;
            tmp = int.Parse(userData["coin"].ToString()) - 1;
            userData.Remove("coin");
            userData.Add("coin", tmp);

            string data = Json.Serialize(userData);
            //byte[] bytesForEncoding = Encoding.UTF8.GetBytes(data);
            //data = Convert.ToBase64String(bytesForEncoding);
            File.WriteAllText(Application.dataPath + @"\Resources\" + id.ToString() + ".json", data);
            Application.LoadLevel(4);
            pressOnce = false;
        }
    }
}
