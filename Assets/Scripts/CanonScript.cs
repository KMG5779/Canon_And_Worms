using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class CanonScript : MonoBehaviour {
    public string canonName;
    public float delay, rotationZ;
    public float hp, atk, scale, heal, canonBallspeed;
    public int rarity,canonId;
    public int bombLimit;
    public BombInfo bombLimitInfo;
    public float speed,limit,touchLimit,touchTime, touchTimeLimit,changeStartPosTimeLimit, changeStartPosTime;
    public Vector3 lastPos, startPos, deltaPos, changeStartPos,tempPos;
    public Transform firePoint,start,last;
    public GameObject bomb;
    public GameObject[] bombs;
    public GameObject[] canons;
    public float coolTime;
    public float DragSenseLimit; // 스크롤 뷰 조작과 안 겹치도록 터치 가능 위치의 제한을 두는 변수
    public string JSon;
    public int selectBomb,i;
    public UISprite aim;
    public TextMesh nameText;
    public GameObject effect;
    public AudioSource canonSound;
    //public enum CanonBall
    //{
    //    small,
    //    normal,
    //    big,
    //    tooBig
    //}
    // Use this for initialization
    void Awake () {
        i = 0;
        canonId = PlayerPrefs.GetInt("selectedCanonID");
        if (canonId != 1001)
            i = canonId % 4;
        else
            i = 3;
        canons[i].SetActive(true);
        canonId = PlayerPrefs.GetInt("selectedCanonID");
        hp = PlayerPrefs.GetFloat(canonId.ToString() + "Hp");
        delay = PlayerPrefs.GetFloat(canonId.ToString() + "Delay") / 100;
        atk = PlayerPrefs.GetFloat(canonId.ToString() + "Power");
        scale = PlayerPrefs.GetFloat(canonId.ToString() + "Scale");
        heal = PlayerPrefs.GetFloat(canonId.ToString() + "Heal");
        canonBallspeed = PlayerPrefs.GetFloat(canonId.ToString() + "Speed");
        coolTime = delay;
        canonSound= GetComponent<AudioSource>();
    }
    void Update()
    {
        coolTime += Time.deltaTime;
        aim.fillAmount = coolTime / delay;
        if (Input.mousePosition.y > Screen.height / DragSenseLimit&&Input.mousePosition.y<Screen.height*6/DragSenseLimit&&Input.mousePosition.x>Screen.width/9&&Input.mousePosition.x<8*Screen.width/9)
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
                    if (touchTime < touchTimeLimit && coolTime > delay && bombLimitInfo.bombLimit != 0)
                    {
                        GameObject canonBall;
                        canonSound.Play();
                        canonBall = Instantiate(bomb, firePoint.position, firePoint.rotation) as GameObject;
                        canonBall.GetComponent<CanonBallScript>().transform.localScale *= (1 + scale);
                        canonBall.GetComponent<CanonBallScript>().speed += canonBallspeed;
                        canonBall.GetComponent<CanonBallScript>().heal += heal;
                        canonBall.GetComponent<CanonBallScript>().power += atk;
                        bombLimitInfo.bombLimit--;
                        coolTime = 0;
                        Instantiate(effect, firePoint.position, effect.transform.rotation);
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
            transform.eulerAngles = new Vector3(0, 90, rotationZ);
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
