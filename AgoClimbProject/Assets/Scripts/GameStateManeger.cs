using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum State {
    wait,stuck, fire,spintime, gameover, retrymemu,moving
}

public class GameStateManeger : MonoBehaviour {
    public State GameState { get; set; }
    [SerializeField]
    Ago ago;
    [SerializeField]
    AgoTip agoTip;
    [SerializeField]
    ArrowManeger arrowManeger;
    [SerializeField]
    DeadPanelManeger deadPanelManeger;
    [SerializeField]
    InfiniteStageCreateManeger stageCreateManeger;
    [SerializeField]
    StageLimitObject stageLimitObject;
    [SerializeField]
    ScoreManeger scoreManeger;
	// Use this for initialization
	void Start () {
        scoreManeger.ResetScore();
        GameState = (State)0;
        ScoreManeger.ClearStageName = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
        StateManege();
	}

    private void FixedUpdate() {
        arrowManeger.AgoTracking();
    }

    void StateManege() {
        if(GameState == State.wait) {
            arrowManeger.ArrowDisplayChenge(true);
            if (Input.GetMouseButtonDown(0)) {
                StateChange(2);
                arrowManeger.ArrowDisplayChenge(false);
            }
        }

        if(GameState == State.stuck) {
            ago.StuckChin(agoTip.WallObject);
            ago.SetZeroFallVelocity();
            arrowManeger.ArrowDisplayChenge(true);
            if (Input.GetMouseButtonDown(0)) {
                StateChange(2);
                arrowManeger.ArrowDisplayChenge(false);
            }
        }

        if (GameState == State.fire) {
            ago.Fire();
            StateChange((int)State.moving);
        }

        if (GameState == State.spintime) {
            //回った後にchenge
            ago.DeadSpin();
        }

        if (GameState == State.gameover) {
            arrowManeger.ArrowDisplayChenge(false);
            deadPanelManeger.DisplayDeadPanel(true);
            ago.gameObject.SetActive(false);
            StateChange(5);
        }

        if (GameState == State.retrymemu) {
            if (Input.GetKeyDown("r")) {
                Retry();
                StateChange(0);
            }
            if (Input.GetKeyDown("w")) {
                scoreManeger.ResetScore();
                SceneManager.LoadScene("StartScene");
            }
        }

        if(GameState == State.moving) {
            ago.AddFallVelocity();
            ago.ChengeRotation();
        }
    }

    public void StateChange(int num) {
        GameState = (State)num;
    }

    void Retry() {
        scoreManeger.ResetScore();
        if (SceneManager.GetActiveScene().name == "Infinitemode") {
            ago.RetryAgo();
            stageLimitObject.RetrySetPosition();
            stageCreateManeger.RetryGameLevel();
            stageCreateManeger.RetryDeleteObj();
            deadPanelManeger.DisplayDeadPanel(false);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

}
