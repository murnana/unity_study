using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavechecker : MonoBehaviour {

	public GameObject Enemy;

	public void Invokeset(){
			Invoke ("wavecherck", 5);
		}
		

	void wavecherck(){
		Debug.Log ("ok");
		Instantiate (Enemy, new Vector2 (0, 3.44f),Quaternion.identity);
	}

}
//ステージクリア条件
//敵を一定数倒した時
//一定秒数間生き残る

