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
    float horizontalMovement, verticalMovement;

    // Use this for initialization
    void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (isHorizontal) {
            HorizontalExchengeCheck();
            HorizontalMoveInput();
        }
        if (isVertical) {
            VerticalExchengeCheck();
            VerticalMoveInput();
        }
        CrosshairMove();
	}

    void HorizontalMoveInput() {
        if (isRight) {
            horizontalMovement = moveSpeed;
        }
        if (isLeft) {
            horizontalMovement = -moveSpeed;
        }
    }

    void VerticalMoveInput() {
        if (isUp) {
            verticalMovement = moveSpeed;
        }
        if(isDown){
            verticalMovement = -moveSpeed;
        }
    }

    void CrosshairMove() {
        rb.velocity = new Vector3(horizontalMovement,verticalMovement,0);
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
