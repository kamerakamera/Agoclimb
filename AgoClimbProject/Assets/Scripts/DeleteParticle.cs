using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteParticle : MonoBehaviour {
    float deleteCount = 0;
    [SerializeField]
    float deleteTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        deleteCount += Time.deltaTime;
        if(deleteCount >= deleteTime) {
            Destroy(this.gameObject);
        }
	}
}
