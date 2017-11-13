using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverButton : MonoBehaviour {

	// Use this for initialization
	void  Start () {
		gameObject.GetComponent<Text>().enabled = false;
		gameObject.GetComponent<Image>().enabled = false;

	}
	
	// Update is called once per frame
	public void Lose () {
		gameObject.GetComponent<Text>().enabled = true;


		}
	public void PushGameoverButton(){
		SceneManager.LoadScene ("Titlescene");
	}

}

//非表示
//体力が0になる
//表示
//UIボタンでタイトルへ戻るがでる
//押すとタイトルシーンへ移動
//非表示