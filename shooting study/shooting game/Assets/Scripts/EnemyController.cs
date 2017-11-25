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
	public wavechecker wavechecker;



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
			
			wavechecker.Invokeset ();
			Explosion ();
			Destroy = false;
		
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

}


//攻撃の種類
//アイテム：自分の攻撃が2列になる、HP回復、一定時間無敵
//敵のドロップ
//敵を倒した時にパーティクルでアイテムを表示
//当たり判定で取得→テキストで取得数を表示


//わかんないリスト
//ドロップさせる仕組み
//アイテム一つ一つのデータの取得

//敵から湧き出たときは固定のアイテム(パーティクル):アイテムじゃない	trigger指定して、当たったときに関数呼出し
//取得させる時にアイテム確定？→乱数とif文でアイテムを決定:アイテムになる

//アイテム決定後の保持がわかんない→アイテム管理スクリプト作って配列でID管理
//連装はいれちゅ
//アイテムを数える(増やす)、アイテムの数の変数、名前、