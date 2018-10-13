using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour {
    public int Score { get; set; }
    public float HeightScore { get; set; }
    private float playerPositionY, startPlayerPositionY;
    [SerializeField]
    GameObject player;
    [SerializeField]
    Text heightScoreText, marshmallowScoreText;

    // Use this for initialization
    void Start () {
        startPlayerPositionY = player.transform.position.y;
        Score = 0;
        HeightScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        CheckHeightScore();
        ScoreDisplay();
	}

    void CheckHeightScore() {
        if(playerPositionY + HeightScore <= player.transform.position.y) {
            HeightScore = player.transform.position.y;
        }
    }

    void ScoreDisplay() {
        marshmallowScoreText.text = Score.ToString() + "\nクソマロ";
        heightScoreText.text = ((int)HeightScore).ToString() + "m\n登った高さ";
    }

    public void AddScore() {
        Score += 1;
    }

    public void ResetScore() {
        Score = 0;
        HeightScore = 0;
    }
}
