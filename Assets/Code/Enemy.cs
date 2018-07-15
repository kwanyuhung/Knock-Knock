using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Enemy  {

	public int ID;

	public Character.World WORLD;
	public Character.Type TYPE;
	public string Name;
	public int HP;
	public int ATK;
	public int DEF;
	public int COURAGE;
	public int MANA;

	public string Description;

	public minion minion;

	public Enemy(int ID_ , Character.World WORLD_,Character.Type TYPE_,string Name_, int HP_, int ATK_, int DEF_,int COURAGE_, int MANA_, minion M, string description_)
	{
		ID = ID_;

		WORLD = WORLD_;
		TYPE = TYPE_;

		Name = Name_;

		HP  = HP_ + (int)Mathf.Round(M.gethp());
		ATK = ATK_+ (int)Mathf.Round(M.getatk());
		DEF = DEF_+ (int)Mathf.Round(M.gethp());


		COURAGE = COURAGE_;
		MANA = MANA_;

		minion = M;
		Description = description_;
	}
}
