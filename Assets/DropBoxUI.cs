using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropBoxUI : MonoBehaviour {

	public GameObject CharacterBox;



	public void CreateBox(List<Character> Clist){
		float Count = 0.0f;	
		float range = 40.0f;

		foreach (Character C in Clist) {
			string number = C.ID.ToString ();
			Sprite icon = Resources.Load <Sprite> ("icon/" + number);
			Vector3 T = new Vector3 (Count, this.transform.position.y, 0.0f);
			GameObject G = Instantiate (CharacterBox,this.transform);
			G.transform.position = T;
			G.transform.SetParent (this.transform);
			Image Img = G.GetComponent<Image> ();
			Img.sprite = icon;
			Count += range;
		}
	}
}
