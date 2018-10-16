using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marshmallow : MonoBehaviour {
    ScoreManeger scoreManeger;
    [SerializeField]
    GameObject marshmallow,particle;
    bool isDead;
    float deadCount;
    // Use this for initialization
    void Start () {
        scoreManeger = GameObject.Find("ScoreManeger").GetComponent<ScoreManeger>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            scoreManeger.AddScore();
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(marshmallow);
        } 
        if(other.tag == "Flame") {
            scoreManeger.AddScore();
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(marshmallow);
        }
    }
}
