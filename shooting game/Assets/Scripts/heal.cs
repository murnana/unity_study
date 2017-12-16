using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour {
	public int healvalue;

	void Update ()
	{
		transform.Translate (0, -0.02f, 0);

		if (transform.position.y < -5.3f) {
			Destroy (gameObject);
		}
	}

}
