using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreateManeger : MonoBehaviour {
    [SerializeField]
    GameObject ago;
    [SerializeField]
    GameObject[] wallObject = new GameObject[3];
    [SerializeField]
    GameObject wallPrefab;
    float nextWallPosY,playerStartPosY,wallsize = 10;
    // Use this for initialization
    void Start () {
        nextWallPosY = wallsize * wallObject.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if(ago.transform.position.y >= nextWallPosY - wallsize * 2) {
            CreateWall();
        }
	}

    void CreateWall() {
        DeleteWall();
        SetWallRist();
        UpdateNextWallPos();
    }

    void UpdateNextWallPos() {
        nextWallPosY += wallsize;
    }

    void SetWallRist() {
        for(int i = 0;i < 3; i++) {
            if(i < 2) {
                wallObject[i] = wallObject[i + 1];
            } else {
                wallObject[2] = Instantiate(wallPrefab, new Vector3(0, nextWallPosY, 0), Quaternion.identity);
            }
        }
    }

    void DeleteWall() {
        Destroy(wallObject[0]);
    }

    public void RetryCreateWall() {
        nextWallPosY = 0;
        for(int i = 0;i < 3; i++) {
            Destroy(wallObject[i]);
            wallObject[i] = Instantiate(wallPrefab, new Vector3(0, nextWallPosY, 0),Quaternion.identity);
            UpdateNextWallPos();
        }
    }

}
