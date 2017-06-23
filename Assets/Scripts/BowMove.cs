using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMove : MonoBehaviour
{

    //public float rotationX;
    //public float rotationY;
    public GameObject bowObj;

    public Transform bow;       //=bowObj

    public float rotateSpeed;
    public float rotationZ;
    public float bowAngle;
    public float bowAngleLimit;
    public float touchSupport;
    public float testrotateSpeed;
    public int count;
    public Vector2 firstTouchPosition, movePos, range;
    public bool moveStart; //드레그와 터치 구분

    // Use this for initialization
    void Start()
    {
        moveStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        //print("qart : " + bowObj.transform.rotation);
        count = Input.touchCount;
        if (moveStart == true)
        {
            if (count > 0) //터치 컨트롤 터치영역 테스트 
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    firstTouchPosition = Input.GetTouch(0).position;//첫번째 터치위치 변수화
                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    movePos = Input.GetTouch(0).position;
                    if (firstTouchPosition.x - movePos.x > 0.5)
                    {
                        bow.Rotate(0, 0, rotateSpeed);  //transform으로 터치시 회전값을 적용
                        if (bowObj.transform.rotation.z > bowAngle)
                        {
                            bowObj.transform.rotation = Quaternion.Euler(0, 0, bowAngleLimit);
                        }
                    }
                    else if (firstTouchPosition.x - movePos.x < -0.5)
                    {
                        bow.Rotate(0, 0, -rotateSpeed);
                        if (bowObj.transform.rotation.z < -bowAngle)
                        {
                            bowObj.transform.rotation = Quaternion.Euler(0, 0, -bowAngleLimit);
                        }
                    }
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    if (firstTouchPosition == Input.GetTouch(0).position || (Input.GetTouch(0).position.x < firstTouchPosition.x + touchSupport && Input.GetTouch(0).position.x > firstTouchPosition.x - touchSupport)) //터치 컨트롤 테스트
                    {
                        count = 0;
                    }
                }
            }
        }
        float mouseMoveValueZ = Input.GetAxis("Mouse X");//유니티 확인용 컨트롤러
        rotationZ += mouseMoveValueZ * testrotateSpeed * Time.deltaTime;
        if (rotationZ > bowAngleLimit)
        {
            rotationZ = bowAngleLimit;
        }
        if (rotationZ < -bowAngleLimit)
        {
            rotationZ = -bowAngleLimit;
        }
        transform.eulerAngles = new Vector3(0, 0, -rotationZ);//로테이션 값을 받아서 오브젝트를 회전_컨트롤러 끝
    }

    //float mouseMoveValueX = Input.GetAxis("Mouse X");
    //float mouseMoveValueY = Input.GetAxis("Mouse Y");
    //rotationX += mouseMoveValueY * sensitivity * Time.deltaTime; //y축을 기준으로 돌리기 때문에 x값이 움직이게 된다
    //rotationY += mouseMoveValueX * sensitivity * Time.deltaTime; //x축을 기준으로 돌리기 때문에 y값이 움직이게 된다

    //if (rotationX > 20.0f)
    //{
    //    rotationX = 20.0f;
    //}
    //if (rotationX < -30.0f)
    //{
    //    rotationX = -30.0f;
    //}
    //if (rotationY > 175.0f)
    //{
    //    rotationY = 175.0f;
    //}
    //if (rotationY < -175.0f)
    //{
    //    rotationY = -175.0f;
    //}

}

