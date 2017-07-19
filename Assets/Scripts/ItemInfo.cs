using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MiniJSON;
using System.IO;

public class ItemInfo : MonoBehaviour {
    public int itemID;
    public int itemValue;
    public int goldPrice, cashPrice, goldPlus, materialPlus, coinPlus;
    public float coinTime;
    public bool isBuyable;
    public string itemName, sprName;
    public ItemInfo item;
    public ShopManager shopManager;
    public UILabel priceLabel;
    Dictionary<string, object> data;
    // Use this for initialization
    void Start() {
        if (itemID != 1)
        {
            if (PlayerPrefs.GetInt(itemID.ToString() + "isOpened") == 1 && PlayerPrefs.GetInt(itemID.ToString() + "isBuying") == 0)
            {
                isBuyable = false;//전자일 때는 닫힘 스프라이트 활성화 후자일 떄는 솔드아웃 스프라이트 활성화
                transform.FindChild("Lock").gameObject.SetActive(false);
                transform.FindChild("SoldOut").gameObject.SetActive(false);
            }
            else if (PlayerPrefs.GetInt(itemID.ToString() + "isOpened") == 1 && PlayerPrefs.GetInt(itemID.ToString() + "isBuying") == 1)
            {
                isBuyable = true;
                transform.FindChild("Lock").gameObject.SetActive(false);
                transform.FindChild("SoldOut").gameObject.SetActive(true);
            }
            else if (PlayerPrefs.GetInt(itemID.ToString() + "isOpened") == 0 && PlayerPrefs.GetInt(itemID.ToString() + "isBuying") == 0)
            {
                transform.FindChild("Lock").gameObject.SetActive(true);
                transform.FindChild("SoldOut").gameObject.SetActive(false);

            }
            sprName = transform.FindChild("ItemSpr").GetComponent<UISprite>().spriteName;
        }
        else
        {
            isBuyable = true;
            transform.FindChild("Lock").gameObject.SetActive(false);
            transform.FindChild("SoldOut").gameObject.SetActive(false);
        }
        shopManager = GameObject.FindObjectOfType<ShopManager>();
        priceLabel = transform.FindChild("PriceLabel").GetComponent<UILabel>();
        if (goldPrice != 0)
            priceLabel.text = goldPrice.ToString();
        else if (cashPrice != 0)
            priceLabel.text = cashPrice.ToString();



    }

    public void SelectThisItem()
    {
        if (isBuyable)
        {
            if (goldPrice != 0)
            {
                shopManager.selectLabel.text = goldPrice.ToString();
                shopManager.selectSpr.spriteName = "status_charactor_0001_Layer-22";
                shopManager.itemSpr.spriteName = transform.FindChild("ItemSpr").GetComponent<UISprite>().spriteName;
                shopManager.itemPrice.text = goldPrice.ToString();
                shopManager.itemName.text = itemName;
                shopManager.itemInfo.text = "";
            }
            if (cashPrice != 0&&itemID==1)
            {
                shopManager.selectLabel.text = cashPrice.ToString();
                shopManager.selectSpr.spriteName = "status_charactor_0004_Layer-25";
                shopManager.itemSpr.spriteName = transform.FindChild("ItemSpr").GetComponent<UISprite>().spriteName;
                shopManager.itemPrice.text = cashPrice.ToString();
                shopManager.itemName.text = itemName;
                shopManager.itemInfo.text = "골드 "+ goldPlus.ToString() + " 와 재료 " + materialPlus.ToString()+"를 구매합니다.";
            }


        }
    }
    public void BuyThisItem()
    {
        if (itemID != 1 && PlayerPrefs.GetInt(itemID.ToString() + "isBuying") == 0)
        {


            if (goldPrice != 0)
            {
                if (goldPrice < shopManager.goldValue)
                {
                    shopManager.goldValue -= goldPrice;
                    if (itemID != 0 && PlayerPrefs.GetInt(itemID.ToString() + "isBuying") == 0)
                    {
                        PlayerPrefs.SetInt(itemID.ToString() + "isBuying", 1);
                        PlayerPrefs.SetInt("gold", shopManager.goldValue);
                        PlayerPrefs.SetInt("cash", shopManager.cashValue);
                        transform.FindChild("SoldOut").gameObject.SetActive(true);

                    }

                }
            }
            else if (cashPrice != 0)
            {
                if (cashPrice < shopManager.cashValue)
                {
                    shopManager.cashValue -= cashPrice;
                    if (itemID != 0 && PlayerPrefs.GetInt(itemID.ToString() + "isBuying") == 0)
                    {
                        PlayerPrefs.SetInt(itemID.ToString() + "isBuying", 1);
                        shopManager.goldValue += goldPlus;
                        shopManager.cashValue += materialPlus;
                        PlayerPrefs.SetInt("gold", shopManager.goldValue);
                        PlayerPrefs.SetInt("cash", shopManager.cashValue);
                        transform.FindChild("SoldOut").gameObject.SetActive(true);
                    }
                }
            }
        }
        else if (itemID == 1)
        {
            if(cashPrice<shopManager.cashValue&&goldPrice<shopManager.goldValue)
            {
                shopManager.cashValue -= cashPrice;
                shopManager.goldValue += goldPlus;
                shopManager.materialValue += materialPlus;
                PlayerPrefs.SetInt("gold", shopManager.goldValue);
                PlayerPrefs.SetInt("cash", shopManager.cashValue);
                PlayerPrefs.SetInt("material", shopManager.materialValue);
            }
        }
    }
    public void RefreshItem()
    {
        if (itemID != 1)
        {
            if (PlayerPrefs.GetInt(itemID.ToString() + "isOpened") == 1 && PlayerPrefs.GetInt(itemID.ToString() + "isBuying") == 0)
            {
                isBuyable = false;//전자일 때는 닫힘 스프라이트 활성화 후자일 떄는 솔드아웃 스프라이트 활성화
                transform.FindChild("Lock").gameObject.SetActive(false);
                transform.FindChild("SoldOut").gameObject.SetActive(false);
            }
            else if (PlayerPrefs.GetInt(itemID.ToString() + "isOpened") == 1 && PlayerPrefs.GetInt(itemID.ToString() + "isBuying") == 1)
            {
                isBuyable = true;
                transform.FindChild("Lock").gameObject.SetActive(false);
                transform.FindChild("SoldOut").gameObject.SetActive(true);
            }
            else if (PlayerPrefs.GetInt(itemID.ToString() + "isOpened") == 0 && PlayerPrefs.GetInt(itemID.ToString() + "isBuying") == 0)
            {
                transform.FindChild("Lock").gameObject.SetActive(true);
                transform.FindChild("SoldOut").gameObject.SetActive(false);
            }
            sprName = transform.FindChild("ItemSpr").GetComponent<UISprite>().spriteName;
        }
        else
        {
            isBuyable = true;
            transform.FindChild("Lock").gameObject.SetActive(false);
            transform.FindChild("SoldOut").gameObject.SetActive(false);
        }
    }

}
