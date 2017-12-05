using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Text score;
	public Text Nscore;
	public Text damage;
	public int lastscore;
	public int nowscore;
	public int lastTakeDamage;

	// Use this for initialization
	void Start () {
		lastscore = 0;
		nowscore = 0;
		score = GameObject.Find("Score").GetComponent<Text> ();
		Nscore = GameObject.Find ("NowScore").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ScoreSet(){
		//ここを変えるぞ//////////////////////////////////////
		lastscore = GameObject.Find ("GameManager").GetComponent<GameManager> ().DestoroyScore;

		score.text = "Score:" + lastscore.ToString ();
	}
	public void TakenDamageSet(){
		damage = GameObject.Find("TakenDamage").GetComponent<Text> ();
		lastTakeDamage = GameObject.Find ("Player").GetComponent<PlayerController> ().TakenDamage;

		damage.text = "受けたダメージ:" + lastTakeDamage.ToString ();
	}
	public void NowScoreSet(){
		nowscore = GameObject.Find ("GameManager").GetComponent<GameManager> ().DestoroyScore;
		Nscore.text = "Score:" + nowscore.ToString ();
	}
}
