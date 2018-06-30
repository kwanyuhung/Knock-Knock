using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour {

	public Character a;
	public Character b;


	public int MapX= 6;
	public int MapY= 6;

	void Start () {
		minion M = new minion (minion.miniontype.ATK, 100);

		//a = new Character (Character.Type.Blue, 10, 2, 2, M);
		//b = new Character (Character.Type.Red,  10, 1, 2,M);
		//Battle (a, b);
		this.gameObject.GetComponent<MapGM>().CreateMap(MapX,MapY);

		Addchararcter(0,0,a);

	}


	void Addchararcter(int x, int y , Character C){
		this.GetComponent<MapGM> ().AddCharacter (x, y, C);
	}

	void Battle(Character atker , Character defener){
		if (CheckDef(atker,defener)) {
			DeflessDamage (defener);
		}
		else {
			Damage (defener, atker);
		}
	}











	bool CheckDef(Character atker , Character defener){
		if (defener.DEF >= atker.ATK) {
			return true;
		}
		else {
			return false;
		}

	}


	void DeflessDamage(Character target){
		Damage (target, 1);
		target.DEF = Mathf.RoundToInt(target.DEF * 0.9f);
	}

	void Damage(Character target, Character dealer){
		int dmg = dealer.ATK - target.DEF;
		DealDamage (target, dmg);
	}

	void Damage(Character target, int dmg){
		DealDamage (target, dmg);
	}

	private void DealDamage(Character target, int damage){
		target.HP -= damage;
	}
}
