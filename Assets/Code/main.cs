using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour {

	public Character a;

	public int MapX= 6;
	public int MapY= 6;


	MapGM Map_GM;

	void Start () {
		minion M = new minion (minion.miniontype.ATK, 100);

		a = new Character (0,Character.Rarity.SSR,Character.World.Sorrow,Character.Type.God,"jj", 100,20,20,20,10,M,"eat shit");

		Enemy B = new Enemy(11,Character.World.Fear,Character.Type.Demon,"Demon",1000,20,20,20,10,M,"real Demono");

		//b = new Character (Character.Type.Red,  10, 1, 2,M);
		//Battle (a, b);
		this.gameObject.GetComponent<MapGM>().CreateMap(MapX,MapY);

		Addchararcter(a,3,3);
		Addchararcter (B, 2, 1);

	}


	void Addchararcter(Character C, int x, int y ){
		Mapinfo map = this.GetComponent<MapGM> ().getmap (x,y);
		this.GetComponent<CharacterGM>().ADDCharacterToMap (C, map);
	}
	void Addchararcter(Enemy E, int x, int y ){
		Mapinfo map = this.GetComponent<MapGM> ().getmap (x,y);
		this.GetComponent<CharacterGM>().ADDCharacterToMap (E, map);
	}
		
}
