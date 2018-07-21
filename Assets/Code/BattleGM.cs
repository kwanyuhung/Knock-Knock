using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGM : MonoBehaviour {

	/*
	public Character.World Atker_W;
	public Character.Type Atker_T;
	public int Atker_Hp;
	public int Atker_Atk;
	public int Atker_def;
	public int Atker_Courage;

	public Character.World defener_W;
	public Character.Type defener_T;
	public int defener_Hp;
	public int defener_Atk;
	public int defener_def;
	public int defener_Courage;*/

	public BattleUIGM BUI;
	public CharacterGM CGM;



	public void Battle(Character atker , Enemy defener){
		float CourA = atker.Courage*0.01f+1;
		float CourD = defener.Courage*0.01f+1;
		float CalADmg = atker.AttacK* CourA;
		float CalDown = defener.Defend * CourD;

		CalADmg *= CheckCourageCounter (atker.Courage, defener.Courage);
		CalADmg *= CheckWorldCounter ();
		CalADmg *= CheckTypeCounter ();

		CalADmg *= CheckDefend (CalADmg, CalDown);
		Damage (defener, (int)CalADmg);

		AfterBattle (atker);
	}

	public void AfterBattle(Character C){
		CGM.characterJumpReturn (C);
	}

	public void Damage(Enemy defener, int damge){
		BUI.DamgeText(CGM.GetCharacterGameoBject (defener).transform,damge);
		defener.HP -= damge;
		if (defener.HP <= 0) {
			//die
		}
	}
		

	float CheckDefend(float Dmg, float Defend){
		float DmgPer;
		if (Dmg > Defend) {
			DmgPer = Defend / Dmg;
		} else {
			DmgPer = Dmg / Defend;
		}
		return DmgPer;
	}

	float CheckWorldCounter(){
		return 1;
	}

	float CheckTypeCounter(){
		return 1;
	}

	float CheckCourageCounter(float Acourage,float Dcourage){
		int CalCourage = Acourage.CompareTo (Dcourage);

		if (CalCourage > 0) {
			if (CalCourage >= Dcourage * 2) {
				//Debug.Log ("Courage Max Counter");
				return 3;
			}
			//Debug.Log ("Courage Counter");
			return 1+(CalCourage/Dcourage);
		} else if (CalCourage < 0) {
			if (CalCourage <= Dcourage * -2) {
				//Debug.Log ("Courage MAx Down");
				return 1 / 3;
			}
			//Debug.Log ("Courage Down");
			return  (CalCourage / Dcourage)+1;
		} else {
			return 1;
		}
	}
}
