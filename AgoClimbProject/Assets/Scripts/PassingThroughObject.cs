using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingThroughObject : MonoBehaviour {

    bool isMove;
    [SerializeField]
    float limitTime;
    float timeCount;
	// Use this for initialization
	void Start () {
        timeCount = 0;
        isMove = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isMove) {
            MoveToRight();
            CountTime();
        }
	}

    void MoveToRight() {
        transform.position += new Vector3(0.1f, 0, 0);
    }

    void CountTime() {
        timeCount += Time.deltaTime;
        if(timeCount >= limitTime) {
            DeleteObject();
            timeCount = 0;
        }
    }

    void DeleteObject() {
        Destroy(gameObject);
    }

}
