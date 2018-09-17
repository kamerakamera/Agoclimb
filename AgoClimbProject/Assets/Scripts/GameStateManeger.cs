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
	// Use this for initialization
	void Start () {
        GameState = 0;
	}
	
	// Update is called once per frame
	void Update () {
        StateManege();
	}

    void StateManege() {
        if(GameState == (State)0) {
            if (Input.GetMouseButtonDown(0)) {
                ago.Fire();
                StateChange(1);
            }
        }
        if (GameState == (State)1) {
            
        }
    }

    public void StateChange(int num) {
        GameState = (State)num;
        
    }

}
