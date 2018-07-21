using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapinfo : MonoBehaviour {


	public MapGM.MapType Type = MapGM.MapType.none;

	public List<Character> Character_C;
	public List<Enemy> Enemy_E;

	public MapGM MGM;
	public GM GM;

	public int mapX;
	public int mapY;

	public Mapinfo(MapGM.MapType TYPE_)
	{
		Type = TYPE_;  
		Character_C = null;
		Enemy_E = null;
	}
		
	public void SelectThisMap(){
		if (GM.Turn == GM.GameState.Jump) {
			GM.UpdateState ();
			MGM.SelectJump (this.gameObject);
		} else if (GM.Turn == GM.GameState.Move) {
			if (GM.movecount > 0) {
				MGM.SelectMap (this.gameObject);
				GM.MoveCountDown ();
				if (GM.CheckBattle ()) { //check and go battle
					GM.GoToTurn (GM.GameState.AfterBattle);
				}
			}
		}
	}
}
