using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using MiniJSON;
using System.IO;
using System.Text;

public class CanonStatus : MonoBehaviour {
    public string canonName;
    public int canonID,canonLevel,canonClass;
    public float hp, delay, atk, scale, heal,speed, scaleInc,scaleLimit,hpInc,dlyInc,atkInc,healInc,speedInc;
    Dictionary<string, object> jsonData;
	// Use this for initialization
	void Start () {
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
        scale = canonLevel * (1 + scaleInc);
        if (scale > scaleLimit)
            scale = scaleLimit;
        hp = hp + canonLevel * hpInc;
        delay = delay - canonLevel * dlyInc;
        atk = atk + canonLevel * atkInc;
        heal = heal + canonLevel * healInc;
        speed = speed + canonLevel * speedInc;
        jsonData = new Dictionary<string, object>();
        jsonData.Add("CanonName", canonName);
        jsonData.Add("CanonClass", canonClass);
        jsonData.Add("CanonHp", hp);
        jsonData.Add("CanonDelay", delay);
        jsonData.Add("Atk", atk);
        jsonData.Add("Heal", heal);
        jsonData.Add("Scale", scale);
        jsonData.Add("CanonLevel", canonLevel);
        jsonData.Add("Speed", speed);
        string data = Json.Serialize(jsonData);
        //byte[] bytesForEncoding = Encoding.UTF8.GetBytes(data);
        //data = Convert.ToBase64String(bytesForEncoding);
        File.WriteAllText(Application.dataPath + @"\Resources\" + canonID.ToString() + ".json", data);
    }
    public void SelectCanon()
    {
        jsonData = new Dictionary<string, object>();
        jsonData.Add("CanonID", canonID);
        jsonData.Add("CanonName", canonName);
        jsonData.Add("CanonClass", canonClass);
        jsonData.Add("CanonHp", hp);
        jsonData.Add("CanonDelay", delay);
        jsonData.Add("Atk", atk);
        jsonData.Add("Heal", heal);
        jsonData.Add("Scale", scale);
        jsonData.Add("CanonLevel", canonLevel);
        jsonData.Add("Speed", speed);
        string data = Json.Serialize(jsonData);
        File.WriteAllText(Application.dataPath + @"\Resources\selectedCanonInfo.json", data);
    }
}
