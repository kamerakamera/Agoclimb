using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ago : MonoBehaviour {
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private ArrowManeger arrowManeger;
    [SerializeField]
    GameStateManeger gameStateManeger;
    private float fireRotationZ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Fire() {
        transform.rotation = Quaternion.Euler(arrowManeger.GetFireRotation().eulerAngles + new Vector3(0, 0, 180));
        rb.velocity = transform.up * -1 * arrowManeger.GetFirePower();
    }

    public void StuckChin(GameObject stuckObject) {
        rb.velocity = stuckObject.GetComponent<Rigidbody2D>().velocity;
        gameStateManeger.StateChange(0);
    }
}
