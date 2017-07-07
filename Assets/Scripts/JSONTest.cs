using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using System.IO;

public class JSONTest : MonoBehaviour {
    public int id, stageNum, gold, cash, material;
    public string JSon,canonJson;
    public CanonStatus[] canons;
    public Dictionary<string, object> userData,canonData;
	// Use this for initialization
	void Awake () {
        TextAsset data = Resources.Load(id.ToString()) as TextAsset;
        JSon = data.text;
        userData = Json.Deserialize(JSon) as Dictionary<string, object>;
        stageNum=int.Parse(userData["stageNum"].ToString());
        gold = int.Parse(userData["gold"].ToString());
        cash = int.Parse(userData["cash"].ToString());
        material = int.Parse(userData["material"].ToString());

        
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
            canons[i].atk = float.Parse(canonData["Atk"].ToString());
            canons[i].hp = float.Parse(canonData["CanonHp"].ToString());
            canons[i].delay = float.Parse(canonData["CanonDelay"].ToString());
            canons[i].canonLevel = int.Parse(canonData["CanonLevel"].ToString());
            canons[i].heal = float.Parse(canonData["Heal"].ToString());
            canons[i].canonClass = int.Parse(canonData["CanonClass"].ToString());
            canons[i].scale = float.Parse(canonData["Scale"].ToString());
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
