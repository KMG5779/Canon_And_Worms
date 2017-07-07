using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

public class testBtn : MonoBehaviour {
    public GameObject canon1,canon2,canon3,canon4,canon5;
    public Transform canonPos;
    public SpringPanel springPanel;
    public UITable uiTable;
    public UILabel label1,canonLevelInfo, canonHpInfo, canonPwInfo, canonDlyInfo, canonHealInfo, canonScaleInfo,canonNameInfo;
    public UILabel canonHpIncInfo, canonPwIncInfo, canonDlyIncInfo, canonHealIncInfo, canonScaleIncInfo;
    public UILabel gold, cash, material;
    public UISprite sprite;
    public CanonStatus canonstat;
    public JSONTest data;
    public float pageSize,xPos;
    public int limit; 
    public int pgSize,pageCount,page;
    public string sprName;
    public bool canonBool1,canonBool2,canonBool3,canonBool4,canonBool5;
    bool once;
    void Start()
    {
        canonBool1 = true;
        canonBool2 = true;
        canonBool3 = true;
        canonBool4 = true;
        canonBool5 = true; 
        springPanel = GameObject.FindObjectOfType<SpringPanel>();
        limit = uiTable.GetChildList().Count;
        pgSize = (int)pageSize;
        once = true;
        gold.text=data.userData["gold"].ToString();
        cash.text = data.cash.ToString();
        material.text = data.material.ToString();
    }
    void Update()
    {
        if (once)
        {
            springPanel = GameObject.FindObjectOfType<SpringPanel>();
            
            once = false;
        }
        xPos = springPanel.target.x;
        if (xPos >-286)
            page = 1;
        else if (xPos >-1501)
            page = 2;
        else if (xPos > -2720)
            page = 3;
        else if (xPos > -3943)
            page = 4;
        else if (xPos > -5166)
            page = 5;
        else if (xPos > -6388)
            page = 6;
        switch(page)
        {
            case 1:
                label1.text = "1/"+uiTable.GetChildList().Count;
                break;
            case 2:
                label1.text = "2/"+uiTable.GetChildList().Count;
                break;
            case 3:
                label1.text = "3/"+ uiTable.GetChildList().Count;
                break;
            case 4:
                label1.text = "4/"+ uiTable.GetChildList().Count; 
                break;
            case 5:
                label1.text = "5/"+ uiTable.GetChildList().Count; 
                break;
            case 6:
                label1.text = "6/"+ uiTable.GetChildList().Count;
                break;
            case 7:
                label1.text = "7/"+ uiTable.GetChildList().Count;
                break;
            case 8:
                label1.text = "8/" + uiTable.GetChildList().Count;
                break;
            case 9:
                label1.text = "9/" + uiTable.GetChildList().Count;
                break;
        }
    }
    public void TestBoots()
    { 
        Ray ray=UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            canonstat = hit.collider.gameObject.GetComponent<CanonStatus>();
        }
        GameObject tmp=GameObject.FindGameObjectWithTag("canon");
        
