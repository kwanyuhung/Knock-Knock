using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIGM : MonoBehaviour {


	public GameObject DText;
	public List<GameObject> DamageTextList;


	public void DamgeText(Transform T, int Dmg){
		//if (DamageTextList.Count == 0) {
		GameObject G = Instantiate (DText, T);
		G.transform.localPosition = new Vector3 (0, 5, 0);
		G.GetComponent<Text> ().text = Dmg.ToString ();
		DamageTextList.Add (G);
		//}
	}
}
