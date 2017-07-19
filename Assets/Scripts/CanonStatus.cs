using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using MiniJSON;
using System.IO;
using System.Text;

public class CanonStatus : MonoBehaviour {
    public string canonName;
    public int canonID,canonLevel,canonClass, selectCanonID,goldPrice,materialPrice,levelLimit,isOpened,isBuying,openNext,openLevel;
    public float hp, delay, power, scale, heal, speed, scaleInc, scaleLimit, hpInc, dlyInc, atkInc, healInc, speedInc, nextHp, nextDelay, nextPower, nextScale, nextHeal, nextSpeed;
    Dictionary<string, object> jsonData;
    Dictionary<string, object> userInfoData;
    public TextAsset temp;
    public JSONTest info;
    public testBtn ui;
    public CanonStatus nextCanonStat;
    public string userInfo;
    public int tmpGold, tmpCash, tmpMaterial;
    // Use this for initialization
    void Awake () {
        canonName = PlayerPrefs.GetString(canonID.ToString() + "Name", canonName);
        canonLevel = PlayerPrefs.GetInt(canonID.ToString() + "Level", canonLevel);
        canonClass = PlayerPrefs.GetInt(canonID.ToString() + "Class", canonClass);
        hp = PlayerPrefs.GetFloat(canonID.ToString() + "Hp", hp);
        delay = PlayerPrefs.GetFloat(canonID.ToString() + "Delay", delay);
        power = PlayerPrefs.GetFloat(canonID.ToString() + "Power", power);
        scale = PlayerPrefs.GetFloat(canonID.ToString() + "Scale", scale);
        heal = PlayerPrefs.GetFloat(canonID.ToString() + "Heal", heal);
        speed = PlayerPrefs.GetFloat(canonID.ToString() + "Speed", speed);
        openLevel = PlayerPrefs.GetInt(canonID.ToString() + "OpenLevel", openLevel);
        if (canonID == 1001)
        {
            if (!PlayerPrefs.HasKey(canonID.ToString() + "isOpened") && !PlayerPrefs.HasKey(canonID.ToString() + "isBuying"))
            {
                isOpened = PlayerPrefs.GetInt(canonID.ToString() + "isOpened", 1);
                isBuying = PlayerPrefs.GetInt(canonID.ToString() + "isBuying", 1);
                PlayerPrefs.SetInt(canonID.ToString() + "isOpened", isOpened);
                PlayerPrefs.SetInt(canonID.ToString() + "isBuying", isBuying);
            }
            else
            {
                isOpened = PlayerPrefs.GetInt(canonID.ToString() + "isOpened");
                isBuying = PlayerPrefs.GetInt(canonID.ToString() + "isBuying");
            }
        }
        else if (canonID == 1002 || canonID == 1006 || canonID == 1010 || canonID == 1014 || canonID == 1018 || canonID == 1022 || canonID == 1026)
        {
            if (!PlayerPrefs.HasKey(canonID.ToString() + "isOpened") && !PlayerPrefs.HasKey(canonID.ToString() + "isBuying"))
            {
                isOpened = PlayerPrefs.GetInt(canonID.ToString() + "isOpened", 1);
                isBuying = PlayerPrefs.GetInt(canonID.ToString() + "isBuying", 0);
                PlayerPrefs.SetInt(canonID.ToString() + "isOpened", isOpened);
                PlayerPrefs.SetInt(canonID.ToString() + "isBuying", isBuying);
            }
            else
            {
                isOpened = PlayerPrefs.GetInt(canonID.ToString() + "isOpened");
                isBuying = PlayerPrefs.GetInt(canonID.ToString() + "isBuying");
            }
        }
        else
        {
            if (!PlayerPrefs.HasKey(canonID.ToString() + "isOpened") && !PlayerPrefs.HasKey(canonID.ToString() + "isBuying"))
            {
                isOpened = PlayerPrefs.GetInt(canonID.ToString() + "isOpened", 0);
                isBuying = PlayerPrefs.GetInt(canonID.ToString() + "isBuying", 0);
                PlayerPrefs.SetInt(canonID.ToString() + "isOpened", isOpened);
                PlayerPrefs.SetInt(canonID.ToString() + "isBuying", isBuying);
            }
            else
            {
                isOpened = PlayerPrefs.GetInt(canonID.ToString() + "isOpened");
                isBuying = PlayerPrefs.GetInt(canonID.ToString() + "isBuying");
            }
        }
        scaleLimit = 1000;
        
        //canonLevel = PlayerPrefs.GetInt("CanonLevel", 1);
        //hp = PlayerPrefs.GetFloat("Hp", hp);
        //delay = PlayerPrefs.GetFloat("Delay", delay);
        //atk = PlayerPrefs.GetFloat("ATK", atk);
        //scale = PlayerPrefs.GetFloat("Scale", scale);
        //heal = PlayerPrefs.GetFloat("Heal", heal);
    }
    void Start()
    {
        ui = GameObject.FindObjectOfType<testBtn>();
        if(isOpened==1&&isBuying==1)
        {
            transform.FindChild("Disabled").gameObject.SetActive(false);
            transform.FindChild("Buy The This").gameObject.SetActive(false);
        }
        else if(isBuying==0&&isOpened==1)
        {
            transform.FindChild("Disabled").gameObject.SetActive(false);
            transform.FindChild("Buy The This").gameObject.SetActive(true);
        }
        else 
        {
            transform.FindChild("Disabled").gameObject.SetActive(true);
            transform.FindChild("Buy The This").gameObject.SetActive(true);
        }
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
                levelLimit = 20;
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
                levelLimit = 35;

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
                levelLimit = 100;
                break;
        }
        if(scale!=0)
            nextScale = 1 + (canonLevel + 1) * scaleInc;
        nextHp = hp + (canonLevel + 1) * hpInc;
        if (power != 0)
            nextPower = power + (canonLevel + 1) * atkInc;
        else
            nextPower = 0;
        if (heal != 0)
            nextHeal = heal + (canonLevel + 1) * healInc;
        else
            nextHeal = 0;
        if (speed != 0)
            nextSpeed = speed + (canonLevel + 1) * speedInc;
        else
            nextSpeed = 0;
        nextDelay = delay - (canonLevel + 1) * dlyInc;
        
    }
	
	// Update is called once per frame
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
                levelLimit = 20;
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
                levelLimit = 35;
                
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
                levelLimit = 100;
                break;
        }
        if (ui.goldValue > canonLevel * goldPrice &&
            ui.materialValue > canonLevel * materialPrice && canonLevel < levelLimit && isBuying == 1)
        {
            if (scale != 0)
            {
                scale = 1 + canonLevel * scaleInc;
                nextScale = 1 + (canonLevel + 1) * scaleInc;
                if (scale > scaleLimit)
                    scale = scaleLimit;
              
            }
            hp = hp + canonLevel * hpInc;
            nextHp = hp + (canonLevel + 1) * hpInc;
       
            delay = delay - canonLevel * dlyInc;
            nextDelay = delay - (canonLevel + 1) * dlyInc;

            if (power != 0)
            {
                power = power + canonLevel * atkInc;
                nextPower = power + (canonLevel + 1) * atkInc;
               
            }
            if (heal != 0)
            {
                heal = heal + canonLevel * healInc;
                nextHeal = heal + (canonLevel+1) * healInc;
        
            }
            if (speed != 0)
            {
                speed = speed + canonLevel * speedInc;
                nextSpeed = speed + (canonLevel + 1) * speedInc;
                
            }
            PlayerPrefs.SetString(canonID.ToString() + "Name", canonName);
            PlayerPrefs.SetInt(canonID.ToString() + "Class", canonClass);
            PlayerPrefs.SetFloat(canonID.ToString() + "Hp", hp);
            PlayerPrefs.SetFloat(canonID.ToString() + "Delay", delay);
            PlayerPrefs.SetFloat(canonID.ToString() + "Power", power);
            PlayerPrefs.SetFloat(canonID.ToString() + "Heal", heal);
            PlayerPrefs.SetFloat(canonID.ToString() + "Scale", scale);
            PlayerPrefs.SetFloat(canonID.ToString() + "Speed", speed);

            tmpGold = ui.goldValue - canonLevel * goldPrice;
            ui.goldValue -= canonLevel * goldPrice;
            tmpMaterial = ui.materialValue - canonLevel * materialPrice;
            ui.materialValue -= canonLevel * materialPrice;
            PlayerPrefs.SetInt("gold", tmpGold);
            PlayerPrefs.SetInt("material", tmpMaterial);
            canonLevel++;
            PlayerPrefs.SetInt(canonID.ToString() + "Level", canonLevel);
            if(canonLevel==35&&canonClass==3)
            {
                int nextCanon;
                nextCanon = canonID + 1;
                PlayerPrefs.SetInt(nextCanon.ToString() + "isOpened", 1);
                PlayerPrefs.SetInt(nextCanon.ToString() + "isBuying", 1);
                nextCanonStat.isOpened = 1;
                nextCanonStat.isBuying = 1;
            }
        }
        else if (isBuying == 0)
            Debug.Log("구매도 안한 게 까불고 있어!");
        else if (ui.goldValue < canonLevel * goldPrice)
        {
            Debug.Log("골드가 부족합니다.");

        }
        else if (ui.materialValue < canonLevel * materialPrice)
        {
            Debug.Log("재료가 부족합니다.");
        }
        else if (ui.goldValue < canonLevel * goldPrice && ui.materialValue < canonLevel * materialPrice)
        {
            Debug.Log("골드와 재료가 부족합니다.");
        }
        else if (canonLevel == levelLimit-1&&canonID!=1001)
        {
            Debug.Log("이미 최고 레벨입니다.");
            int nextCanon = canonID + 1;
            PlayerPrefs.SetInt(nextCanon.ToString() + "isOpened", 1);
            nextCanonStat.isOpened = 1;
        }
        else if(canonLevel == levelLimit)
        {
            Debug.Log("만렙이라고!");
            int nextCanon = canonID + 1;
            PlayerPrefs.SetInt(nextCanon.ToString() + "isOpened", 1);
            nextCanonStat.isOpened = 1;
        }
        ui.refresh = true;
    }
    public void SelectCanon()
    {
        if(isBuying==1)
        {
            PlayerPrefs.SetInt("selectedCanonID", canonID);
            PlayerPrefs.SetString(canonID.ToString() + "Name", canonName);
            PlayerPrefs.SetInt(canonID.ToString() + "Class", canonClass);
            PlayerPrefs.SetFloat(canonID.ToString() + "Hp", hp);
            PlayerPrefs.SetFloat(canonID.ToString() + "Delay", delay);
            PlayerPrefs.SetFloat(canonID.ToString() + "Power", power);
            PlayerPrefs.SetFloat(canonID.ToString() + "Heal", heal);
            PlayerPrefs.SetFloat(canonID.ToString() + "Scale", scale);
            PlayerPrefs.SetFloat(canonID.ToString() + "Speed", speed);
            PlayerPrefs.SetInt(canonID.ToString() + "Level", canonLevel);
        }
        else
        {
            Debug.Log("구매부터 하시죠.");
        }
        


    }

}
