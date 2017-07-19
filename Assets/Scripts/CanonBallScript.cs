using UnityEngine;
using System.Collections;

public class CanonBallScript : MonoBehaviour {
    public float speed;
    public int hp;
    public float heal;
    public float range;
    public float power;
    CanonScript canon;
    WormHeadScript head;
    public UIManager UI;
    public GameObject anim;
    // Use this for initialization
    void Start () {
        //head = GameObject.FindObjectOfType<WormHeadScript>();
        canon = GameObject.FindWithTag("Canon").GetComponent<CanonScript>();
        UI = GameObject.FindWithTag("UI").GetComponent<UIManager>();
        transform.localScale *= range / 100;

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, speed*Time.deltaTime/10, 0);
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
            col.GetComponent<WormScript>().head.damage(power,heal);
            Instantiate(anim, transform.position, anim.transform.rotation);
            
        }
        else if(col.transform.tag == "WormHead")
        {
            if (col.GetComponent<WormHeadScript>().isDamaged)
                hp--;
            col.GetComponent<WormHeadScript>().damage(power,heal);
            Instantiate(anim,transform.position,anim.transform.rotation);
        }
        else if (col.transform.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
