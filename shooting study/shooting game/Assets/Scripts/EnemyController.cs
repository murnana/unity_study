using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public GameObject enemybullet;
	public GameObject explosion;
	public GameObject Enemy;

	private int count = 0;
	//commonMovableplayer commonmovableplayer;
	public bool CanShotBullet;
	public int EnemyLife;
	public int EnemyAttack;

	public bool Destroy;




	// Use this for initialization
	void Start () {
		CanShotBullet = true;
		Destroy = false;
	}
	// Update is called once per frame
	void Update () {
		count++;
		//80フレームごとにメソッドを実行
		if (CanShotBullet == true) {
			if (count % 80 == 0) {
				EnemyShot ();
			}
		}
		if (EnemyLife <= 0) {
			Destroy = true;
		}
		if (Destroy == true) {
			Explosion ();
			/////////////////ここで終了////////////////
			//Invoke ("wavechercker", 5);
			//Invoke使って別スクリプトからメソッドを呼び出す
			//Debug.Log ("呼び出したよ");
		
		}
	

	}
	public void EnemyShot(){
		GameObject Enebullet = Instantiate (enemybullet,transform.position,Quaternion.identity)as GameObject;

		}
	void OnTriggerEnter2D (Collider2D hit){
		Debug.Log ("いいい");
		if (hit.CompareTag ("playerBullet")) {
			
			int pATK = GameObject.Find ("Player").GetComponent<PlayerController> ().playerATK;
			EnemyLife -= pATK;
			//Debug.Log ("的に当たったよ");
		}
	}
	public void Explosion ()
	{	Debug.Log ("ここまでok");
		Instantiate (explosion,transform.position,transform.rotation);
		Destroy (gameObject);
	}
	public void wavechecker(){
		Debug.Log ("ok");
		Instantiate (Enemy, transform.position, Quaternion.identity);
	}
			
}
