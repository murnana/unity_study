using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {

	//public int EneATK;

	public GameObject Prefab;
	public GameObject GOB;
	public GameObject enemyatk;

	public readonly int maxLife = 100; //プレイヤーの体力最大値、あとでここを変えられるようにする
	public int Life;

	public static int count;//発射間隔
	int frame;
	public int playerATK;

	public bool CanMove;
	public bool LoseCheck;


	// Use this for initialization
	void Start () {
		count = 10;
		CanMove = true;
		Life = maxLife;
		LoseCheck = false;

	}
	
	// Update is called once per frame
	void Update () {
		frame++;
		Clamp ();
		if (CanMove == true) {

			if (Input.GetKey (KeyCode.W)) {
				transform.Translate (0, 0.1f, 0);
			}
			if (Input.GetKey (KeyCode.A)) {
				transform.Translate (-0.1f, 0, 0);
			}
			if (Input.GetKey (KeyCode.S)) {
				transform.Translate (0, -0.1f, 0);
			}
			if (Input.GetKey (KeyCode.D)) {
				transform.Translate (0.1f, 0, 0);
			}
			if (Input.GetKey (KeyCode.Space) && frame % count == 0) {
				//GameObject bulletPrefab = GameObject.Instantiate (Prefab)as GameObject;

				Instantiate (Prefab, transform.position, Quaternion.identity);
			}
		}
		if (Life <= 0) {
			//Debug.Log ("GameOver");
			GameoverControll ();
			LoseCheck = true;
		}
	}
	void Clamp(){
		//移動可能範囲の設定
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0.07f));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		Vector2 pos = transform.position;

		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		transform.position = pos;
	}
	void OnTriggerEnter2D (Collider2D hit){
		Debug.Log ("あああ");
		if (hit.CompareTag ("Bullet")) {

			//当たった相手のスクリプトを参照したい時の文
			int EneATK = hit.GetComponent<EnemyBulletController>().damage;

		
			Life -= EneATK;
			Debug.Log ("当たったよ");
			//Debug.Log (Life);

		}
	}

	void GameoverControll ()
	{
		if (LoseCheck == true) {

			GOB.SetActive(true);
			CanMove = false;
		}
	}
}