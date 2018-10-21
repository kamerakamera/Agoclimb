using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneManeger : MonoBehaviour {
    [SerializeField]
    GameObject backGroundAgo;
    [SerializeField]
    SpriteRenderer backGroundSpriteColor;
    Color nextColor;
    float colorValueH, colorValueS, colorValueV;
    bool isUp, isDown;
	// Use this for initialization
	void Start () {
        isUp = true;
        nextColor = backGroundSpriteColor.color;

    }
	
	// Update is called once per frame
	void Update () {
        BackGroundChengeRotation();
        ChengeColor();
        if (Input.GetKeyDown("w")) {
            LoadTitleScene();
        }
	}

    void BackGroundChengeRotation() {
        backGroundAgo.transform.Rotate(0, 0, 45 * Time.deltaTime);
    }

    void ChengeColor() {
        colorValueH += 1 * Time.deltaTime;
        if(colorValueH >= 1) {
            colorValueH = 0;
        }
        nextColor = Color.HSVToRGB(colorValueH, 1, 1);
        backGroundSpriteColor.color = new Color(nextColor.r, nextColor.g, nextColor.b, 0.7f);
    }

    void LoadTitleScene() {
        SceneManager.LoadScene("StartScene");
    }

}
