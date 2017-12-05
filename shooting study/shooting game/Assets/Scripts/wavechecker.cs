using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavechecker : MonoBehaviour {
	GameObject [] tagEnemy;

	public GameObject Enemy;
	public GameObject SCB;
	public GameObject ScoreText;
	public GameObject TakeDamageText;
	Score c;
	public int SpawnCheck;
	public int SpawnSwitch;
	public int EnemyAlive;

	Vector2 hoge = new Vector2(0,6.4f);

	void Update () {
		EnemyCountChecker ("enemy");
		spawnswitch ();

	}



	public void Invokeset(){

		SpawnCheck = GameObject.Find ("GameManager").GetComponent<GameManager> ().EnemySpawnCount;
		if (SpawnCheck >= 1 ) {
			Invoke ("wavecheck", 3);
		} else {
			stageclear ();

		}
			
		}
		

	void wavecheck(){
		if (EnemyAlive == 0 && SpawnCheck >=1) {
			Debug.Log ("ok");
			switch (SpawnSwitch) {
			case 0:
				Instantiate (Enemy, new Vector2 (0, 6.4f), Quaternion.identity);
				break;
			case 1:
				for (int i = 0; i <= 2; i++) {
					Instantiate (Enemy, hoge, Quaternion.identity);
					if (i < 1) {
						hoge.x += 2.0f;
					} else if (i == 1) {
						hoge.x -= 4.0f;
					} else {
						hoge.x += 1.5f;
					}
			
					
				}
				break;
			case 2:
				for (int i = 0; i <= 3; i++) {
					Instantiate (Enemy, hoge, Quaternion.identity);
					if (i < 1) {
						hoge.x += 2.0f;
					} else if (i == 1) {
						hoge.x -= 4.0f;
					} else if (i == 2) {
						hoge.x += 1.5f;
					} else {
						hoge.y += 0.8f;
					}
					//繰り返しているため、画面外に出てしまう要修正
				}
				break;
			}
		}
	}
	void stageclear(){
		Debug.Log ("clear");
		//メニューに戻るボタン表示
		SCB.SetActive(true);
		//リザルトスコア表示
		ScoreText.SetActive (true);
		//リザルトスコアに値を代入
		c = GameObject.Find ("Score").GetComponent<Score> ();
		c.ScoreSet ();
		//受けたダメージを表示
		TakeDamageText.SetActive(true);
		c.TakenDamageSet ();

		}
	void spawnswitch(){
		int wavecountGM = GameObject.Find ("GameManager").GetComponent<GameManager> ().WaveCount;
		if (wavecountGM >= 0 && wavecountGM <= 2) {
			SpawnSwitch = 0;
		} else if (wavecountGM > 2 && wavecountGM <= 8) {
			SpawnSwitch = 1;
		} else {
			SpawnSwitch = 2;
		}
	}
	void EnemyCountChecker(string tagname){
		tagEnemy = GameObject.FindGameObjectsWithTag (tagname);
		EnemyAlive = tagEnemy.Length;
		Debug.Log ("おっけい");
	}

}
//ステージクリア条件
//敵を一定数倒した時
//一定秒数間生き残る


//リザルト画面を作る
//撃破スコア、被ダメージ、経験値、ステージクリア時間、お金？

//わかんない
//表示する中身を変更する方法,記録する方法(経験値、ステージクリア時間、お金)

//敵の種類の増加



//成果
//waveで敵が増える処理を作った(未完成)
//次回複数敵がわく処理の座標の決定手段を考えるところから
