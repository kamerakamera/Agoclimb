using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgoTip : MonoBehaviour {
    [SerializeField]
    Ago ago;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D col) {
        if (col.collider.tag == "Wall") {
            ago.StuckChin(col.gameObject);
            Debug.Log("stuck");
            
        }
    }
}
