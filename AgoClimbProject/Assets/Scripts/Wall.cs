using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    [SerializeField]
    Transform[] moveObject;
    [SerializeField]
    Rigidbody2D[] moveObjectRb;
    [SerializeField]
    bool[] isRight = new bool[2], isLeft = new bool[2];

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        MoveWall(moveObject, moveObjectRb, 6, 8, "left", 0);
        MoveWall(moveObject, moveObjectRb, -8, -6, "right", 1);
    }

    void MoveWall(Transform[] moveObject, Rigidbody2D[] rigidbody, float limitLeftPosition, float limitRightPosition, string firstDirection, int objectNum) {
        if (limitLeftPosition >= moveObject[objectNum].localPosition.x) {
            isRight[objectNum] = true;
            isLeft[objectNum] = false;
        }
        if (limitRightPosition <= moveObject[objectNum].localPosition.x) {
            isLeft[objectNum] = true;
            isRight[objectNum] = false;
        }
        if (rigidbody[objectNum].velocity == Vector2.zero) {
            if (firstDirection == "right") {
                isRight[objectNum] = true;
                isLeft[objectNum] = false;
            }
            if (firstDirection == "left") {
                isLeft[objectNum] = true;
                isRight[objectNum] = false;
            }
        }

        if (isRight[objectNum] == true) {
            rigidbody[objectNum].velocity = Vector2.right;
        }
        if (isLeft[objectNum] == true) {
            rigidbody[objectNum].velocity = Vector2.left;
        }
    }

}
