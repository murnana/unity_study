using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {

	public readonly int maxLife = 100; //プレイヤーの体力最大値、あとでここを変えられるようにする
	public int Life;
	public int EnemyATK = 10;//敵の攻撃力　あとでここも(ry
	public bool LoseCheck;
	GameObject GameOverCheck;



	// Use this for initialization
	void Start () {
		Life = maxLife;//初期状態は体力が最大値
		LoseCheck = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Life <= 0) {
			//Debug.Log ("GameOver");
			LoseCheck = true;
		}
	}

	void OnTriggerEnter2D (Collider2D hit){
		Debug.Log ("あああ");
		if (hit.CompareTag ("Bullet")) {
			Life -= EnemyATK;
			Debug.Log ("当たったよ");
			//Debug.Log (Life);

		}
	}
	void GameoverControll ()
	{
		if (LoseCheck == true) {
			GameOverCheck.Find("GameOver").GetComponent<GameOverButton> ().Lose ();
			//GameOverButton.Lose ();
		}
	}
}
