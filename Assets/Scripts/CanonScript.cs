using UnityEngine;
using System.Collections;

public class CanonScript : MonoBehaviour {
    public float delay,rotationZ;
    public float hp;
    public float speed,limit,touchLimit,touchTime, touchTimeLimit,changeStartPosTimeLimit, changeStartPosTime;
    public Vector3 lastPos, startPos, deltaPos, changeStartPos;
    public Transform firePoint;
    public GameObject bomb;
    public float coolTime;
    //public enum CanonBall
    //{
    //    small,
    //    normal,
    //    big,
    //    tooBig
    //}
	// Use this for initialization
	void Start () {
        //StartCoroutine("CanonRotate");
	}
    void Update()
    {
        coolTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            changeStartPos = startPos;
        }
        else if (Input.GetMouseButton(0))
        {
            touchTime += Time.deltaTime;
            changeStartPosTime += Time.deltaTime;
            deltaPos = Input.mousePosition - startPos;
            if (changeStartPosTime > changeStartPosTimeLimit)
            {
                changeStartPos = Input.mousePosition;
                changeStartPosTime = 0;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            lastPos = Input.mousePosition;
            deltaPos = Vector3.zero;
            if (lastPos.x > startPos.x - touchLimit && lastPos.x < startPos.x + touchLimit)
            {
                if(touchTime<touchTimeLimit&&coolTime>delay)
                {
                    int canonType = Random.RandomRange(1, 4);
                    GameObject canonBall;
                    canonBall = Instantiate(bomb,firePoint.position,firePoint.rotation) as GameObject;
                    canonBall.transform.localScale *= canonType;
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