        switch(canonstat.canonID)
        {
            case 1:
                if(canonBool1)
                {
                    if (tmp != null)
                    {
                        Destroy(tmp);
                    }
                    tmp = Instantiate(canon1, canonPos);
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
                    tmp = Instantiate(canon2, canonPos);
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
                    tmp = Instantiate(canon3, canonPos);
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
                    tmp = Instantiate(canon4, canonPos);
                    canonBool2 = true;
                    canonBool3 = true;
                    canonBool1 = true;
                    canonBool5 = true;
                    canonBool4 = false;
                }
                break;
            case 5:
                if (canonBool5)
                {
                    if (tmp != null)
                    {
                        Destroy(tmp);
                    }
                    tmp = Instantiate(canon5, canonPos);
                    canonBool2 = true;
                    canonBool3 = true;
                    canonBool4 = true;
                    canonBool1 = true;
                    canonBool5 = false;
                }
                break;
        }
        canonNameInfo.text = canonstat.canonName;
        canonLevelInfo.text = canonstat.canonLevel.ToString();
        canonHpInfo.text = canonstat.hp.ToString();
        canonDlyInfo.text = canonstat.delay.ToString();
        canonPwInfo.text = canonstat.atk.ToString();
        canonHealInfo.text = canonstat.heal.ToString();
        canonScaleInfo.text = canonstat.scale.ToString();
        
    }
    public void UpgradeCanon()
    {
        canonstat.canonLevel++;
        canonstat.CanonUpgrade();
        canonLevelInfo.text = canonstat.canonLevel.ToString();
        canonHpInfo.text = canonstat.hp.ToString();
        canonDlyInfo.text = canonstat.delay.ToString();
        canonPwInfo.text = canonstat.atk.ToString();
        canonHealInfo.text = canonstat.heal.ToString();
        canonScaleInfo.text = canonstat.scale.ToString();
        
    }
    public void SelectCanon()
    {
        canonstat.SelectCanon();
    }
    public void QuitInventory()
    {
        Application.LoadLevel(1);
    }
    //public void Test()
    //{
    //    canonNameInfo.text = canonstat.canonName;
    //    canonHpInfo.text = canonstat.hp.ToString();
    //    canonDlyInfo.text = canonstat.delay.ToString();
    //    canonPwInfo.text = canonstat.atk.ToString();
    //    canonHealInfo.text = canonstat.heal.ToString();
    //    canonScaleInfo.text = canonstat.scale.ToString();
    //}
    //public void TestGrove()
    //{
    //    sprName = "Orc Armor - Bracers";
    //    sprite.spriteName = sprName;
    //    Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        canonstat = hit.collider.gameObject.GetComponent<CanonStatus>();
    //    }

    //    canonHpInfo.text = canonstat.hp.ToString();
    //    canonDlyInfo.text = canonstat.delay.ToString();
    //    canonPwInfo.text = canonstat.atk.ToString();
    //    canonHealInfo.text = canonstat.heal.ToString();
    //    canonScaleInfo.text = canonstat.scale.ToString();
    //}
    //public void TestETC()
    //{
    //    sprName = "Orc Armor - Shoulders";
    //    sprite.spriteName = sprName;
    //    Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        canonstat = hit.collider.gameObject.GetComponent<CanonStatus>();
    //    }

    //    canonHpInfo.text = canonstat.hp.ToString();
    //    canonDlyInfo.text = canonstat.delay.ToString();
    //    canonPwInfo.text = canonstat.atk.ToString();
    //    canonHealInfo.text = canonstat.heal.ToString();
    //    canonScaleInfo.text = canonstat.scale.ToString();
    //}
    //public void PressOne()
    //{
    //        springPanel = GameObject.FindObjectOfType<SpringPanel>();
    //        springPanel.enabled = true;
    //        springPanel.target.x = 0;
    //        springPanel.enabled = true;
    //}

    //public void PressTwo()
    //{
    //        springPanel = GameObject.FindObjectOfType<SpringPanel>();
    //        springPanel.enabled = true;
    //        springPanel.target.x = pageSize;
    //        springPanel.enabled = true;
    //}

    //public void PressThree()
    //{
    //    springPanel = GameObject.FindObjectOfType<SpringPanel>();
    //    springPanel.enabled = true;
    //    springPanel.target.x = pageSize * 2;
    //    springPanel.enabled = true;
    //}

    //public void PressFour()
    //{
    //    springPanel = GameObject.FindObjectOfType<SpringPanel>();
    //    springPanel.enabled = true;
    //    springPanel.target.x = pageSize * 3;
    //    springPanel.enabled = true;
    //}
    //public void PressFive()
    //{
    //    springPanel = GameObject.FindObjectOfType<SpringPanel>();
    //    springPanel.enabled = true;
    //    springPanel.target.x = pageSize * 4;
    //    springPanel.enabled = true;
    //}
    //public void PressSix()
    //{
    //    springPanel = GameObject.FindObjectOfType<SpringPanel>();
    //    springPanel.enabled = true;
    //    springPanel.target.x = pageSize * 5;
    //    springPanel.enabled = true;
    //}
    //public void PressSeven()
    //{
    //    springPanel = GameObject.FindObjectOfType<SpringPanel>();
    //    springPanel.enabled = true;
    //    springPanel.target.x = pageSize * 6;
    //    springPanel.enabled = true;
    //}
}
