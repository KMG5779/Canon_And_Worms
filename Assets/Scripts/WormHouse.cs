using UnityEngine;
using System.Collections;

public class WormHouse : MonoBehaviour {
    public GameObject wormHead,worm,wormHead2,worm2,wormHead3,worm3,tmpHead,tmpWorm;
    public GameManager gm;
    public float delay, rotationDelay, wormLimit,worm2Limit,worm3Limit, rotationLimit, rotationY,time;
    public int rotationX, wormNum,worm2Num,worm3Num;
    public bool createWorm,win;
	// Use this for initialization
	void Start () {
        //transform.position = gm.wormHousePos[gm.stageNum];
        delay = gm.delay[gm.stageNum];
        wormLimit = gm.wormLimit[gm.stageNum];
        worm2Limit = gm.worm2Limit[gm.stageNum];
        worm3Limit = gm.worm3Limit[gm.stageNum];
        StartCoroutine(CreateWorm());
        StartCoroutine(RotateHouse());
    }
	// Update is called once per frame
	public IEnumerator CreateWorm()
    {



        while (wormNum < wormLimit/*||worm2Num<worm2Limit||worm3Num<worm3Limit*/)
        {
            yield return new WaitForSeconds(delay);
            if(createWorm)
            {
                int tmp=Random.Range(0, 3);
                switch(tmp)
                {
                    case 0:
                        if(wormNum<wormLimit)
                        {
                            tmpHead = Instantiate(wormHead) as GameObject;
                            tmpWorm = Instantiate(worm) as GameObject;
                            tmpHead.transform.position = transform.position;
                            tmpHead.transform.rotation = transform.rotation;
                            tmpWorm.transform.position = tmpHead.transform.position;
                            tmpWorm.GetComponent<WormScript>().head = tmpHead.GetComponent<WormHeadScript>();
                            tmpHead.GetComponent<WormHeadScript>().Worms.Add(tmpWorm);
                            tmpHead.GetComponent<WormHeadScript>().length++;
                            tmpHead.GetComponent<WormHeadScript>().initWorms();
                            wormNum++;
                        }
                        break;
                    case 1:
                        if (worm2Num < worm2Limit)
                        {
                            tmpHead = Instantiate(wormHead2) as GameObject;
                            tmpWorm = Instantiate(worm) as GameObject;
                            tmpHead.transform.position = transform.position;
                            tmpHead.transform.rotation = transform.rotation;
                            tmpWorm.transform.position = tmpHead.transform.position;
                            tmpWorm.GetComponent<WormScript>().head = tmpHead.GetComponent<WormHeadScript>();
                            tmpHead.GetComponent<WormHeadScript>().Worms.Add(tmpWorm);
                            tmpHead.GetComponent<WormHeadScript>().length++;
                            tmpHead.GetComponent<WormHeadScript>().initWorms();
                            worm2Num++;
                        }
                        break;
                    case 2:
                        if (worm3Num < worm3Limit)
                        {
                            tmpHead = Instantiate(wormHead3) as GameObject;
                            tmpWorm = Instantiate(worm) as GameObject;
                            tmpHead.transform.position = transform.position;
                            tmpHead.transform.rotation = transform.rotation;
                            tmpWorm.transform.position = tmpHead.transform.position;
                            tmpWorm.GetComponent<WormScript>().head = tmpHead.GetComponent<WormHeadScript>();
                            tmpHead.GetComponent<WormHeadScript>().Worms.Add(tmpWorm);
                            tmpHead.GetComponent<WormHeadScript>().length++;
                            tmpHead.GetComponent<WormHeadScript>().initWorms();
                            worm3Num++;
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
                }
                
                if (wormNum >= wormLimit&&worm2Num >=worm2Limit&&worm3Num>=worm3Limit)
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
        while(wormNum < wormLimit&&worm2Num<worm2Limit&&worm3Num<worm3Limit)
        {
            rotationX = Random.Range(1, 4);
            transform.rotation = Quaternion.Euler(rotationX * 35f, rotationY, 0);
            yield return new WaitForSeconds(rotationDelay);
        }
            
    }
}
