using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneManeger : MonoBehaviour {
    [SerializeField]
    GameObject stageSelectPanel, descriptionPanel;

	// Use this for initialization
	void Start () {
        stageSelectPanel.SetActive(false);
        descriptionPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickStageSelectModeButton() {
        stageSelectPanel.SetActive(true);
    }

    public void OnClickInfiniteModeButton() {
        SceneManager.LoadScene("InfiniteMode");
    }

    public void OnClickOperationDescriptionButton() {
        descriptionPanel.SetActive(true);
    }

    public void OnClickStageButton(int stageNum) {
        SceneManager.LoadScene("Stage" + stageNum.ToString());
    }

    public void OnClickBackButton() {
        stageSelectPanel.SetActive(false);
        descriptionPanel.SetActive(false);
    }

}
