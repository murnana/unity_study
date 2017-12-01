using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave: MonoBehaviour {

	public  GameObject Wavea;
	private int countcheck = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		countcheck++;
		if (countcheck % 6000 == 0) {
			//EnemyShot ();
			Instantiate (Wavea,transform.position,Quaternion.identity);
		}
		
	}

}
//オブジェクトの設定
//ウェーブ発生タイミングの設定
//今のウェーブのUIを表示

//メニューシーン→メインシーンに移動→ボタン押す→敵がプレハブから設置される
//敵が死ぬ→x秒後に次のwaveが設置される
//敵の攻撃方法の追加



//やばいことリスト
//プレハブから設置した複数敵のHPが減らない
	//当たり判定が取れてない
	//プレイヤーの弾のATKが取得できてない
	//親のWaveオブジェクトにヒット判定があり、子のEnemyにヒット判定がない

//そいつの弾に当たると1発なのに3発当たってることになる
//時間でスポーンだと詰む
