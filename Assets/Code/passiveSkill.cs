using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class passiveSkill {

	public enum passive 
	{
		none,
		atkUp,
		defUp,
		HpUP
	}


	public passive Pasive;
	public float value;

	public passiveSkill(passive P,float V){
		Pasive = P;
		value = V;
	}

}


