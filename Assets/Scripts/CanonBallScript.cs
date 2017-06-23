using UnityEngine;
using System.Collections;

public class CanonBallScript : MonoBehaviour {
    public float speed;
    public int hp;
    public float range;
    public float Damage;
    CanonScript canon;
    WormHeadScript head;
	// Use this for initialization
	void Start () {
        GetComponent<SphereCollider>().radius = range;
        //head = GameObject.FindObjectOfType<WormHeadScript>();
        canon = GameObject.Find("Canon").GetComponent<CanonScript>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, speed*Time.deltaTime, 0);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Worm")
        {
            if (col.GetComponent<WormScript>().head.isDamaged)
                hp--;
            col.GetComponent<WormScript>().head.damage(Damage);
        }
        else if(col.transform.tag == "WormHead")
        {
            if (col.GetComponent<WormHeadScript>().isDamaged)
                hp--;
            col.GetComponent<WormHeadScript>().damage(Damage);
        }
        else if (col.transform.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
