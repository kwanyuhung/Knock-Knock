using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropBoxUI : MonoBehaviour {

	public GameObject CharacterBox;

	public GameObject Camera;

	public CharacterGM CGM;

	public List<Character> Characterlist;

	public List<GameObject> GOBject;

	public void CreateBox(List<Character> Clist){
		Characterlist = Clist;
		float range = 40.0f;

		float cal = ((Clist.Count * range / 2)-range/2) *-1;

		float countR = cal;

		foreach (Character C in Clist) {
			//string number = C.ID.ToString ();
			//Sprite icon = Resources.Load <Sprite> ("icon/" + number);
			GameObject G = Instantiate (CharacterBox,Camera.transform);
			G.transform.localPosition = new Vector3 (countR, this.transform.localPosition.y, 0);
			G.transform.SetParent (this.transform);
			//Image Img = G.GetComponent<Image> ();
			//Img.sprite = icon;
			GOBject.Add (G);
			countR += range;
		}
		updateImage (GOBject);
	}

	public void updateBox(){
		Character frsit = Characterlist [0];

		for (int i = 0; i < Characterlist.Count-1; i++) {
			Characterlist [i] = Characterlist [i+1];
		}
		Characterlist [Characterlist.Count-1] = frsit;
		updateImage (GOBject);
	}

	public void SelectBoxinfo(){


	}

	void updateImage(List<GameObject> GOB){


		for(int i = 0 ; i < GOBject.Count;i++){
			string number = Characterlist[i].ID.ToString ();
			Sprite icon = Resources.Load <Sprite> ("icon/" + number);
			Image Img = GOBject[i].GetComponent<Image> ();
			Img.sprite = icon;
		}
	}
}
