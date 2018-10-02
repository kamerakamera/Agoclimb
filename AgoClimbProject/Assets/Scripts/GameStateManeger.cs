using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {
    wait,stuck, fire,gameover,dead,spintime,retrymemu
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
    StageCreateManeger stageCreateManeger;
    [SerializeField]
    StageLimitObject stageLimitObject;
	// Use this for initialization
	void Start () {
        GameState = (State)0;
	}
	
	// Update is called once per frame
	void Update () {
        StateManege();
	}

    private void FixedUpdate() {
        arrowManeger.AgoTracking();
    }

    void StateManege() {
        if(GameState == (State)0) {
            arrowManeger.ArrowDisplayChenge(true);
            if (Input.GetMouseButtonDown(0)) {
                StateChange(2);
                arrowManeger.ArrowDisplayChenge(false);
            }
        }

        if(GameState == (State)1) {
            ago.StuckChin(agoTip.WallObject);
            ago.SetZeroFallVelocity();
            arrowManeger.ArrowDisplayChenge(true);
            if (Input.GetMouseButtonDown(0)) {
                StateChange(2);
                arrowManeger.ArrowDisplayChenge(false);
            }
        }

        if (GameState == (State)2) {
            ago.Fire();
            ago.AddFallVelocity();
        }

        if (GameState == (State)3) {
            //回った後にchenge
            ago.DeadSpin();
        }

        if (GameState == (State)4) {
            arrowManeger.ArrowDisplayChenge(false);
            deadPanelManeger.DisplayDeadPanel(true);
            ago.gameObject.SetActive(false);
            StateChange(5);
        }

        if (GameState == (State)5) {
            if (Input.GetKeyDown("r")) {
                Retry();
                StateChange(0);
            }
        }
    }

    public void StateChange(int num) {
        GameState = (State)num;
    }

    void Retry() {
        stageLimitObject.RetrySetPosition();
        ago.RetryAgo();
        stageCreateManeger.RetryCreateWall();
        deadPanelManeger.DisplayDeadPanel(false);
    }

}
