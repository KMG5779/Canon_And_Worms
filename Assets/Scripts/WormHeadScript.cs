using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WormHeadScript : MonoBehaviour {
    public List<GameObject> Worms;
    public Vector3[] postions;
    public GameObject Worm;
    public GameObject targetObj;
    public CanonScript canon;
    WormNumManager wormNum;
    UIManager UI;
    public string name;
    public float speed, hp, atackedTime,delay,wormPower,scale;
    public int length,destroy_Value,count;
    public float updateDelay,zLimit,yLimit,yUpLimit, yvalue,zvalue;
    public bool isDamaged;
    float timer,hpMax;
    public AudioSource audio;
    public GameObject effect;
    // Use this for initialization
    void Start()
    {
        UI = GameObject.FindObjectOfType<UIManager>();
        canon = GameObject.FindObjectOfType<CanonScript>();
        gameObject.name = name;
        //초기화
        speed = speed / 10;
        transform.localScale *= scale/100;
        postions = new Vector3[Worms.Count];
        updateDelay = 1/speed;
        wormNum = GameObject.Find("WormNumManager").GetComponent<WormNumManager>();
        //라인렌더러 초기화
        audio = GetComponent<AudioSource>();
        for (int i = 0; i < Worms.Count; i++)
        {
            postions[i] = transform.position;
        }

        hpMax = canon.hp;
        initWorms();
        StartCoroutine(UpdateLine());   //updateDelay주기로 업데이트
    }

    void Update()
    {
        //GetComponent<Rigidbody>().velocity = transform.forward * speed;
        transform.Translate(0, 0, speed * Time.deltaTime);
        //if (transform.rotation.x == 40 || transform.rotation.x == -59)
        //    transform.Rotate(30, 0, 0);
        if (transform.position.z > zLimit)
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimit - zvalue);
        if (transform.position.z < -zLimit)
            transform.position = new Vector3(transform.position.x, transform.position.y, -zLimit + zvalue);
        if (transform.position.y > yUpLimit)
            transform.position = new Vector3(transform.position.x, yUpLimit - yvalue, transform.position.z);
        if (transform.position.y < -yLimit)
            transform.position = new Vector3(transform.position.x, -yLimit + yvalue, transform.position.z);
        if (!isDamaged)
        {
            atackedTime += Time.deltaTime;
            if (atackedTime > delay)
            {
                isDamaged = true;
                atackedTime = 0;
            }
                
        }
        if (destroy_Value <= 0)
        {
            wormNum.count--;
            Destroy(gameObject);
        }
            
            
        if (hp <= 0)
        {
            wormNum.count--;
            UI.score.text = (int.Parse(UI.score.text)+1).ToString();
            Destroy(gameObject);
        }
            
    }

    IEnumerator UpdateLine()
    {
        while (true)
        {
            postions[0] = transform.position;   //현재 자신의 위치를 0번째 postion에 저장

            //나머지 위치를 한칸 씩 밀어냄
            for (int i = length - 1; i > 0; i--)
            {
                postions[i] = postions[i - 1];
            }
            for (int i = length -1; i > 0; i--)
            {
                Worms[i].transform.position = postions[i];
            }
            //pos배열을 line renderer에 적용
            yield return new WaitForSeconds(updateDelay);

            //반복
        }

    }
    //IEnumerator ResizeWorms()
    //{
    //    for(int i=length-1;)
    //    }
    //}


    void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag=="Wall")
        {
            audio.Play();
            DrawLaser(transform.position);
            Instantiate(effect, transform.position, effect.transform.rotation);
           //GetComponent<Rigidbody>().velocity = transform.forward * speed;

        }
        else if(col.transform.tag=="CanonWall")
        {
            audio.Play();
            DrawLaser(transform.position);
            Instantiate(effect, transform.position, effect.transform.rotation);
            //GetComponent<Rigidbody>().velocity = transform.forward * speed;
            destroy_Value--;
            for(int i=0;i<length;i++)
            {
                GameObject tmp = Instantiate(Worm);
                tmp.transform.position = transform.position;
                tmp.transform.localScale = transform.localScale/2;
                tmp.GetComponent<WormScript>().head = GetComponent<WormHeadScript>();
                Worms.Add(tmp);
            }
            length *= 2;
            initWorms();
            canon.hp -= wormPower;
            //Instantiate(prefebs);
            //Worms.Add(prefebs);
            
            //length *= 2;

        }
        //else if(/*col.transform.tag=="Worm"||*/col.transform.tag=="WormHead")
        //{
        //    ////DrawLaser(transform.position);
        //    //GetComponent<Rigidbody>().velocity = transform.forward * speed;
        //}
    }

    public void damage(float damage,float heal)
    {
        if(isDamaged)
        {
            //canon.hp += 10;
            hp -= damage;
            canon.hp += heal;
            if (canon.hp > hpMax)
                canon.hp = hpMax;
            isDamaged = false;
        }
    }
    void DrawLaser(Vector3 startPoint)
    {
        
        RaycastHit hit;
        Vector3 rayDir = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(startPoint, rayDir, out hit, Mathf.Infinity))
        {
            //Debug.Log(hit.transform.name);
            //Debug.Log("Infinity" + Mathf.Infinity);
            //Debug.Log("hit" + hit);
            //Debug.Log("startPoint" + startPoint);
            //Debug.Log("rayDir"+rayDir);
            rayDir = Vector3.Reflect((hit.point - startPoint).normalized, hit.normal);
            if (Physics.Raycast(startPoint, rayDir, out hit, Mathf.Infinity))
            {
                GameObject target = Instantiate(targetObj) as GameObject;
                target.transform.position = hit.point;
                transform.LookAt(target.transform);
            }
           
        }
    }
    public void initWorms()
    {
        postions = new Vector3[Worms.Count];
        for (int i = 0; i < Worms.Count; i++)
        {
            postions[i] = Worms[i].transform.position;
        }
    }
}
