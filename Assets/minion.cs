using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minion {

	public enum miniontype 
	{
		ATK,
		DEF,
		HP,
	}

	public float atk= 0;
	public float def=0;
	public float hp=0;

	public minion(miniontype type, float count)
	{
		if (type == miniontype.ATK) {
			atk += count;
		}

		if (type == miniontype.DEF) {
			def += count;
		}
		if (type == miniontype.HP) {
			hp += count;
		}
	}

	public float getatk(){
		atk *= 0.3f;
		return atk;
	}

	public float getdef(){
		def *= 0.1f;
		return def;
	}

	public float gethp(){
		hp *= 1;
		return hp;
	}
}
