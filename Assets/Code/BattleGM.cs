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



	public void Battle(Character atker , Enemy defener){
		float CourA = atker.Courage*0.01f+1;
		float CourD = defener.Courage*0.01f+1;
		Debug.Log ("CA " + CourA);
		Debug.Log ("CD " + CourD);
		float CalADmg = atker.AttacK* CourA;
		float CalDown = defener.Defend * CourD;

		Debug.Log ("cal dmg" + CalADmg);
		Debug.Log ("cal down" + CalDown);
		Debug.Log ("Counter % " + CheckCourageCounter (atker.Courage, defener.Courage));
		CalADmg *= CheckCourageCounter (atker.Courage, defener.Courage);
		CalADmg *= CheckWorldCounter ();
		CalADmg *= CheckTypeCounter ();

		Debug.Log ("checkDef " + CheckDefend (CalADmg, CalDown));
		CalADmg *= CheckDefend (CalADmg, CalDown);

		Debug.Log ("final Deal" + CalADmg);
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
				Debug.Log ("Courage Max Counter");
				return 3;
			}
			Debug.Log ("Courage Counter");
			return 1+(CalCourage/Dcourage);
		} else if (CalCourage < 0) {
			if (CalCourage <= Dcourage * -2) {
				Debug.Log ("Courage MAx Down");
				return 1 / 3;
			}
			Debug.Log ("Courage Down");
			return  (CalCourage / Dcourage)+1;
		} else {
			return 1;
		}
	}

	void Battle(Enemy defener, Character atker ){

	}
}
