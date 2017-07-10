using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class CanonScript : MonoBehaviour {
    public string canonName;
    public float delay, rotationZ;
    public float hp, atk, scale, heal, canonBallspeed;
    public int rarity;
    public int bombLimit;
    public int[] bombsLimit;
    public float speed,limit,touchLimit,touchTime, touchTimeLimit,changeStartPosTimeLimit, changeStartPosTime;
    public Vector3 lastPos, startPos, deltaPos, changeStartPos,tempPos;
    public Transform firePoint,start,last;
    public GameObject bomb;
    public GameObject[] bombs;
    public float coolTime;
    public float DragSenseLimit; // 스크롤 뷰 조작과 안 겹치도록 터치 가능 위치의 제한을 두는 변수
    public GameManager gm;
    public string JSon;
    public int selectBomb;
    //public enum CanonBall
    //{
    //    small,
    //    normal,
    //    big,
    //    tooBig
    //}
    // Use this for initialization
    void Start () {
        TextAsset data = Resources.Load("selectedCanonInfo") as TextAsset;
        JSon = data.text;
        Dictionary<string, object> canonData;
        canonData = Json.Deserialize(JSon) as Dictionary<string, object>;
        canonName = canonData["CanonName"].ToString();
        hp = float.Parse(canonData["CanonHp"].ToString());
        delay = float.Parse(canonData["CanonDelay"].ToString())/100;
        atk = float.Parse(canonData["CanonPower"].ToString())/100;
        scale = float.Parse(canonData["CanonScale"].ToString())/100;
        heal = float.Parse(canonData["CanonHeal"].ToString())/100;
        canonBallspeed = float.Parse(canonData["CanonSpeed"].ToString());
        coolTime = delay;
    }
    void Update()
    {
        coolTime += Time.deltaTime;
        if (Input.mousePosition.y > Screen.height / DragSenseLimit)
        {


            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
                //start.position = new Vector3(0,Input.mousePosition.y,Input.mousePosition.z);
                //last.position = new Vector3(0, Input.mousePosition.y, Input.mousePosition.z);
                //changeStartPos = startPos;
            }
            else if (Input.GetMouseButton(0))
            {
                touchTime += Time.deltaTime;
                changeStartPosTime += Time.deltaTime;
                deltaPos = Input.mousePosition - startPos;
                deltaPos.Normalize();
                //last.position = Input.mousePosition;
                //if (last.position.z > start.position.z + 0.5f)
                //    last.position = new Vector3(last.position.x, last.position.y, start.position.z + 0.5f);
                //if (last.position.z < start.position.z - 0.5f)
                //    last.position = new Vector3(last.position.x, last.position.y, start.position.z - 0.5f);
            }

            else if (Input.GetMouseButtonUp(0))
            {
                lastPos = Input.mousePosition;
                deltaPos = Vector3.zero;
                if (lastPos.x > startPos.x - touchLimit && lastPos.x < startPos.x + touchLimit)
                {
                    if (touchTime < touchTimeLimit && coolTime > delay && bombLimit != 0)
                    {
                        int canonType = Random.Range(1, 4);
                        GameObject canonBall;
                        canonBall = Instantiate(bombs[selectBomb], firePoint.position, firePoint.rotation) as GameObject;
                        canonBall.GetComponent<CanonBallScript>().transform.localScale *= (1 + scale);
                        canonBall.GetComponent<CanonBallScript>().speed += canonBallspeed;
                        canonBall.GetComponent<CanonBallScript>().heal += heal;
                        canonBall.GetComponent<CanonBallScript>().power += atk;
                        bombsLimit[selectBomb]--;
                        coolTime = 0;
                    }

                }
                touchTime = 0;
            }
            rotationZ += deltaPos.x * Time.deltaTime * speed;
            if (rotationZ > limit)
            {
                rotationZ = limit;
            }
            if (rotationZ < -limit)
            {
                rotationZ = -limit;
            }
            transform.eulerAngles = new Vector3(rotationZ, 0, 0);
        }
    }
	
	// Update is called once per frame
    //IEnumerator CanonRotate()
    //{
    //    float pointer_x = Input.GetAxis("Mouse X");
    //    if(Input.
    //        pointer_x = Input.mousePosition.x;
    //        transform.Rotate(pointer_x*Time.deltaTime, 0, 0);
        
    //    yield return new WaitForSeconds(0.1f);
    //}
}
