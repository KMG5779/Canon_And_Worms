using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBtn : MonoBehaviour {
    public GameObject obj;
    public SpringPanel springPanel;
    public UIGrid uiGrid;
    public UILabel label1;
    public float pageSize;
    public int limit; 
    public int xPos,pgSize;
    bool once;
    void Start()
    {
        springPanel = GameObject.FindObjectOfType<SpringPanel>();
        limit = uiGrid.GetChildList().Count;
        pgSize = (int)pageSize;
        once = true;
    }
    void Update()
    {
        if(once)
        {
            springPanel = GameObject.FindObjectOfType<SpringPanel>();
            once = false;
        }
        xPos = (int)springPanel.target.x;
        switch(xPos)
        {
            case 0:
                label1.text = "1/7";
                break;
            case -400:
                label1.text = "2/7";
                break;
            case -800:
                label1.text = "3/7";
                break;
            case -1200:
                label1.text = "4/7";
                break;
            case -1600:
                label1.text = "5/7";
                break;
            case -2000:
                label1.text = "6/7";
                break;
            case -2400:
                label1.text = "7/7";
                break;
        }
    }
    public void TestBoots()
    {
        Debug.Log("이건 부츠다!");
    }
    public void TestGrove()
    {
        Debug.Log("이건 장갑이다!");
    }
    public void TestETC()
    {
        Debug.Log("몰라썅");
    }
    public void PressOne()
    {
            springPanel = GameObject.FindObjectOfType<SpringPanel>();
            springPanel.enabled = true;
            springPanel.target.x = 0;
            springPanel.enabled = true;
    }

    public void PressTwo()
    {
            springPanel = GameObject.FindObjectOfType<SpringPanel>();
            springPanel.enabled = true;
            springPanel.target.x = pageSize;
            springPanel.enabled = true;
    }

    public void PressThree()
    {
        springPanel = GameObject.FindObjectOfType<SpringPanel>();
        springPanel.enabled = true;
        springPanel.target.x = pageSize * 2;
        springPanel.enabled = true;
    }

    public void PressFour()
    {
        springPanel = GameObject.FindObjectOfType<SpringPanel>();
        springPanel.enabled = true;
        springPanel.target.x = pageSize * 3;
        springPanel.enabled = true;
    }
    public void PressFive()
    {
        springPanel = GameObject.FindObjectOfType<SpringPanel>();
        springPanel.enabled = true;
        springPanel.target.x = pageSize * 4;
        springPanel.enabled = true;
    }
    public void PressSix()
    {
        springPanel = GameObject.FindObjectOfType<SpringPanel>();
        springPanel.enabled = true;
        springPanel.target.x = pageSize * 5;
        springPanel.enabled = true;
    }
    public void PressSeven()
    {
        springPanel = GameObject.FindObjectOfType<SpringPanel>();
        springPanel.enabled = true;
        springPanel.target.x = pageSize * 6;
        springPanel.enabled = true;
    }
}
