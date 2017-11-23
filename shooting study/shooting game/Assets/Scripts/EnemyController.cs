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
//


//回復アイテム  下に一定速度で移動、当たり判定、Destoroy、プレイヤーのHP参照、回復処理
//回復アイテム側の当たり判定でplayercontrollerの(仮)healを呼び出す
//healの中でLifeに数値を+
//+する値を一定に固定
//回復アイテムの発生条件or発生タイミング
