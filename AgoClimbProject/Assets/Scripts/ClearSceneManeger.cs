using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSceneManeger : MonoBehaviour {
    [SerializeField]
    GameObject backGroundAgo;
    Color backGroundSpriteColor;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        BackGroundChengeRotation();
	}

    void BackGroundChengeRotation() {
        backGroundAgo.transform.Rotate(0, 0, 45 * Time.deltaTime);
    }
}
