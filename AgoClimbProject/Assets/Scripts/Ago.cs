using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ago : MonoBehaviour {
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private ArrowManeger arrowManeger;
    private float fireRotationZ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Fire();
        }
	}

    void Fire() {
        Debug.Log(arrowManeger.GetFireRotation().eulerAngles + new Vector3(0,0,180));
        transform.rotation = Quaternion.Euler(arrowManeger.GetFireRotation().eulerAngles + new Vector3(0, 0, 180));
        rb.velocity = transform.up * -1 * arrowManeger.GetFirePower();
        //transform.rotation = 

        //rb.velocity = arrowManeger.GetShotPower()  * arrowManeger.GetArrowRotation().eulerAngles;
        //rb.velocity = Vector2.up * 6.65f;
    }

    public void Stop() {
        rb.velocity = Vector3.zero;
    }

}
