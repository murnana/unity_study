using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameclear : MonoBehaviour {
	public GameObject SCB;
	public int DestoroyCount;


	void stageclear(){
		Debug.Log ("clear");
		SCB.SetActive(true);
	}
	void destoroycount(){
		DestoroyCount += 1;
	}
}//DestoroyCount += 1;
//if (DestoroyCount >= 5) {
	//stageclear ();
//} else {

//このスクリプトをenemyに入れて同じようにやる
/////////////////////////////////////////////////////ステージクリア処理作成からスタート/////////////
//ステージクリア条件
//敵を一定数倒した時
//一定秒数間生き残る
