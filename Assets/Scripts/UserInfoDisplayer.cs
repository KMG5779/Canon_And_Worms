using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using System.IO;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System;



public class UserInfoDisplayer : MonoBehaviour {
    public int id,bestScore,bestStage,coinValue,cashValue,goldValue,materialValue,selectedCanonID;
    public UILabel coin, cash, gold, material;
    public UILabel bestStageRank, bestStageText, bestScoreRank, bestScoreText;
    public UILabel selectedCanonName, selectedCanonLevel, selectedCanonHp, selectedCanonDelay,
        selectedCanonPower, selectedCanonScale, selectedCanonHeal, selectedCanonSpeed;
    public string userJson,canonJson;
    public string initUserInfo;
    Dictionary<string, object> userData;
    public bool pressOnce;
    public bool canonBool1, canonBool2, canonBool3, canonBool4, canonBool5;
    public GameObject canon1, canon2, canon3;
    public Transform canonPos;
    public TextAsset tmp;
    public Dictionary<string, object> dic;
    public GameObject anim;
    // Use this for initialization
    void Start () {
        if (!PlayerPrefs.HasKey("1001Name"))
        {
            List<Dictionary<string, object>> data = CSVReader.Read("Cannon");
            for (int i = 0; i < data.Count; i++)
            {

                PlayerPrefs.SetString(data[i]["id"].ToString() + "Name", data[i]["name"].ToString());
                PlayerPrefs.SetInt(data[i]["id"].ToString() + "Class", int.Parse(data[i]["class"].ToString()));
                if (!PlayerPrefs.HasKey(data[i]["id"].ToString() + "Level"))
                    PlayerPrefs.SetInt(data[i]["id"].ToString() + "Level", 1);
                if (!PlayerPrefs.HasKey(data[i]["hp"].ToString() + "Hp"))
                    PlayerPrefs.SetFloat(data[i]["id"].ToString() + "Hp", float.Parse(data[i]["hp"].ToString()));
                PlayerPrefs.SetFloat(data[i]["id"].ToString() + "Delay", float.Parse(data[i]["delay"].ToString()));
                PlayerPrefs.SetFloat(data[i]["id"].ToString() + "Power", float.Parse(data[i]["power_value"].ToString()));
                PlayerPrefs.SetFloat(data[i]["id"].ToString() + "Speed", float.Parse(data[i]["speed_value"].ToString()));
                PlayerPrefs.SetFloat(data[i]["id"].ToString() + "Scale", float.Parse(data[i]["scale_value"].ToString()));
                PlayerPrefs.SetFloat(data[i]["id"].ToString() + "Heal", float.Parse(data[i]["heal_value"].ToString()));
                PlayerPrefs.SetFloat(data[i]["id"].ToString() + "Hp", float.Parse(data[i]["hp"].ToString()));
                PlayerPrefs.SetInt(data[i]["id"].ToString() + "Class", int.Parse(data[i]["class"].ToString()));
                if (int.Parse(data[i]["id"].ToString()) == 1001 && !PlayerPrefs.HasKey(data[i]["id"].ToString() + "isOpened") && !PlayerPrefs.HasKey(data[i]["id"].ToString() + "isBuying"))
                {
                    Debug.Log(int.Parse(data[i]["id"].ToString()) == 1001 && !PlayerPrefs.HasKey(data[i]["id"].ToString() + "isOpened") && !PlayerPrefs.HasKey(data[i]["id"].ToString() + "isBuying"));
                    //isOpened = PlayerPrefs.GetInt(canonID.ToString() + "isOpened", 1);
                    //isBuying = PlayerPrefs.GetInt(canonID.ToString() + "isBuying", 1);
                    PlayerPrefs.SetInt(data[i]["id"].ToString() + "isOpened", 1);
                    PlayerPrefs.SetInt(data[i]["id"].ToString() + "isBuying", 1);
                }
                else if (!PlayerPrefs.HasKey(data[i]["id"].ToString() + "isOpened") && !PlayerPrefs.HasKey(data[i]["id"].ToString() + "isBuying") && (int.Parse(data[i]["id"].ToString()) == 1002 || int.Parse(data[i]["id"].ToString()) == 1006 || int.Parse(data[i]["id"].ToString()) == 1010 || int.Parse(data[i]["id"].ToString()) == 1014 || int.Parse(data[i]["id"].ToString()) == 1018 || int.Parse(data[i]["id"].ToString()) == 1022 || int.Parse(data[i]["id"].ToString()) == 1026))
                {
                    //isOpened = PlayerPrefs.GetInt(canonID.ToString() + "isOpened", 1);
                    //isBuying = PlayerPrefs.GetInt(canonID.ToString() + "isBuying", 0);
                    PlayerPrefs.SetInt(data[i]["id"].ToString() + "isOpened", 1);
                    PlayerPrefs.SetInt(data[i]["id"].ToString() + "isBuying", 0);
                }
                else
                {
                    //isOpened = PlayerPrefs.GetInt(canonID.ToString() + "isOpened", 0);
                    //isBuying = PlayerPrefs.GetInt(canonID.ToString() + "isBuying", 0);
                    PlayerPrefs.SetInt(data[i]["id"].ToString() + "isOpened", 0);
                    PlayerPrefs.SetInt(data[i]["id"].ToString() + "isBuying", 0);
                }
                //+ "\n" + "공격력 : " + data[i]["Atk"] + "\n" + "마법공격력 : " + data[i]["MAtk"] + "\n" + "방어력 : " + data[i]["Def"] + "\n" + "마법방어력 : " + data[i]["MDef"] + "\n");
            }
            if (!PlayerPrefs.HasKey("selectedCanonID"))
                PlayerPrefs.SetInt("selectedCanonID", 1001);
            if (!PlayerPrefs.HasKey("gold"))
                PlayerPrefs.SetInt("gold", 0);
            if (!PlayerPrefs.HasKey("coin"))
                PlayerPrefs.SetInt("coin", 5);
            if (!PlayerPrefs.HasKey("cash"))
                PlayerPrefs.SetInt("cash", 0);
            if (!PlayerPrefs.HasKey("material"))
                PlayerPrefs.SetInt("material", 0);
            if (!PlayerPrefs.HasKey("stageNum"))
                PlayerPrefs.SetInt("stageNum", 1);
        }
        canonBool1 = true;
        canonBool2 = true;
        canonBool3 = true;
        canonBool4 = true;
        PlayerPrefs.SetInt("coin", 5);
        //PlayerPrefs.SetInt("cash", 9999);
        //PlayerPrefs.SetInt("gold", 999999);
        //PlayerPrefs.SetInt("material", 999999);
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        bestStage = PlayerPrefs.GetInt("stageNum", 1);
        coinValue = PlayerPrefs.GetInt("coin", 5);
        cashValue = PlayerPrefs.GetInt("cash", 0);
        goldValue = PlayerPrefs.GetInt("gold", 0);
        materialValue = PlayerPrefs.GetInt("material", 0);
        selectedCanonID = PlayerPrefs.GetInt("selectedCanonID", 0);
        coin.text = coinValue + "/5";
        cash.text = cashValue.ToString();
        gold.text = goldValue.ToString();
        material.text = materialValue.ToString();
        bestScoreText.text = bestScore.ToString();
        bestStageText.text = bestStage.ToString();
        if(selectedCanonID == 0)
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
            selectedCanonName.text = PlayerPrefs.GetString(selectedCanonID.ToString()+"Name");
            selectedCanonLevel.text = PlayerPrefs.GetInt(selectedCanonID.ToString() + "Level").ToString();
            selectedCanonHp.text = PlayerPrefs.GetFloat(selectedCanonID.ToString() + "Hp").ToString();
            selectedCanonDelay.text = PlayerPrefs.GetFloat(selectedCanonID.ToString() + "Delay").ToString();
            selectedCanonPower.text = PlayerPrefs.GetFloat(selectedCanonID.ToString() + "Power").ToString();
            selectedCanonScale.text = PlayerPrefs.GetFloat(selectedCanonID.ToString() + "Scale").ToString();
            selectedCanonHeal.text = PlayerPrefs.GetFloat(selectedCanonID.ToString() + "Heal").ToString();
            selectedCanonSpeed.text = PlayerPrefs.GetFloat(selectedCanonID.ToString() + "Speed").ToString();
            GameObject tmp = GameObject.FindGameObjectWithTag("canon");
            int canonType;
            if (selectedCanonID != 1001)
                canonType = (selectedCanonID % 4) + 1;
            else
                canonType = 3;
            switch (canonType)
            {
                case 1:
                    if (canonBool1)
                    {
                        if (tmp != null)
                        {
                            Destroy(tmp);
                        }
                        tmp = Instantiate(canon2, canonPos.position,canon2.transform.rotation);
                        canonBool2 = true;
                        canonBool3 = true;
                        canonBool4 = true;
                        canonBool5 = true;
                        canonBool1 = false;
                    }

                    break;
                case 2:
                    if (canonBool2)
                    {
                        if (tmp != null)
                        {
                            Destroy(tmp);
                        }
                        tmp = Instantiate(canon3, canonPos.position, canon3.transform.rotation);
                        canonBool1 = true;
                        canonBool3 = true;
                        canonBool4 = true;
                        canonBool5 = true;
                        canonBool2 = false;
                    }
                    break;
                case 3:
                    if (canonBool3)
                    {
                        if (tmp != null)
                        {
                            Destroy(tmp);
                        }
                        tmp = Instantiate(canon1, canonPos.position, canon1.transform.rotation);
                        canonBool2 = true;
                        canonBool1 = true;
                        canonBool4 = true;
                        canonBool5 = true;
                        canonBool3 = false;
                    }
                    break;
                case 4:
                    if (canonBool4)
                    {
                        if (tmp != null)
                        {
                            Destroy(tmp);
                        }
                        tmp = Instantiate(canon1, canonPos.position, canon1.transform.rotation);
                        canonBool2 = true;
                        canonBool3 = true;
                        canonBool1 = true;
                        canonBool5 = true;
                        canonBool4 = false;
                    }
                    break;
            }
           

        }
        //if(Application.platform==RuntimePlatform.WindowsEditor)
        //{
        //    TextAsset data = Resources.Load(id.ToString()) as TextAsset;
        //    userJson = data.text;
        //    userData = Json.Deserialize(userJson) as Dictionary<string, object>;
        //    bestStage.text = userData["stageNum"].ToString();
        //    bestScore.text = userData["bestScore"].ToString();
        //    coin.text = userData["coin"].ToString() + "/5";
        //    cash.text = userData["cash"].ToString();
        //    gold.text = userData["gold"].ToString();
        //    material.text = userData["material"].ToString();
        //    if (int.Parse(userData["canonID"].ToString()) == 0)
        //    {
        //        selectedCanonName.text = "";
        //        selectedCanonLevel.text = "";
        //        selectedCanonHp.text = "";
        //        selectedCanonDelay.text = "";
        //        selectedCanonPower.text = "";
        //        selectedCanonScale.text = "";
        //        selectedCanonHeal.text = "";
        //    }
        //    else
        //    {
        //        TextAsset canonData = Resources.Load(userData["canonID"].ToString()) as TextAsset;
        //        Dictionary<string, object> userCanonData;
        //        canonJson = canonData.text;
        //        userCanonData = Json.Deserialize(canonJson) as Dictionary<string, object>;
        //        selectedCanonName.text = userCanonData["CanonName"].ToString();
        //        selectedCanonLevel.text = userCanonData["CanonLevel"].ToString();
        //        selectedCanonHp.text = userCanonData["CanonHp"].ToString();
        //        selectedCanonPower.text = userCanonData["CanonPower"].ToString();
        //        selectedCanonDelay.text = userCanonData["CanonDelay"].ToString();
        //        selectedCanonHeal.text = userCanonData["CanonHeal"].ToString();
        //        selectedCanonScale.text = userCanonData["CanonScale"].ToString();
        //        selectedCanonSpeed.text = userCanonData["CanonSpeed"].ToString();

