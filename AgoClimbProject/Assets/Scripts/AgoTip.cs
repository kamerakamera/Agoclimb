using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgoTip : MonoBehaviour {
    [SerializeField]
    Ago ago;
    [SerializeField]
    GameStateManeger gameStateManeger;
    public GameObject WallObject { get; set; }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.tag == "Wall" || gameStateManeger.GameState == (State)1) {
            ago.StuckChin(col.gameObject);
            gameStateManeger.StateChange(1);
            WallObject = col.gameObject;
        }
    }
}
