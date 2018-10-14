using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrosshairObject : MonoBehaviour {
    [SerializeField]
    bool isHorizontal,isVertical,isRight, isLeft, isUp, isDown;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float horizontalMoveDistance,verticalMoveDistance;
    Vector3 startPos;
    [SerializeField]
    float moveSpeed;

    // Use this for initialization
    void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (isHorizontal) {
            HorizontalExchengeCheck();
            HorizontalMove();
        }
        if (isVertical) {
            VerticalExchengeCheck();
            VerticalMove();
        }
	}

    void HorizontalMove() {
        if (isRight) {
            rb.velocity = new Vector3(1,0,0) * moveSpeed;
        }
        if (isLeft) {
            rb.velocity = new Vector3(-1, 0, 0) * moveSpeed;
        }
    }

    void VerticalMove() {
        if (isUp) {
            rb.velocity = new Vector3(0, 1, 0) * moveSpeed;
        }
        if(isDown){
            rb.velocity = new Vector3(0, -1, 0) * moveSpeed;
        }
    }

    void HorizontalExchengeCheck() {
        if(startPos.x + horizontalMoveDistance/2 < transform.position.x) {
            isLeft = true;
            isRight = false;
        }
        if (startPos.x - horizontalMoveDistance / 2 > transform.position.x) {
            isLeft = false;
            isRight = true;
        }

    }

    void VerticalExchengeCheck() {
        if(startPos.y + verticalMoveDistance/2 < transform.position.y) {
            isDown = true;
            isUp = false;
        }

        if (startPos.y - verticalMoveDistance / 2 > transform.position.y) {
            isDown = false;
            isUp = true;
        }
    }

}
