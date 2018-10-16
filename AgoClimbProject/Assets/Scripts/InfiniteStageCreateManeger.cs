using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteStageCreateManeger : MonoBehaviour {
    [SerializeField]
    GameObject ago;
    [SerializeField]
    GameObject[] wallObject = new GameObject[3];
    GameObject[] marshmallowObj, emptySpaceObj,treeObj,passingEmptySpaceObj;
    [SerializeField]
    GameObject wallPrefab,marshmallowPrefab,emptySpacePrefab, treeObjPrefab, passingEmptySpaceObjPrefab;
    [SerializeField]
    ScoreManeger scoreManeger;
    float nextWallPosY,playerStartPosY,wallsize = 10,wallInterval = 3.0f,createInterval = 3.2f,gameLevel;
    List<Vector3> alreadyCreatePos = new List<Vector3>();
    int marshmallowAmount,emptySpaceAmount;
    bool setPos;
    Vector3[] createMarshmallowPos,createEmptySpacePos;
    // Use this for initialization
    void Start () {
        gameLevel = 0;
        marshmallowAmount = 3;
        emptySpaceAmount = 1;
        createMarshmallowPos = new Vector3[marshmallowAmount];
        createEmptySpacePos = new Vector3[emptySpaceAmount + 10];
        alreadyCreatePos.Add(ago.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
		if(ago.transform.position.y >= nextWallPosY - wallsize * 2) {
            CreateWall();
            CreateMarshmallow();
            CreateEmptySpace();
            DeleteAlreadyCreatePosList();
            GameDifficulty();
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
            do {
                createMarshmallowPos[i] = new Vector3(Random.Range(-1 * wallInterval, wallInterval), nextWallPosY - wallsize + Random.Range(wallsize / 2 * -1, wallsize / 2), 0);
                setPos = false;
                foreach (Vector3 alreadyPos in alreadyCreatePos) {
                    if (alreadyPos != null) {
                        if ((alreadyPos.x - createInterval / 2 < createMarshmallowPos[i].x && alreadyPos.y - createInterval / 2 < createMarshmallowPos[i].y) && (alreadyPos.y + createInterval / 2 > createMarshmallowPos[i].y && alreadyPos.y + createInterval / 2 > createMarshmallowPos[i].y)) {
                            setPos = true;
                            break;
                        }
                    }
                }
                if (!setPos) {
                    alreadyCreatePos.Add(createMarshmallowPos[i]);
                }
            }
            while (setPos);
        }
    }

    void CreateEmptySpace() {
        SetEmptySpacePos();
        for (int i = 0; i < emptySpaceAmount; i++) {
            Instantiate(emptySpacePrefab, createEmptySpacePos[i], Quaternion.identity);
        }
    }

    void SetEmptySpacePos() {
        for (int i = 0; i < emptySpaceAmount; i++) {
            do {
                createEmptySpacePos[i] = new Vector3(Random.Range(-1 * wallInterval, wallInterval), nextWallPosY - wallsize + Random.Range(wallsize / 2 * -1, wallsize / 2), 0);
                setPos = false;
                foreach (Vector3 alreadyPos in alreadyCreatePos) {
                    if (alreadyPos != null) {
                        if ((alreadyPos.x - createInterval / 2 < createEmptySpacePos[i].x && alreadyPos.y - createInterval / 2 < createEmptySpacePos[i].y) && (alreadyPos.y + createInterval / 2 > createEmptySpacePos[i].y && alreadyPos.y + createInterval / 2 > createEmptySpacePos[i].y)) {
                            setPos = true;
                            break;
                        }
                    }
                }
                if (!setPos) {
                    alreadyCreatePos.Add(createEmptySpacePos[i]);
                }
            }
            while (setPos);
        }
    }

    void DeleteAlreadyCreatePosList() {
        alreadyCreatePos = new List<Vector3>();
    }

    void GameDifficulty() {
        if (scoreManeger.HeightScore >= 100) {
            gameLevel = scoreManeger.HeightScore / 100;
        }
        emptySpaceAmount = (int)gameLevel + 1;
    }

    public void RetryDeleteObj() {
        nextWallPosY = 0;
        marshmallowObj = GameObject.FindGameObjectsWithTag("Marshmallow");
        emptySpaceObj = GameObject.FindGameObjectsWithTag("EmptySpace");
        treeObj = GameObject.FindGameObjectsWithTag("Tree");
        passingEmptySpaceObj = GameObject.FindGameObjectsWithTag("PassingEmptySpace");
        for (int i = 0;i < 3; i++) {
            Destroy(wallObject[i]);
        }
        foreach(GameObject obj in marshmallowObj) {
            Destroy(obj);
        }
        foreach (GameObject obj in emptySpaceObj) {
            Destroy(obj);
        }
        foreach (GameObject obj in treeObj) {
            Destroy(obj);
        }
        foreach (GameObject obj in passingEmptySpaceObj) {
            Destroy(obj);
        }
        alreadyCreatePos.Add(ago.transform.position);
    }

    public void RetryEmptySpaceAmount() {
        emptySpaceAmount = 1;
    }

}
