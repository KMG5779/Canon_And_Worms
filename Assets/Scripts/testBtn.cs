using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using UnityEngine.SceneManagement;
public class testBtn : MonoBehaviour {
    public GameObject canon1,canon2,canon3,canon4,canon5,tmp;
    public CanonStatus[] canons;
    public Transform canonPos;
    public SpringPanel springPanel;
    public UITable uiTable;
    public UILabel label1, canonLevelInfo, canonHpInfo, canonPwInfo, canonDlyInfo, canonHealInfo, canonScaleInfo, canonNameInfo, canonSpeedInfo;
    public UILabel canonHpIncInfo, canonPwIncInfo, canonDlyIncInfo, canonHealIncInfo, canonScaleIncInfo,canonSpeedIncInfo;
    public UILabel gold, cash, material,coin;
    public UISprite sprite;
    public CanonStatus canonstat;
    public JSONTest data;
    public float pageSize,xPos;
    public int limit;
    public int goldValue, cashValue, materialValue,coinValue;
    public int pgSize,pageCount,page;
    public string sprName,userData;
    TextAsset tmpData;
    public bool canonBool1,canonBool2,canonBool3,canonBool4,canonBool5;
    Dictionary<string, object> user;
    public bool once, refresh;
    public GameObject OptionPopUp;
    public UIPlaySound sound;
    public AudioClip PlaySE;
    void Start()
    {
        sound = GameObject.FindWithTag("levelup").GetComponent<UIPlaySound>();
        canonBool1 = true;
        canonBool2 = true;
        canonBool3 = true;
        canonBool4 = true;
        canonBool5 = true;
        if (PlayerPrefs.HasKey("selectedCanonID"))
        {
            int selectedCanonID = PlayerPrefs.GetInt("selectedCanonID"); 
            tmp = GameObject.FindGameObjectWithTag("canon");
            int canonType;
            if (PlayerPrefs.GetInt("selectedCanonID") != 1001)
                canonType = (PlayerPrefs.GetInt("selectedCanonID") % 4) + 1;
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
                        tmp = Instantiate(canon2, canonPos.position, canonPos.rotation);
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
                        tmp = Instantiate(canon3, canonPos.position, canonPos.rotation);
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
                        tmp = Instantiate(canon1, canonPos.position, canonPos.rotation);
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
                        tmp = Instantiate(canon1, canonPos.position, canonPos.rotation);
                        canonBool2 = true;
                        canonBool3 = true;
                        canonBool1 = true;
                        canonBool5 = true;
                        canonBool4 = false;
                    }
                    break;
            }
            canonNameInfo.text = PlayerPrefs.GetString(selectedCanonID.ToString() + "Name");
            canonLevelInfo.text = PlayerPrefs.GetInt(selectedCanonID.ToString() + "Level").ToString();
            canonHpInfo.text = PlayerPrefs.GetFloat(selectedCanonID.ToString() + "Hp").ToString();
            canonDlyInfo.text = PlayerPrefs.GetFloat(selectedCanonID.ToString() + "Delay").ToString();
            canonPwInfo.text = PlayerPrefs.GetFloat(selectedCanonID.ToString() + "Power").ToString();
            canonHealInfo.text = PlayerPrefs.GetFloat(selectedCanonID.ToString() + "Heal").ToString();
            canonScaleInfo.text = PlayerPrefs.GetFloat(selectedCanonID.ToString() + "Scale").ToString();
            canonSpeedInfo.text = PlayerPrefs.GetFloat(selectedCanonID.ToString() + "Speed").ToString();
            canonHpIncInfo.text = "";
            canonDlyIncInfo.text = "";
            canonPwIncInfo.text = "";
            canonHealIncInfo.text = "";
            canonScaleIncInfo.text = "";
            canonSpeedIncInfo.text = "";

        }
        springPanel = GameObject.FindObjectOfType<SpringPanel>();
        limit = uiTable.GetChildList().Count;
        pgSize = (int)pageSize;
        once = true;
        coinValue = PlayerPrefs.GetInt("coin", 5);
        cashValue = PlayerPrefs.GetInt("cash", 0);
        goldValue = PlayerPrefs.GetInt("gold", 0);
        materialValue = PlayerPrefs.GetInt("material", 0);
        coin.text = coinValue + "/5";
        cash.text = cashValue.ToString();
        gold.text = goldValue.ToString();
        material.text = materialValue.ToString();
        canons=GameObject.FindObjectsOfType<CanonStatus>();
        Refresh();
        //int test = int.Parse(array["1001"].ToString());
        //Debug.Log(test);\
    }
    void Update()
    {
        if (once)
        {
            springPanel = GameObject.FindObjectOfType<SpringPanel>();
            
            once = false;
        }
        gold.text = goldValue.ToString();
        cash.text = cashValue.ToString();
        material.text = materialValue.ToString();
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
        if (refresh)
        {
            Refresh();
            refresh = false;
        }
        if (canonstat.canonLevel * canonstat.goldPrice > canonstat.ui.goldValue || canonstat.canonLevel * canonstat.materialPrice > canonstat.ui.materialValue||canonstat.canonLevel==canonstat.levelLimit)
        {
            sound.audioClip = null;
        }
        else
        {
            sound.audioClip = PlaySE;
        }
    }
    public void TestBoots()
    {

        Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            canonstat = hit.collider.gameObject.GetComponent<CanonStatus>();
        }
        tmp = GameObject.FindGameObjectWithTag("canon");
        int canonType;
        if (canonstat.canonID != 1001)
            canonType = (canonstat.canonID % 4) + 1;
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
                    tmp = Instantiate(canon2, canonPos.position, canonPos.rotation);
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
                    tmp = Instantiate(canon3, canonPos.position, canonPos.rotation);
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
                    tmp = Instantiate(canon1, canonPos.position, canonPos.rotation);
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
                    tmp = Instantiate(canon1, canonPos.position, canonPos.rotation);
                    canonBool2 = true;
                    canonBool3 = true;
                    canonBool1 = true;
                    canonBool5 = true;
                    canonBool4 = false;
                }
                break;
        }
        canonNameInfo.text = canonstat.canonName;
        canonLevelInfo.text = canonstat.canonLevel.ToString();
        canonHpInfo.text = canonstat.hp.ToString();
        canonDlyInfo.text = canonstat.delay.ToString();
        canonPwInfo.text = canonstat.power.ToString();
        canonHealInfo.text = canonstat.heal.ToString();
        canonScaleInfo.text = canonstat.scale.ToString();

        if (canonstat.canonLevel < canonstat.levelLimit)
        {
            canonHpIncInfo.text = canonstat.nextHp.ToString();
            canonDlyIncInfo.text = canonstat.nextDelay.ToString();
            canonPwIncInfo.text = canonstat.nextPower.ToString();
            canonHealIncInfo.text = canonstat.nextHeal.ToString();
            canonScaleIncInfo.text = canonstat.nextScale.ToString();
            canonSpeedIncInfo.text = canonstat.nextSpeed.ToString();
        }
        else
        {
            canonHpIncInfo.text = "";
            canonDlyIncInfo.text = "";
            canonPwIncInfo.text = "";
            canonHealIncInfo.text = "";
            canonScaleIncInfo.text = "";
            canonSpeedIncInfo.text = "";
        }
    }
    public void UpgradeCanon()
    {
        canonstat.CanonUpgrade();
        canonLevelInfo.text = canonstat.canonLevel.ToString();
        canonHpInfo.text = canonstat.hp.ToString();
        canonDlyInfo.text = canonstat.delay.ToString();
        canonPwInfo.text = canonstat.power.ToString();
        canonHealInfo.text = canonstat.heal.ToString();
        canonScaleInfo.text = canonstat.scale.ToString();
        Refresh();
    }
    public void SelectCanon()
    {
        canonstat.SelectCanon();
    }
    public void QuitInventory()
    {
        SceneManager.LoadScene("Main");
    }
    public void OpenOption()
    {
        OptionPopUp.SetActive(true);
    }
    public void CloseOption()
    {
        OptionPopUp.SetActive(false);
    }
    public void Refresh()
    {
        for (int i = 0; i < canons.Length; i++)
        {
            if (canons[i].isOpened == 1)
                canons[i].transform.FindChild("Disabled").gameObject.SetActive(false);
            if (canons[i].isBuying == 1)
                canons[i].transform.FindChild("Buy The This").gameObject.SetActive(false);
        }
    }
}
