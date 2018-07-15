using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character {

	public enum Rarity
	{
		SSR = 6,
		SR = 5,
		R = 4,
		C = 3,
		N = 2,
		NN = 1
	}

	public enum World
	{
		Null,
		Happiness,
		Anger,
		Sorrow,
		Fear,
		RainbowCity
	};

	public enum Type 
	{
		Null,
		God,
		Human,
		Lizardfolk,
		Dargon,
		Giant,
		Elf,
		Demon,
		Mech
	};

	public enum sex
	{
		Male,
		Female,
		other
	}

	static private Dictionary<Type, Character> characterTypesInfo = null;


	public int ID;

	public Rarity Rare;
	public World WORLD;
	public Type TYPE;
	public string Name;
	public int HP;
	public int ATK;
	public int DEF;
	public int COURAGE;
	public int MANA;

	public string Description;

	public minion minion;

	public World W{get{ return WORLD;}}
	public Type T{ get { return TYPE; } }
	public int LifePoint{get{return HP;}}
	public int AttacK{get{return ATK;}}
	public int Defend{get{return DEF;}}
	public int Courage{get{return COURAGE;}}
	public int MANACount{get{return MANA;}}


	public Character(int ID_, Rarity Rare_ , World WORLD_,Type TYPE_,string Name_, int HP_, int ATK_, int DEF_,int COURAGE_, int MANA_, minion M, string description_)
	{
		ID = ID_;
		Rare = Rare_;

		WORLD = WORLD_;
		TYPE = TYPE_;

		Name = Name_;

		HP  = HP_ + (int)Mathf.Round(M.gethp());
		ATK = ATK_+ (int)Mathf.Round(M.getatk());
		DEF = DEF_+ (int)Mathf.Round(M.gethp());


		COURAGE = COURAGE_;
		MANA = MANA_;

		Description = description_;
	}
		


		
	public Character(Type type)
	{
		HP = characterTypesInfo[type].HP;
		ATK = characterTypesInfo[type].ATK;
		DEF = characterTypesInfo[type].DEF;
	}
		

}

