using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCanonBallInfo : MonoBehaviour {
    public BombInfo bombInfo;
    public CanonScript canon;
    RaycastHit hit;
    // Use this for initialization
    void Start () {
        canon = GameObject.FindObjectOfType<CanonScript>();
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);


        if (Physics.Raycast(transform.position, fwd, out hit, 10f))
        {
            bombInfo = hit.collider.gameObject.GetComponent<BombInfo>();
        }
        canon.bombLimitInfo=bombInfo;
        canon.bomb = bombInfo.bomb;
        

    }
}
