using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingTrigger : MonoBehaviour {
    [SerializeField]
    PassingThroughObject passingThroughObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            passingThroughObject.SetIsMove(true);
        }
    }

}
