using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManeger : MonoBehaviour {
    public int Score { get; set; }
    public float HeightScore { get; set; }
    private float playerPositionY, startPlayerPositionY;
    [SerializeField]
    GameObject player;

    // Use this for initialization
    void Start () {
        startPlayerPositionY = player.transform.position.y;
        Score = 0;
        HeightScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        CheckHeightScore();
	}

    void CheckHeightScore() {
        if(playerPositionY + HeightScore <= player.transform.position.y) {
            HeightScore = player.transform.position.y;
        }
    }

    public void AddScore() {
        Score += 10;
    }

    public void ResetScore() {
        Score = 0;
        HeightScore = 0;
    }
}
