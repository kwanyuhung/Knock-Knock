using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour {

	public Character a;

	public int MapX= 6;
	public int MapY= 6;

	public BattleGM BGM;

	void Start () {
		minion M = new minion (minion.miniontype.ATK, 100);

		a = new Character (0,Character.Rarity.SSR,Character.World.Sorrow,Character.Type.God,"jj", 1,14,1,30,1,M,"eat shit");

		Enemy B = new Enemy(11,Character.World.Fear,Character.Type.Demon,"Demon",1,1,100,20,1,M,"real Demono");

		this.gameObject.GetComponent<MapGM>().CreateMap(MapX,MapY);

		Addchararcter(a,3,3);
		Addchararcter (B, 2, 1);

		BGM.Battle (a, B);

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
