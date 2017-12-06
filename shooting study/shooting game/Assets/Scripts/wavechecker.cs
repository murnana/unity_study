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
		//Random.Rangeで敵の沸く場所のx座標を指定したかった
		//画面外に出ないように範囲を指定したい
		Vector2 hoge = new Vector2 (0, 6.4f);
		hoge.x = Mathf.Clamp (hoge.x, -2.5f, 2.5f);

		if (EnemyAlive == 0 && SpawnCheck >=1) {
			Debug.Log ("ok");
			switch (SpawnSwitch) {
			case 0:
				Instantiate (Enemy, new Vector2 (0, 6.4f), Quaternion.identity);
				break;
			case 1:
				for (int i = 0; i <= 2; i++) {
					float random = Random.Range (-3f, 3f);
					hoge.x = hoge.x + random;

					Instantiate (Enemy, hoge, Quaternion.identity);
					hoge.x = hoge.x - random;
					//ここで一番最初のhogeの座標に戻したい
				}
				break;
			case 2:
				for (int i = 0; i <= 3; i++) {
					float randomm = Random.Range (-3f, 3f);
					hoge.x = hoge.x + randomm;

					Instantiate (Enemy, hoge, Quaternion.identity);
					hoge.x = hoge.x - randomm;
				}
				break;
			}//仮完成　座標決定方法要検討
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

