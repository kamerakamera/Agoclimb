using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManeger : MonoBehaviour {
    [SerializeField]
    GameObject ago;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, ago.transform.position.y, transform.position.z);
        if(SceneManager.GetActiveScene().name != "Infinitemode") {
            transform.position = new Vector3(ago.transform.position.x, ago.transform.position.y, transform.position.z);
        }
	}
}
