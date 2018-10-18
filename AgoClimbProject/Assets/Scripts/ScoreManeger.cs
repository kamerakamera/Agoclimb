using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManeger : MonoBehaviour {
    public int Score { get; set; }
    public float HeightScore { get; set; }
    public int BurningScore { get; set; }
    public float TimeScore { get; set; }
    private float playerPositionY, startPlayerPositionY;
    [SerializeField]
    GameObject player;
    [SerializeField]
    Text heightScoreText,timeScoreText, marshmallowScoreText;
    [SerializeField]
    private int targetTreeNum;

    // Use this for initialization
    void Start () {
        startPlayerPositionY = player.transform.position.y;
        Score = 0;
        HeightScore = 0;
        TimeScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Infinitemode") {
            CheckHeightScore();
        } else {
            if(BurningScore >= targetTreeNum) {
                StageClear();
            }
        }
        ScoreDisplay();
        AddTimeScore();
	}

    void CheckHeightScore() {
        if(playerPositionY + HeightScore <= player.transform.position.y) {
            HeightScore = player.transform.position.y;
        }
    }

    void ScoreDisplay() {
        marshmallowScoreText.text = Score.ToString() + "\nクソマロ";
        if (SceneManager.GetActiveScene().name == "Infinitemode") {
            heightScoreText.text = ((int)HeightScore).ToString() + "m\n登った高さ";
        } else {
            timeScoreText.text = ((int)TimeScore).ToString() + "秒\n経過時間";
        }
        
    }

    public void AddScore() {
        Score += 1;
    }

    public void AddTimeScore() {
        TimeScore += Time.deltaTime;
    }

    void StageClear() {
        SceneManager.LoadScene("StageClear");
    }

    public void AddScoreBurningTree() {
        BurningScore += 1;
    }

    public void ResetScore() {
        Score = 0;
        HeightScore = 0;
    }
}
