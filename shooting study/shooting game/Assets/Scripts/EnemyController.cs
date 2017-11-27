using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public GameObject enemybullet;
	public GameObject explosion;
	public GameObject Enemy;
	public GameObject DropItem;

	private int count = 0;
	//commonMovableplayer commonmovableplayer;
	public bool CanShotBullet;
	public int EnemyLife;
	public int EnemyAttack;
	public int DropItemstack;

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
		//Vector2 random = new Vector2(0,0);

		//pos_item.x = Mathf.Clamp (pos_item.x, pos_enemylast.x - 0.3f,pos_enemylast.x + 0.3f);
		//pos_item.y = Mathf.Clamp (pos_item.y, pos_enemylast.y - 0.3f,pos_enemylast.y + 0.3f);


		//DropItemstackの値の分だけInstantiateされる(アイテムが生成される)
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