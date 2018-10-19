using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TweetButton : MonoBehaviour {
    string hashtag = "顎よ高く昇れ", tweetURL;
    [SerializeField]

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTweetButton() {
        if(SceneManager.GetActiveScene().name == "Infinitemode") {
            tweetURL = "https://twitter.com/intent/tweet?" + "text=" + ScoreManeger.HeightScore.ToString() + "m登って" + ScoreManeger.Score.ToString() + "個クソマロを処理しました！" + "&hashtags=" + hashtag;
        } else {
            tweetURL = "https://twitter.com/intent/tweet?" + "text=" + SceneManager.GetActiveScene().name + "をクリアできませんでしたが" + ScoreManeger.Score.ToString() + "個クソマロを処理しました！" + "&hashtags=" + hashtag;
        }
        
        if(Application.platform == RuntimePlatform.WebGLPlayer) {
            Application.ExternalEval(string.Format("widow.open('{0}','_blank')", tweetURL));
        } else {
            Application.OpenURL(tweetURL);
        }
    }

    public void ClearScoreTweetButton() {
        //stagekurianotokinoyatu
        tweetURL = "https://twitter.com/intent/tweet?" + "text="  + ScoreManeger.ClearStageName +"を" + ScoreManeger.TimeScore.ToString() + "秒で" + ScoreManeger.Score.ToString() + "個クソマロを処理してクリア！" + "&hashtags=" + hashtag;
        
        if (Application.platform == RuntimePlatform.WebGLPlayer) {
            Application.ExternalEval(string.Format("widow.open('{0}','_blank')", tweetURL));
        } else {
            Application.OpenURL(tweetURL);
        }
    }
}
