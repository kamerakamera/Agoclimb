using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TweetButton : MonoBehaviour {
    [SerializeField]
    Button tweetButton;
    string hashtag = "顎よ高く昇れ", tweetURL;
    [SerializeField]
    ScoreManeger scoreManeger;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTweetButton() {
        if(SceneManager.GetActiveScene().name == "Infinitemode") {
            tweetURL = "https://twitter.com/intent/tweet?" + "text=" + scoreManeger.HeightScore.ToString() + "m登って" + scoreManeger.Score.ToString() + "個クソマロを処理しました！" + "&hashtags=" + hashtag;
        } else {
            tweetURL = "https://twitter.com/intent/tweet?" + "text=" + SceneManager.GetActiveScene().name + "をクリアできませんでしたが" + scoreManeger.Score.ToString() + "個クソマロを処理しました！" + "&hashtags=" + hashtag;
        }
        
        if(Application.platform == RuntimePlatform.WebGLPlayer) {
            //Application.ExternalEval(string.Format("widow.open('{0}','_blank')", tweetURL));
        } else {
            Application.OpenURL(tweetURL);
        }
    }
}
