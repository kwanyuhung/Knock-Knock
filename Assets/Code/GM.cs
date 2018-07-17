using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {


	public enum GameState
	{
		NewTurn, //0
		BeforeStart,
		StartTurn,
		BeforeJump,
		Jump,
		AfterJump,
		SkillTurn,
		BeforeMove,
		Move,
		AfterMove,
		BeforeBattle,
		Battle,
		AfterBattle,
		EndTurn, //13

		BeforeStart_E, //14
		Start_E,
		BeforeJump_E,
		Jump_E,
		AfterJump_E,
		SkillTurn_E,
		BeforeMove_E,
		move_E,
		AfterMove_E,
		BeforeBattle_E,
		Battle_E,
		AfterBattle_E,
		EndTurn_E, // 26


		Win,
		Lose
	}
		
	public int GameTurn = 0;

	public int MapX= 6;
	public int MapY= 6;

	public GameState G = GameState.NewTurn;
	public GameState Turn {get { return G;}}

	public MapGM MGM;
	public CharacterGM CGM;

	public Text LOG;

	public List<Character> Clist = new List<Character> ();

	public List<Character> GetBoxList {get{return Clist;}}

	public void SetUp(){
		minion M = new minion (minion.miniontype.ATK, 100);
		Character a = new Character (0,Character.Rarity.SSR,Character.World.Sorrow,Character.Type.God,"jj", 1,14,1,30,1,M,"eat shit");

		Character CB = new Character (1,Character.Rarity.SSR,Character.World.Sorrow,Character.Type.God,"jj", 1,14,1,30,1,M,"eat shit");
		Character CC = new Character (2,Character.Rarity.SSR,Character.World.Sorrow,Character.Type.God,"jj", 1,14,1,30,1,M,"eat shit");
		Character CD = new Character (3,Character.Rarity.SSR,Character.World.Sorrow,Character.Type.God,"jj", 1,14,1,30,1,M,"eat shit");

		Enemy B = new Enemy(11,Character.World.Fear,Character.Type.Demon,"Demon",1,1,100,20,1,M,"real Demono");

		MGM.CreateMap (MapX, MapY);
		//CGM.Addchararcter (a,3,3);
		CGM.Addchararcter (B, 2, 1);


		Clist.Add (a);
		Clist.Add (CB);
		Clist.Add (CC);
		Clist.Add (CD);

		for (int i = 0; i < Clist.Count;i++) {
			Clist [i].Teamid = i;
		}

		CGM.AddCharacterDropBox (Clist);
	}

	public void Start(){
		SetUp ();
		UpdateState ();
	}


	public void NewTurn(){
		UpdateState ();
	}

	public void BeforeStart(){
		UpdateState ();
	}

	public void StartTurn(){
		UpdateState ();
	}

	public void BeforeJump(){
		UpdateState ();
	}

	public void Jump(){
		
	}

	public void AfterJump(){
		UpdateState ();
	}

	public void SkillTurn(){
		UpdateState ();
	}

	public void BeforeMove(){
		UpdateState ();
	}

	public void Move(){
		
	}

	public void AfterMove(){
		UpdateState ();
	}

	public void BeforeBattle(){
		UpdateState ();
	}

	public void Battle(){
		UpdateState ();
	}

	public void AfterBattle(){
		UpdateState ();
	}

	public void EndTurn(){
		UpdateState ();
	}


	public void UpdateState(){
		if (G == GameState.NewTurn) {
			//GameTurn += 1;
			G+=1;
			GameTurn = 4;
		}

		if (G != GameState.Lose && G != GameState.Win) {
			if (G == GameState.EndTurn_E) {
				G = GameState.BeforeStart;
			} else {
				G += 1;
			}
		} else if (G == GameState.Lose) {
			Debug.Log ("game over");
		} else if (G == GameState.Win) {
			Debug.Log ("game over");
		}

		updateText ();
		GoTurn ();
	}
		
	void updateText(){
		LOG.text = G.ToString();
	}

	void GoTurn(){
		Debug.Log ("this turn now" + Turn.ToString ());
		Invoke (Turn.ToString (),1);
	}
}
