using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPanelManeger : MonoBehaviour {
    [SerializeField]
    GameObject deadPanel;
	// Use this for initialization
	void Start () {
        deadPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayDeadPanel(bool _bool) {
        deadPanel.SetActive(_bool);
    }

}
