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

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Wall") {
            ago.Stop();
        }
    }
}
