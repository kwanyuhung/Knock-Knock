using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapinfo : MonoBehaviour {


	public MapGM.MapType Type = MapGM.MapType.none;

	public GameObject gm;

	public int mapX;
	public int mapY;

	public Mapinfo(MapGM.MapType TYPE_)
	{
		Type = TYPE_;  
	}
		
	public void SelectThisMap(){
		gm.SendMessage ("SelectMap", this.gameObject);
	}
}
