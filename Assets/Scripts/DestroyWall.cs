using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        Debug.Log("빠짐"+col.transform.position);
        col.GetComponent<WormHeadScript>().hp = 0;
    }
}
