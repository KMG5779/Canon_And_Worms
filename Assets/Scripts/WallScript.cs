using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

	void OnCollisionStay(Collision col)
    {
        col.transform.Rotate(30, 0, 0);
    }
}
