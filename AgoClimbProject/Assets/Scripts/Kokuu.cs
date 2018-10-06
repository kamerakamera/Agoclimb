using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kokuu : MonoBehaviour {
    [SerializeField]
    GameStateManeger gameStateManeger;
	// Use this for initialization
	void Start () {
        gameStateManeger = GameObject.Find("GameStateManeger").GetComponent<GameStateManeger>();
	}
	
	// Update is called once per frame
	void Update () {
        Spin();
	}

    public void Spin() {
        transform.Rotate(new Vector3(0,0,10));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag == "Player") {
            gameStateManeger.StateChange(3);
        }
    }

}
