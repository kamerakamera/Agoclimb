using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreateManeger : MonoBehaviour {
    [SerializeField]
    GameObject ago;
    [SerializeField]
    GameObject[] wallObject = new GameObject[3];
    GameObject[] marshmallowObj, emptySpaceObj;
    [SerializeField]
    GameObject wallPrefab,marshmallowPrefab,emptySpacePrefab;
    [SerializeField]
    ScoreManeger scoreManeger;
    float nextWallPosY,playerStartPosY,wallsize = 10;
    int marshmallowAmount;
    Vector3[] createMarshmallowPos;
    // Use this for initialization
    void Start () {
        //nextWallPosY = wallsize * wallObject.Length;
        marshmallowAmount = 7;
        createMarshmallowPos = new Vector3[marshmallowAmount];

    }
	
	// Update is called once per frame
	void Update () {
		if(ago.transform.position.y >= nextWallPosY - wallsize * 2) {
            CreateWall();
            CreateMarshmallow();
            CreateEmptySpace();
        }
	}

    void StartCreate() {
        for(int i = 0;i < 3; i++) {
            wallObject[i] = Instantiate(wallPrefab, new Vector3(0, nextWallPosY, 0), Quaternion.identity);
            CreateMarshmallow();
            CreateEmptySpace();
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

    void CreateMarshmallow() {
        SetMarshmallowPos();
        for(int i = 0;i < marshmallowAmount; i++) {
            Instantiate(marshmallowPrefab, createMarshmallowPos[i], Quaternion.identity);
        }
    }

    void SetMarshmallowPos() {
        for(int i = 0;i < marshmallowAmount; i++) {
            createMarshmallowPos[i] = new Vector3(Random.Range(-4,4), nextWallPosY - wallsize + Random.Range(wallsize / 2 * -1,wallsize / 2), 0);
        }
    }

    void CreateEmptySpace() {
        Instantiate(emptySpacePrefab, new Vector3(Random.Range(-4, 4), nextWallPosY - wallsize + Random.Range(wallsize / 2 * -1, wallsize / 2), 0), Quaternion.identity);
    }

    public void RetryCreateStage() {
        nextWallPosY = 0;
        marshmallowObj = GameObject.FindGameObjectsWithTag("Marshmallow");
        emptySpaceObj = GameObject.FindGameObjectsWithTag("EmptySpace");
        for (int i = 0;i < 3; i++) {
            Destroy(wallObject[i]);
        }
        foreach(GameObject obj in marshmallowObj) {
            Destroy(obj);
        }
        foreach (GameObject obj in emptySpaceObj) {
            Destroy(obj);
        }

    }

}
