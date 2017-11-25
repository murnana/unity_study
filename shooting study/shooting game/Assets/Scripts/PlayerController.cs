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
	public bool CanTakenDamage;
	public bool splitbeam;

	public float nodamagetime;
	public float splittime;


	// Use this for initialization
	void Start () {
		count = 10;
		CanMove = true;
		Life = maxLife;
		LoseCheck = false;
		CanTakenDamage = true;
		splitbeam = false;
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

				if (splitbeam != true) {
					Instantiate (Prefab, transform.position, Quaternion.identity);
				} else {
					for (int k = 0; k < transform.childCount; k++) {
						Transform splitshotposition = transform.GetChild (k);
						Shot (splitshotposition);
					}
				}
			}
		
				//specialアイテムを取得時splitbeamがtrueに変わる
				//自機から出る攻撃が複数列になる→Instantiateでx成分のみいじってどうにか
				//最初からshotposを作っておいて、各posごとにCanShotを分ける→On/Off

				//if(splitbeam == true){
					//Instantiate (Prefab, transform.position, Quaternion.identity);

			}
		if (Life <= 0) {
			//Debug.Log ("GameOver");
			GameoverControll ();
			LoseCheck = true;
		}

		if (CanTakenDamage == false) {
			nodamagetime += Time.deltaTime;
			if (nodamagetime >= 3) {
				nodamagetime = 0;
				CanTakenDamage = true;
			}
		}
		if (splitbeam == true) {
			splittime += Time.deltaTime;
			if (splittime >= 10) {
				splittime = 0;
				splitbeam = false;
			}
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

			if(CanTakenDamage == true){
			//当たった相手のスクリプトを参照したい時の文
			int EneATK = hit.GetComponent<EnemyBulletController> ().damage;

		
			Life -= EneATK;
			
				if(splitbeam == true){
					splitbeam = false;
				}
			}

		}
		if (hit.CompareTag ("heal")) {
			int healitem = hit.GetComponent<heal> ().healvalue;
			Life = Mathf.Min (Life + healitem, maxLife);
				
				Destroy (hit.gameObject);

		}
		if (hit.CompareTag("nodamage")) {
		
			CanTakenDamage = false;
			Destroy (hit.gameObject);
			}
		if (hit.CompareTag ("special")) {
			splitbeam = true;
			Destroy (hit.gameObject);
		}
	}

		void GameoverControll ()
	{
		if (LoseCheck == true) {

			GOB.SetActive(true);
			CanMove = false;
		}
	}
	public void Shot(Transform origin){

			Instantiate (Prefab, origin.position, origin.rotation);
		}
	
	}