        //    }

        //}
        //else if(Application.platform==RuntimePlatform.Android)
        //{

        //    userJson = File.ReadAllText(Application.persistentDataPath+id.ToString()+".json");
        //    if (userJson == null)
        //    {
        //        File.WriteAllText(Application.persistentDataPath + id.ToString() + ".json", initUserInfo);
        //        userJson=File.ReadAllText(Application.persistentDataPath + id.ToString() + ".json");
        //    }
        //    userData = Json.Deserialize(userJson) as Dictionary<string, object>;
        //    bestStage.text = userData["stageNum"].ToString();
        //    bestScore.text = userData["bestScore"].ToString();
        //    coin.text = userData["coin"].ToString() + "/5";
        //    cash.text = userData["cash"].ToString();
        //    gold.text = userData["gold"].ToString();
        //    material.text = userData["material"].ToString();
        //    if (int.Parse(userData["canonID"].ToString()) == 0)
        //    {
        //        selectedCanonName.text = "";
        //        selectedCanonLevel.text = "";
        //        selectedCanonHp.text = "";
        //        selectedCanonDelay.text = "";
        //        selectedCanonPower.text = "";
        //        selectedCanonScale.text = "";
        //        selectedCanonHeal.text = "";
        //    }
        //    else
        //    {
        //        TextAsset canonData = Resources.Load(userData["canonID"].ToString()) as TextAsset;
        //        Dictionary<string, object> userCanonData;
        //        canonJson = canonData.text;
        //        userCanonData = Json.Deserialize(canonJson) as Dictionary<string, object>;
        //        selectedCanonName.text = userCanonData["CanonName"].ToString();
        //        selectedCanonLevel.text = userCanonData["CanonLevel"].ToString();
        //        selectedCanonHp.text = userCanonData["CanonHp"].ToString();
        //        selectedCanonPower.text = userCanonData["CanonPower"].ToString();
        //        selectedCanonDelay.text = userCanonData["CanonDelay"].ToString();
        //        selectedCanonHeal.text = userCanonData["CanonHeal"].ToString();
        //        selectedCanonScale.text = userCanonData["CanonScale"].ToString();
        //        selectedCanonSpeed.text = userCanonData["CanonSpeed"].ToString();

        //    }
        //}
        
        
        pressOnce = true;
        //stageNum = int.Parse(userData["stageNum"].ToString());
        //gold = int.Parse(userData["gold"].ToString());
        //cash = int.Parse(userData["cash"].ToString());
        //material = int.Parse(userData["material"].ToString());

    }

    // Update is called once per frame
    public void MoveInventory()
    {
        SceneManager.LoadScene("Inventory");
    }
    public void MoveShop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void GameStart()
    {
        if(pressOnce)
        {
            PlayerPrefs.SetInt("coin", coinValue - 1);
            SceneManager.LoadScene("Stage");
            pressOnce = false;
        }
    }
}
