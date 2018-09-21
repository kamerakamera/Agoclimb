using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {
    wait, shot,gameover,deadtime
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

    private IEnumerator Dead() {

        yield return new WaitForSeconds(1.5f);
        yield break;
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
        if (GameState == (State)2) {
            StartCoroutine("Dead");
            StateChange(3);
        }
        if(GameState == (State)3) {
            //回った
            GameObject deadAgo = ago.gameObject;
            deadAgo.transform.Rotate(new Vector3(0, 0, 20));
            deadAgo.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            if(deadAgo.transform.localScale.z < 0.1f) {
                deadAgo.SetActive(false);
                //Destroy(deadAgo);
                StateChange(4);
            }
        }
        if (GameState == (State)4) {
            //回転処理
            
        }
    }

    public void StateChange(int num) {
        GameState = (State)num;
        
    }

}
