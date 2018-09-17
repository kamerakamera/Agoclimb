using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {
    wait, shot
}

public class StateManeger : MonoBehaviour {
    public State GameState { get; set; }
    [SerializeField]
    Ago ago;
	// Use this for initialization
	void Start () {
        GameState = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
	}



    void StateChange() {
        if(GameState == (State)0) {
            GameState += 1;
        }
        else if(GameState == (State)1) {
            GameState = 0;
        }
    }

}
