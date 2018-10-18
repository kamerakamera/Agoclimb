using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour {
    float surviveTime = 3,countTime;
    //衝突で消滅した方がよさそう
	// Use this for initialization
	void Start () {
        countTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        DeleteCount();
	}

    void DeleteCount() {
        countTime += Time.deltaTime;
        if(countTime >= surviveTime) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != "Player" && other.tag != "Tree") {
            Destroy(this.gameObject);
        }
    }

}
