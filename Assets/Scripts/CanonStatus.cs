using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using MiniJSON;
using System.IO;
using System.Text;

public class CanonStatus : MonoBehaviour {
    public string canonName;
    public int canonID,canonLevel,canonClass, selectCanonID,goldPrice,materialPrice,levelLimit;
    public float hp, delay, atk, scale, heal,speed, scaleInc,scaleLimit,hpInc,dlyInc,atkInc,healInc,speedInc;
    Dictionary<string, object> jsonData;
    Dictionary<string, object> userInfoData;
    public TextAsset temp;
    public JSONTest info;
    public string userInfo;
    int tmpGold, tmpCash, tmpMaterial;
    // Use this for initialization
    void Start () {
        info = GameObject.FindObjectOfType<JSONTest>();
        temp = Resources.Load(info.id.ToString()) as TextAsset;
        userInfo = temp.text;
        userInfoData = Json.Deserialize(userInfo) as Dictionary<string, object>;
        //canonLevel = PlayerPrefs.GetInt("CanonLevel", 1);
        //hp = PlayerPrefs.GetFloat("Hp", hp);
        //delay = PlayerPrefs.GetFloat("Delay", delay);
        //atk = PlayerPrefs.GetFloat("ATK", atk);
        //scale = PlayerPrefs.GetFloat("Scale", scale);
        //heal = PlayerPrefs.GetFloat("Heal", heal);
    }
	
	// Update is called once per frame
	void Update () {
        

	}
    public void CanonUpgrade()
    {
        switch (canonClass)
        {
            case 1:
                goldPrice = 500;
                materialPrice = 5;
                scaleInc = 0.005f;
                hpInc = 3;
                dlyInc = 0.01f;
                atkInc = 1;
                healInc = 10;
                speedInc = 0.1f;
                levelLimit = 15;
                break;
            case 2:
                goldPrice = 1000;
                materialPrice = 10;
                scaleInc = 0.005f;
                hpInc = 5;
                dlyInc = 0.02f;
                atkInc = 2;
                healInc = 20;
                speedInc = 0.1f;
                levelLimit = 30;
                break;
            case 3:
                goldPrice = 2000;
                materialPrice = 20;
                scaleInc = 0.005f;
                hpInc = 8;
                dlyInc = 0.03f;
                atkInc = 3;
                healInc = 50;
                speedInc = 0.2f;
                levelLimit = 45;
                break;
            case 4:
                goldPrice = 5000;
                materialPrice = 50;
                scaleInc = 0.005f;
                hpInc = 15;
                dlyInc = 0.05f;
                atkInc = 5;
                healInc = 100;
                speedInc = 0.2f;
                levelLimit = 15;
                break;
        }
        if(int.Parse(userInfoData["gold"].ToString())>canonLevel*goldPrice&& 
            int.Parse(userInfoData["material"].ToString())> canonLevel * materialPrice&&canonLevel<levelLimit)
        {
            if(scale!=0)
            {
                scale = 1 + canonLevel * scaleInc;
                if (scale > scaleLimit)
                    scale = scaleLimit;
            }
            hp = hp + canonLevel * hpInc;
            delay = delay - canonLevel * dlyInc;
            if(atk!=0)
                atk = atk + canonLevel * atkInc;
            if(heal!=0)
                heal = heal + canonLevel * healInc;
            if(speed!=0)
                speed = speed + canonLevel * speedInc;
            jsonData = new Dictionary<string, object>();
            jsonData.Add("CanonName", canonName);
            jsonData.Add("CanonClass", canonClass);
            jsonData.Add("CanonHp", hp);
            jsonData.Add("CanonDelay", delay);
            jsonData.Add("CanonPower", atk);
            jsonData.Add("CanonHeal", heal);
            jsonData.Add("CanonScale", scale);
            jsonData.Add("CanonSpeed", speed);
            tmpGold = int.Parse(userInfoData["gold"].ToString()) - canonLevel * goldPrice;
            tmpMaterial = int.Parse(userInfoData["material"].ToString()) - canonLevel * materialPrice;
            userInfoData["gold"] = tmpGold;
            userInfoData["material"] = tmpMaterial;
            canonLevel++;
            jsonData.Add("CanonLevel", canonLevel);
            string data = Json.Serialize(jsonData);
            string userData = Json.Serialize(userInfoData);
            //byte[] bytesForEncoding = Encoding.UTF8.GetBytes(data);
            //data = Convert.ToBase64String(bytesForEncoding);
            File.WriteAllText(Application.dataPath + @"\Resources\" + canonID.ToString() + ".json", data);
            File.WriteAllText(Application.dataPath + @"\Resources\" + info.id.ToString() + ".json", userData);
        }
        else if(int.Parse(userInfoData["gold"].ToString()) < canonLevel * goldPrice)
        {
            Debug.Log("골드가 부족합니다.");
        }
        else if(int.Parse(userInfoData["material"].ToString()) < canonLevel * materialPrice)
        {
            Debug.Log("재료가 부족합니다.");
        }
        else if(int.Parse(userInfoData["gold"].ToString()) < canonLevel * goldPrice&& int.Parse(userInfoData["material"].ToString()) < canonLevel * materialPrice)
        {
            Debug.Log("골드와 재료가 부족합니다.");
        }
        else if(canonLevel>=levelLimit)
        {
            Debug.Log("이미 최고 레벨입니다.");
        }
    }
    public void SelectCanon()
    {
        jsonData = new Dictionary<string, object>();
        jsonData.Add("CanonID", canonID);
        jsonData.Add("CanonName", canonName);
        jsonData.Add("CanonClass", canonClass);
        jsonData.Add("CanonHp", hp);
        jsonData.Add("CanonDelay", delay);
        jsonData.Add("CanonPower", atk);
        jsonData.Add("CanonHeal", heal);
        jsonData.Add("CanonScale", scale);
        jsonData.Add("CanonLevel", canonLevel);
        jsonData.Add("CanonSpeed", speed);
        string data = Json.Serialize(jsonData);
        File.WriteAllText(Application.dataPath + @"\Resources\selectedCanonInfo.json", data);
        userInfoData["canonID"] = canonID;
        string userData = Json.Serialize(userInfoData);
        File.WriteAllText(Application.dataPath + @"\Resources\" + info.id.ToString() + ".json", userData);
    }
}
