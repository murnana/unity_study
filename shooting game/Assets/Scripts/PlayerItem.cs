using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour {
	public int[] items = new int[10];

	// Use this for initialization
	void Start () {
		for (int i = 0; i < items.Length; i++) {
			items [i] = 0;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D hit)
	{	
		if (hit.CompareTag ("item")) {
			int random = Random.Range (0, 100);
			if (0 <= random && random <= 10) {
				items [0] += 1;
			}
			if (11 <= random && random <= 20) {
				items [1] += 1;
			}
			if (21 <= random && random <= 30) {
				items [2] += 1;
			}
			if (31 <= random && random <= 40) {
				items [3] += 1;
			}
			if (41 <= random && random <= 50) {
				items [4] += 1;
			}
			if (51 <= random && random <= 60) {
				items [5] += 1;
			}
			if (61 <= random && random <= 70) {
				items [6] += 1;
			}
			if (71 <= random && random <= 80) {
				items [7] += 1;
			}
			if (81 <= random && random <= 90) {
				items [8] += 1;
			}
			if (91 <= random && random <= 100) {
				items [9] += 1;
			}
		}
		Destroy (hit.gameObject);
	}
}
//敵から湧き出たときは固定のアイテム(パーティクル):アイテムじゃない	trigger指定して、当たったときに関数呼出し
/////////取得させる時にアイテム確定？→乱数とif文でアイテムを決定:アイテムになる////////

//アイテム決定後の保持がわかんない→アイテム管理スクリプト作って配列でID管理
//連装はいれちゅ
//アイテムを数える(増やす)、アイテムの数の変数、名前、
///debugitem ほげの塊0～9
