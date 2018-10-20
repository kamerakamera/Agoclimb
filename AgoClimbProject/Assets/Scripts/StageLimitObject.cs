using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLimitObject : MonoBehaviour {
    [SerializeField]
    Transform agoTransform;
    [SerializeField]
    float movePower,maxdistance;
    Vector3 startposition;
	// Use this for initialization
	void Start () {
        startposition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        FollowAgo();
    }

    void FollowAgo() {
        if(transform.position.y + maxdistance <= agoTransform.position.y) {
            transform.position = new Vector3(0, agoTransform.position.y - maxdistance, 0);
        }
        transform.position += new Vector3(0, 0.01f, 0) * movePower;
    }

    public void RetrySetPosition() {
        transform.position = startposition;
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Marshmallow" || other.tag == "EmptySpace") {
            Destroy(other.transform.root.gameObject);
        }
    }
}
