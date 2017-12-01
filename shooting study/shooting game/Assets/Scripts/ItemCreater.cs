using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreater : MonoBehaviour {

	public float time;
	public float nodamageitemtime;
	public float splititemtime;

	public GameObject heal;
	public GameObject nodamage;
	public GameObject split;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		time += Time.deltaTime;
		nodamageitemtime += Time.deltaTime;
		splititemtime += Time.deltaTime;
		if (time >= 4) {
			Instantiate (heal, new Vector2 (-2.3f, 5.5f), Quaternion.identity);
			time = 0;

			
		}
		if (nodamageitemtime >= 10) {
			Instantiate (nodamage, new Vector2 (2.3f, 5.5f), Quaternion.identity);
			nodamageitemtime = 0;
		}
		if (splititemtime > 5) {
			Instantiate (split, new Vector2 (2.3f, 5.5f), Quaternion.identity);
			splititemtime = 0;
		}
	}
}
//////////////////////////////注目//////////////////////////////////////
//なぜかnodamageアイテムを拾ってもCanTakendamageがfalseにならなかった
