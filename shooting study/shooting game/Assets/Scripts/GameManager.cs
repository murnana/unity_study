using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	//追々難易度を自動判定して、以下を設定するようにする
	public int EnemySpawnCount;
	public int DestoroyScore;
	public int WaveCount;
	Score d;
	public Text score;
		
	void Start(){
		//敵の湧き上限
		EnemySpawnCount = 18;
		//表示するスコア
		DestoroyScore = 0;
		WaveCount = 0;
	}
	void Update(){
		//現在のスコアを表示→バグ発生中　テキストにうまく表示されない　次回修正
		score = GameObject.Find("NowScore").GetComponent<Text> ();
		d = GameObject.Find ("NowScore").GetComponent<Score> ();
		d.NowScoreSet ();
	}

	public void CountCheck(){
		//湧き数を減算
		EnemySpawnCount -= 1;
		DestoroyScore += 100;
		WaveCount += 1;
	}
}


//敵の湧き数上限設定、湧き数上限から減算処理(Invokeしたら減算→wavecheckerを参照)
//湧き数が0になるとgameclearスクリプトを呼び出し


//プレイヤーの残機の設定
//残機が0になるとgameoverスクリプトを呼び出し

