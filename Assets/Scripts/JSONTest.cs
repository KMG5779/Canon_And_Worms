using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using System.IO;

public class JSONTest : MonoBehaviour {
    public int id, stageNum, gold, cash, material;
    public string JSon,canonJson;
    public CanonStatus[] canons;
    public TextAsset userData;
    public Dictionary<string, object> userInfoData,canonData;
	// Use this for initialization
	void Awake () {
        
        userData = Resources.Load(id.ToString()) as TextAsset;
        JSon = userData.text;
        this.userInfoData = Json.Deserialize(JSon) as Dictionary<string, object>;
        stageNum = int.Parse(this.userInfoData["stageNum"].ToString());
        gold = int.Parse(this.userInfoData["gold"].ToString());
        cash = int.Parse(this.userInfoData["cash"].ToString());
        material = int.Parse(this.userInfoData["material"].ToString());

        
    }
    void Start()
    {
        TextAsset data;
        canons = GameObject.FindObjectsOfType<CanonStatus>();
        Debug.Log(canons.Length);
        for (int i = 0; i < canons.Length; i++)
        {

            data = Resources.Load(canons[i].canonID.ToString()) as TextAsset;
            canonJson = data.text;
            canonData = Json.Deserialize(canonJson) as Dictionary<string, object>;
            canons[i].canonName = canonData["CanonName"].ToString();
            canons[i].atk = float.Parse(canonData["CanonPower"].ToString());
            canons[i].hp = float.Parse(canonData["CanonHp"].ToString());
            canons[i].delay = float.Parse(canonData["CanonDelay"].ToString());
            canons[i].canonLevel = int.Parse(canonData["CanonLevel"].ToString());
            canons[i].heal = float.Parse(canonData["CanonHeal"].ToString());
            canons[i].canonClass = int.Parse(canonData["CanonClass"].ToString());
            canons[i].scale = float.Parse(canonData["CanonScale"].ToString());
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
