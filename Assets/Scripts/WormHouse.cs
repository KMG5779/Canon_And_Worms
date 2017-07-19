using UnityEngine;
using System.Collections;

public class WormHouse : MonoBehaviour {
    public GameObject wormHead1,wormHead2, wormHead3, wormHead4, wormHead5, wormHead6, wormHead7, wormHead8, wormHead9, wormHead10,tmpHead, tmpWorm,wormBody;
    public GameManager gm;
    public float delay, rotationDelay, wormLimit,worm2Limit,worm3Limit, rotationLimit, rotationY,time,worm4Limit, worm5Limit, worm6Limit, worm7Limit, worm8Limit, worm9Limit, worm10Limit;
    public int rotationX, wormNum,worm2Num,worm3Num,worm4Num, worm5Num, worm6Num, worm7Num, worm8Num, worm9Num, worm10Num, worm11Num;
    public bool createWorm,win;
	// Use this for initialization
	void Start () {
        delay = gm.delay;
        wormLimit = gm.worm1Limit;
        worm2Limit = gm.worm2Limit;
        worm3Limit = gm.worm3Limit;
        worm4Limit = gm.worm4Limit;
        worm5Limit = gm.worm5Limit;
        worm6Limit = gm.worm6Limit;
        worm7Limit = gm.worm7Limit;
        worm8Limit = gm.worm8Limit;
        worm9Limit = gm.worm9Limit;
        win = false;
        StartCoroutine(CreateWorm());
        StartCoroutine(RotateHouse());
    }
	// Update is called once per frame
	public IEnumerator CreateWorm()
    {



        while (!gm.win)
        {
            yield return new WaitForSeconds(delay);
            if(createWorm)
            {
                int tmp=Random.Range(0, 9);
                yield return new WaitForSeconds(delay);
                switch(tmp)
                {
                    case 0:
                        if (gm.worm1Num < wormLimit)
                        {
                            tmpHead = Instantiate(wormHead1) as GameObject;
                            tmpWorm = Instantiate(wormBody) as GameObject;
                            tmpHead.transform.position = transform.position;
                            tmpHead.transform.rotation = transform.rotation;
                            tmpWorm.transform.position = tmpHead.transform.position;
                            tmpWorm.GetComponent<WormScript>().head = tmpHead.GetComponent<WormHeadScript>();
                            tmpHead.GetComponent<WormHeadScript>().Worms.Add(tmpWorm);
                            tmpHead.GetComponent<WormHeadScript>().length++;
                            tmpHead.GetComponent<WormHeadScript>().initWorms();
                            gm.worm1Num++;
                        }
                        break;
                    case 1:
                        if(gm.worm2Num<worm2Limit)
                        {
                            tmpHead = Instantiate(wormHead2) as GameObject;
                            tmpWorm = Instantiate(wormBody) as GameObject;
                            tmpHead.transform.position = transform.position;
                            tmpHead.transform.rotation = transform.rotation;
                            tmpWorm.transform.position = tmpHead.transform.position;
                            tmpWorm.GetComponent<WormScript>().head = tmpHead.GetComponent<WormHeadScript>();
                            tmpHead.GetComponent<WormHeadScript>().Worms.Add(tmpWorm);
                            tmpHead.GetComponent<WormHeadScript>().length++;
                            tmpHead.GetComponent<WormHeadScript>().initWorms();
                            gm.worm2Num++;
                        }
                        break;
                    case 2:
                        if (gm.worm3Num < worm3Limit)
                        {
                            tmpHead = Instantiate(wormHead3) as GameObject;
                            tmpWorm = Instantiate(wormBody) as GameObject;
                            tmpHead.transform.position = transform.position;
                            tmpHead.transform.rotation = transform.rotation;
                            tmpWorm.transform.position = tmpHead.transform.position;
                            tmpWorm.GetComponent<WormScript>().head = tmpHead.GetComponent<WormHeadScript>();
                            tmpHead.GetComponent<WormHeadScript>().Worms.Add(tmpWorm);
                            tmpHead.GetComponent<WormHeadScript>().length++;
                            tmpHead.GetComponent<WormHeadScript>().initWorms();
                            gm.worm3Num++;
                        }
                        break;
                    case 3:
                        if (gm.worm4Num < worm4Limit)
                        {
                            tmpHead = Instantiate(wormHead4) as GameObject;
                            tmpWorm = Instantiate(wormBody) as GameObject;
                            tmpHead.transform.position = transform.position;
                            tmpHead.transform.rotation = transform.rotation;
                            tmpWorm.transform.position = tmpHead.transform.position;
                            tmpWorm.GetComponent<WormScript>().head = tmpHead.GetComponent<WormHeadScript>();
                            tmpHead.GetComponent<WormHeadScript>().Worms.Add(tmpWorm);
                            tmpHead.GetComponent<WormHeadScript>().length++;
                            tmpHead.GetComponent<WormHeadScript>().initWorms();
                            gm.worm4Num++;
                        }
                        break;
                    case 4:
                        if (gm.worm5Num < worm5Limit)
                        {
                            tmpHead = Instantiate(wormHead5) as GameObject;
                            tmpWorm = Instantiate(wormBody) as GameObject;
                            tmpHead.transform.position = transform.position;
                            tmpHead.transform.rotation = transform.rotation;
                            tmpWorm.transform.position = tmpHead.transform.position;
                            tmpWorm.GetComponent<WormScript>().head = tmpHead.GetComponent<WormHeadScript>();
                            tmpHead.GetComponent<WormHeadScript>().Worms.Add(tmpWorm);
                            tmpHead.GetComponent<WormHeadScript>().length++;
                            tmpHead.GetComponent<WormHeadScript>().initWorms();
                            gm.worm5Num++;
                        }
                        break;
                    case 5:
                        if (gm.worm6Num < worm6Limit)
                        {
                            tmpHead = Instantiate(wormHead6) as GameObject;
                            tmpWorm = Instantiate(wormBody) as GameObject;
                            tmpHead.transform.position = transform.position;
                            tmpHead.transform.rotation = transform.rotation;
                            tmpWorm.transform.position = tmpHead.transform.position;
                            tmpWorm.GetComponent<WormScript>().head = tmpHead.GetComponent<WormHeadScript>();
                            tmpHead.GetComponent<WormHeadScript>().Worms.Add(tmpWorm);
                            tmpHead.GetComponent<WormHeadScript>().length++;
                            tmpHead.GetComponent<WormHeadScript>().initWorms();
                            gm.worm6Num++;
                        }
                        break;
                    case 6:
                        if (gm.worm7Num < worm7Limit)
                        {
                            tmpHead = Instantiate(wormHead7) as GameObject;
                            tmpWorm = Instantiate(wormBody) as GameObject;
                            tmpHead.transform.position = transform.position;
                            tmpHead.transform.rotation = transform.rotation;
                            tmpWorm.transform.position = tmpHead.transform.position;
                            tmpWorm.GetComponent<WormScript>().head = tmpHead.GetComponent<WormHeadScript>();
                            tmpHead.GetComponent<WormHeadScript>().Worms.Add(tmpWorm);
                            tmpHead.GetComponent<WormHeadScript>().length++;
                            tmpHead.GetComponent<WormHeadScript>().initWorms();
                            gm.worm7Num++;
                        }
                        break;
                    case 7:
                        if (gm.worm8Num < worm8Limit)
                        {
                            tmpHead = Instantiate(wormHead8) as GameObject;
                            tmpWorm = Instantiate(wormBody) as GameObject;
                            tmpHead.transform.position = transform.position;
                            tmpHead.transform.rotation = transform.rotation;
                            tmpWorm.transform.position = tmpHead.transform.position;
                            tmpWorm.GetComponent<WormScript>().head = tmpHead.GetComponent<WormHeadScript>();
                            tmpHead.GetComponent<WormHeadScript>().Worms.Add(tmpWorm);
                            tmpHead.GetComponent<WormHeadScript>().length++;
                            tmpHead.GetComponent<WormHeadScript>().initWorms();
                            gm.worm8Num++;
                        }
                        break;
                    case 8:
                        if (gm.worm9Num < worm9Limit)
                        {
                            tmpHead = Instantiate(wormHead9) as GameObject;
                            tmpWorm = Instantiate(wormBody) as GameObject;
                            tmpHead.transform.position = transform.position;
                            tmpHead.transform.rotation = transform.rotation;
                            tmpWorm.transform.position = tmpHead.transform.position;
                            tmpWorm.GetComponent<WormScript>().head = tmpHead.GetComponent<WormHeadScript>();
                            tmpHead.GetComponent<WormHeadScript>().Worms.Add(tmpWorm);
                            tmpHead.GetComponent<WormHeadScript>().length++;
                            tmpHead.GetComponent<WormHeadScript>().initWorms();
                            gm.worm9Num++;
                        }
                        break;
                        //case 3:
                        //    tmpHead = Instantiate(wormHead) as GameObject;
                        //    tmpWorm = Instantiate(worm) as GameObject;
                        //    tmpHead.transform.position = transform.position;
                        //    tmpHead.transform.rotation = transform.rotation;
                        //    tmpWorm.transform.position = tmpHead.transform.position;
                        //    tmpWorm.GetComponent<WormScript>().head = tmpHead.GetComponent<WormHeadScript>();
                        //    tmpHead.GetComponent<WormHeadScript>().Worms.Add(tmpWorm);
                        //    tmpHead.GetComponent<WormHeadScript>().length++;
                        //    tmpHead.GetComponent<WormHeadScript>().initWorms();
                        //    wormNum++;
                        //    break;
                        yield return new WaitForSeconds(delay);
                }
                
                if (gm.worm1Num >= wormLimit&&gm.worm2Num >=worm2Limit&& gm.worm3Num >=worm3Limit&& gm.worm4Num >= worm4Limit && gm.worm5Num >= worm5Limit && gm.worm6Num >= worm6Limit&& gm.worm7Num >= worm7Limit && gm.worm8Num >= worm8Limit && gm.worm9Num >= worm9Limit)
                {
                    win = true;
                }
                yield return new WaitForSeconds(delay);
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }
        }
        
        
         
    }
    public IEnumerator RotateHouse()
    {
        while(!gm.win)
        {
            rotationX = Random.Range(1, 4);
            transform.rotation = Quaternion.Euler(rotationX * 35f, rotationY, 0);
            yield return new WaitForSeconds(rotationDelay);
        }
            
    }
}
