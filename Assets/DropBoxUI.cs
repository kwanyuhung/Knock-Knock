using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropBoxUI : MonoBehaviour {

	public GameObject CharacterBox;

	public GameObject Camera;


	public void CreateBox(List<Character> Clist){
		float range = 40.0f;

		float cal = ((Clist.Count * range / 2)-range/2) *-1;

		float countR = cal;

		foreach (Character C in Clist) {
			string number = C.ID.ToString ();
			Sprite icon = Resources.Load <Sprite> ("icon/" + number);
			GameObject G = Instantiate (CharacterBox,Camera.transform);
			G.transform.localPosition = new Vector3 (countR, this.transform.localPosition.y, 0);
			G.transform.SetParent (this.transform);
			Image Img = G.GetComponent<Image> ();
			Img.sprite = icon;
			countR += range;
		}
	}
}
