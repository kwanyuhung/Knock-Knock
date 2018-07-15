using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapinfo : MonoBehaviour {


	public MapGM.MapType Type = MapGM.MapType.none;

	public List<Character> Character_C;
	public List<Enemy> Enemy_E;

	public GameObject gm;

	public int mapX;
	public int mapY;

	public Mapinfo(MapGM.MapType TYPE_)
	{
		Type = TYPE_;  
		Character_C = null;
		Enemy_E = null;
	}
		
	public void SelectThisMap(){
		gm.SendMessage ("SelectMap", this.gameObject);
	}
}
