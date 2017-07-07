using UnityEngine;
using System.Collections;

public class WormScript : MonoBehaviour {
    public WormHeadScript head;
    public SphereCollider thisCollider;
    // Use this for initialization
    void Start()
    {
        transform.localScale = head.transform.localScale/10;
    }
    void Update()
    {
        if (head.hp <= 0||head.destroy_Value<=0)
            Destroy(gameObject);
    }

}
