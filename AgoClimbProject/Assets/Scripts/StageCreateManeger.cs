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
        CreateWall();
	}
	
	// Update is called once per frame
	void Update () {
        //Createを呼ぶタイミング頑張って
		if(ago.transform.position.y >= nextWallPosY) {
            CreateWall();
        }
	}

    void CreateWall() {
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
            }
            wallObject[2] = Instantiate(wallPrefab, new Vector3(0, nextWallPosY, 0), Quaternion.identity);
        }
    }

}
