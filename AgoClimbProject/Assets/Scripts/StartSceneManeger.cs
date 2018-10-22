using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneManeger : MonoBehaviour {
    [SerializeField]
    GameObject stageSelectPanel, descriptionPanel;
    [SerializeField]
    GameObject[] descriptionPage;

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
        foreach(GameObject page in descriptionPage) {
            page.SetActive(false);
        }
        descriptionPage[0].SetActive(true);
    }

    public void OnClickNextPage(int pageNum) {
        descriptionPage[pageNum - 1].SetActive(false);
        descriptionPage[pageNum].SetActive(true);
    }

    public void OnClickStageButton(int stageNum) {
        SceneManager.LoadScene("Stage" + stageNum.ToString());
    }

    public void OnClickBackButton() {
        stageSelectPanel.SetActive(false);
        descriptionPanel.SetActive(false);
        foreach (GameObject page in descriptionPage) {
            page.SetActive(false);
        }
    }

}
