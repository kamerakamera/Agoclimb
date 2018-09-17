using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {
    wait, shot
}

public class GameStateManeger : MonoBehaviour {
    public State GameState { get; set; }
    [SerializeField]
    Ago ago;
    [SerializeField]
    ArrowManeger arrowManeger;
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
                ago.Fire();
                StateChange(1);
                arrowManeger.ArrowDisplayChenge(false);
            }
        }
        if (GameState == (State)1) {
            
        }
    }

    public void StateChange(int num) {
        GameState = (State)num;
        
    }

}
