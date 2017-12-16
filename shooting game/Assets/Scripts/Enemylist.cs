using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemylist : MonoBehaviour {
	public int[] EnemyNo = new int[5];

	struct Enemy{
		public string EnemyName;
		public int EnemyAttack;
		public int EnemyLife;
		public int Attackpatterm;

		public Enemy(string name,int atk,int life,int patterm){
			EnemyName = name;
			EnemyAttack = atk;
			EnemyLife = life;
			Attackpatterm = patterm;
		}
	}
	List <Enemylist> enemylist = new List<Enemylist>();

	//やりたいこと
	////////////////////////敵の種類を増やしたい//////////////////////////////////
	//構造体リストで敵の種類を記録
	//記録された敵の情報をEnemyControllerから呼び出し
	//インスペクタでEnemyNoを使ってどの種類の敵か設定
	//Attackpattermの中身を設定


	// Use this for initialization
	void Start () {
		enemylist.Add (new Enemy ("通常型,10,50,0")); //enemylist[0]
		enemylist.Add (new Enemy ("装甲型,15,100,0"));
		enemylist.Add (new Enemy ("複座型,10,40,1"));
		enemylist.Add (new Enemy ("回避型,15,30,0"));
		enemylist.Add (new Enemy ("希少型,10,70,0"));

		for (int i = 0; i < EnemyNo.Length; i++) {
			EnemyNo [i] = enemylist [i];
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
