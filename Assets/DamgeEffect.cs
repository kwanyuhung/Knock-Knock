using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeEffect : MonoBehaviour {

	// Update is called once per frame
	public float Speed ;
	public float waittime;

	public int max;

	void FixedUpdate(){
		float addspeed = Speed * Time.deltaTime;
		this.transform.localPosition = new Vector3 (0, this.transform.localPosition.y*(1+addspeed), 0);

		if (this.transform.localPosition.y > max) {
			this.gameObject.SetActive (false);
		}
	}
}
