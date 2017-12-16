using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionExit : MonoBehaviour {

	void OnAnimationFinish(){
	Destroy(gameObject);
}
}
