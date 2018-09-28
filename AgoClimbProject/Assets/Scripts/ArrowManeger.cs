using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManeger : MonoBehaviour {
    Vector3 agoPos;
    Quaternion shotRotation;
    float shotPower,powerChengeAmount = 10,maxPower = 10,minPower = 1; 
    [SerializeField]
    Transform ago;
    [SerializeField]
    GameObject arrowObject;
    bool isDownPower, isUpPower;
    // Use this for initialization
    void Start () {
        shotPower = 1;
        SetArrowSize();
        isUpPower = true;
	}
	
	// Update is called once per frame
	void Update () {
        LookDirection();
	}

    void FixedUpdate() {
        SetArrowSize();
        SetPower();
    }

    public void AgoTracking() {
        transform.position = ago.position;
    }

    public void ArrowDisplayChenge(bool _bool) {
        arrowObject.SetActive(_bool);
    }

    void LookDirection() {
        agoPos = Camera.main.WorldToScreenPoint(transform.localPosition);
        shotRotation = Quaternion.LookRotation(Vector3.forward,Input.mousePosition - agoPos);
        transform.rotation = shotRotation;
    }

    void SetArrowSize() {
        arrowObject.transform.localScale = new Vector3(1, shotPower, 1);
    }

    void SetPower() {

        if(isUpPower == true) {
            shotPower += powerChengeAmount * Time.fixedDeltaTime;
            if(shotPower >= maxPower) {
                isUpPower = false;
                isDownPower = true; 
            }
        }

        if(isDownPower == true) {
            shotPower -= powerChengeAmount * Time.fixedDeltaTime;
            if (shotPower <= minPower) {
                isUpPower = true;
                isDownPower = false;
            }
        }
        //powerを返す
    }

    public Quaternion GetFireRotation() {
        return transform.rotation;
    }

    public float GetFirePower() {
        return shotPower;
    }

}
