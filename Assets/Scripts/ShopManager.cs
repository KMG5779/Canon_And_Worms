using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using System.IO;
using UnityEngine.SceneManagement;
public class ShopManager : MonoBehaviour {
    public UISprite priceSpr,selectSpr,itemSpr,itemPriceSpr;
    public UILabel priceValue,selectLabel,itemPrice,itemInfo,itemName;
    public UILabel coin, gold, cash, material;
    public string userData;
    public int id,coinValue,goldValue,cashValue,materialValue;
    public Dictionary<string, object> userInfoData;
    public ItemInfo item;
    public GameObject questionBuy,sale;
    // Use this for initialization
    void Start () {
        coinValue = PlayerPrefs.GetInt("coin", 5);
        cashValue = PlayerPrefs.GetInt("cash", 0);
        goldValue = PlayerPrefs.GetInt("gold", 0);
        materialValue = PlayerPrefs.GetInt("material", 0);
    }
	
	// Update is called once per frame
	void Update () {
        coin.text = coinValue.ToString()+"/5";
        gold.text = goldValue.ToString();
        cash.text = cashValue.ToString();
        material.text = materialValue.ToString();
	}

    public void SelectItem()
    {
        Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            item = hit.collider.gameObject.GetComponent<ItemInfo>();
        }
        itemSpr.spriteName = item.sprName;
        item.SelectThisItem();
    }
    public void BuyItem()
    {
        if(item)
            item.BuyThisItem();
        RefreshItem();
        CloseQuestion();
       
    }
    public void BackBtn()
    {
        SceneManager.LoadScene("Main");
    }
    public void QuestionThisBuy()
    {
        if (item.cashPrice != 0)
        {
            sale.transform.FindChild("PriceLabel").GetComponent<UILabel>().text = item.cashPrice.ToString();
            sale.transform.FindChild("sample_Spr").GetComponent<UISprite>().spriteName = "status_charactor_0004_Layer-25";
            sale.transform.FindChild("LeftPanel").transform.FindChild("sample_Spr").GetComponent<UISprite>().spriteName = item.transform.FindChild("ItemSpr").GetComponent<UISprite>().spriteName;
            sale.transform.FindChild("RightPanel").transform.FindChild("ItemName_Label").GetComponent<UILabel>().text = item.itemName;
            sale.transform.FindChild("RightPanel").transform.FindChild("ItemIntro_Label").GetComponent<UILabel>().text = "골드 " + item.goldPlus + " + "+"재료 "+item.materialPlus + "를 구매합니다.";
        }
        if (item.goldPrice != 0)
        {
            sale.transform.FindChild("PriceLabel").GetComponent<UILabel>().text = item.goldPrice.ToString();
            sale.transform.FindChild("sample_Spr").GetComponent<UISprite>().spriteName = "status_charactor_0004_Layer-22";
            sale.transform.FindChild("LeftPanel").transform.FindChild("sample_Spr").GetComponent<UISprite>().spriteName = item.transform.FindChild("ItemSpr").GetComponent<UISprite>().spriteName;
            sale.transform.FindChild("RightPanel").GetComponentInChildren<UILabel>().text = item.itemName;
        }
        sale.transform.FindChild("NameLabel").GetComponent<UILabel>().text = item.itemName;
        //questionBuy.transform.FindChild("")
        questionBuy.SetActive(true);
    }
    public void CloseQuestion()
    {
        questionBuy.GetComponentInChildren<TweenScale>().PlayReverse();
        questionBuy.SetActive(false);
    }
    public void RefreshItem()
    {
        ItemInfo[] items;
        items=GameObject.FindObjectsOfType<ItemInfo>();
        for(int i=0;i<items.Length;i++)
        {
            items[i].RefreshItem();
        }
    }
}
