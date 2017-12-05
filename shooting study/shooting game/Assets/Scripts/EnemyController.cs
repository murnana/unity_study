using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public GameObject enemybullet;
	public GameObject explosion;
	public GameObject Enemy;
	public GameObject DropItem;

	private int count = 0;

	public bool CanShotBullet;
	public int EnemyLife;
	public int EnemyAttack;
	public int DropItemstack;
	public int DeathCount;
	public float InTime;

	public bool Destroy;
	wavechecker a;
	GameManager b;



	// Use this for initialization
	void Start () {
		CanShotBullet = false;
		Destroy = false;
		DeathCount = 0;
		InTime = 0;
	}
	// Update is called once per frame
	void Update () {
		InTime +=Time.deltaTime;
		if (0f <= InTime && InTime<= 1.2f) {
			transform.Translate (0, -0.05f, 0);
		}
		//要調整
		if (InTime >= 1.7f) {
			CanShotBullet = true;
		}
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
			b = GameObject.Find ("GameManager").GetComponent<GameManager> ();
			b.CountCheck ();
			a = GameObject.Find ("Wavechecker").GetComponent<wavechecker> ();
			//今→敵を倒すと次のInstantiateを呼ぶ
		

			Explosion ();
			a.Invokeset ();
			itemdrop ();
			Destroy = false;
		
		}
	

	}
	//敵が弾を撃つ
	public void EnemyShot(){
		GameObject Enebullet = Instantiate (enemybullet,transform.position,Quaternion.identity)as GameObject;

		}
	//HPが減る処理
	void OnTriggerEnter2D (Collider2D hit){
		Debug.Log ("いいい");
		if (hit.CompareTag ("playerBullet")) {
			
			int pATK = GameObject.Find ("Player").GetComponent<PlayerController> ().playerATK;
			EnemyLife -= pATK;
			//Debug.Log ("的に当たったよ");
		}
	}
	//爆発を作成
	public void Explosion ()
	{	Debug.Log ("ここまでok");
		Instantiate (explosion,transform.position,transform.rotation);
		Destroy (gameObject);
	}
	public void itemdrop(){

		Vector2 pos_enemylast = transform.position;//撃破位置

		int i = 1;
		while(i<= DropItemstack){
			float random_x = Random.Range (pos_enemylast.x - 0.3f, pos_enemylast.x + 0.3f);
			float random_y = Random.Range (pos_enemylast.y - 0.3f, pos_enemylast.y + 0.3f);

			Vector2 droprange = new Vector2 (random_x, random_y);
		Instantiate (DropItem, droprange, Quaternion.identity);
			i++;
		}
	}

		//Destoroyがtrueになったら呼び出される
		//敵の撃破位置を中心とした一定範囲
		//一定範囲内で、Itemオブジェクトをランダム位置に配置する
		//ドロップする個数を設定できるようにする→繰り返し回数を設定する

}


//増やす敵の種類(増やす方法がわからない)
//体力が多い敵、攻撃が2列の敵、一定確率で弾が当たらない敵、アイテムを多く落とす敵+一定時間で帰っちゃう
//倒すと固定砲台になり、敵を撃ってくれる敵、倒すと障害物になる敵

//敵を複数出す方法
//Instantiateで座標を変えてループ？
//

//場面ごとに敵の出現数を変える方法がわからない



//確実に起こるバグ
//敵に接触したら敵が死ぬ→レイヤーであたり判定をなくして改善終了


//再現性がわからないバグ
//敵の湧きが途中で止まった