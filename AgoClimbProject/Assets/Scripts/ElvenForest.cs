using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElvenForest : MonoBehaviour {
    bool IsBurning { get; set; }
    float burningCountTime, burningCountLimit = 2;
    [SerializeField]
    Sprite burninngSprite;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    ScoreManeger scoreManeger;
	// Use this for initialization
	void Start () {
        burningCountTime = 0;
        IsBurning = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsBurning) {
            BurningCountTime();
        }
	}

    void Burning() {
        spriteRenderer.sprite = burninngSprite;
    }

    void BurningCountTime() {
        burningCountTime += Time.deltaTime;
        if(burningCountTime >= burningCountLimit) {
            DeleteTree();
        }
    }

    void DeleteTree() {
        if(SceneManager.GetActiveScene().name != "Infinitemode") {
            scoreManeger.AddScoreBurningTree();
        }
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Flame") {
            IsBurning = true;
            Burning();
        }
    }
}
