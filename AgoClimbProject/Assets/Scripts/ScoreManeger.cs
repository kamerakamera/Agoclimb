using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManeger : MonoBehaviour {
    public int Score { get; set; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore() {
        Score += 10;
    }

    public void ResetScore() {
        Score = 0;
    }
}
