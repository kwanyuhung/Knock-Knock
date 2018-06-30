using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

	public enum Rarity
	{
		SSR,
		SR,
		R,
		C,
		N
	}

	public enum World
	{
		Happiness,
		Anger,
		Sorrow,
		Fear,
		RainbowCity
	};

	public enum Type 
	{
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


	public Type TYPE;
	public World WORLD;
	public string Name;
	public int HP;
	public int ATK;
	public int DEF;
	public int COURAGE;
	public int MANA;

	public string Description;

	public minion minion;

	public Character(World WORLD_,Type TYPE_,string Name_, int HP_, int ATK_, int DEF_,int COURAGE_, int MANA_, minion M, string description_)
	{
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
