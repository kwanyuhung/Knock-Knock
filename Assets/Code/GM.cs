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
	public BattleGM BGM;

	public Text LOG;

	public List<Character> Clist = new List<Character> ();

	public List<Character> GetBoxList {get{return Clist;}}

	public int movecount=3;

	public void SetUp(){


		passiveSkill p = new passiveSkill(passiveSkill.passive.atkUp,30);
		List<passiveSkill> PL = new List<passiveSkill> ();
		PL.Add (p);

		minion M = new minion (minion.miniontype.ATK, 100);
		Character a = new Character (0,Character.Rarity.SSR,Character.World.Sorrow,Character.Type.God,"jj", 1,14,1,30,1,M,"eat shit",PL);

		Character CB = new Character (1,Character.Rarity.SSR,Character.World.Sorrow,Character.Type.God,"jj", 1,14,1,30,1,M,"eat shit",PL);
		Character CC = new Character (2,Character.Rarity.SSR,Character.World.Sorrow,Character.Type.God,"jj", 1,14,1,30,1,M,"eat shit",PL);
		Character CD = new Character (3,Character.Rarity.SSR,Character.World.Sorrow,Character.Type.God,"jj", 1,14,1,30,1,M,"eat shit",PL);

		Enemy B = new Enemy(11,Character.World.Fear,Character.Type.Demon,"Demon",1000,1,100,20,1,M,"real Demono");

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
		//
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
		//
	}

	public void AfterMove(){
		UpdateState ();
	}

	public void BeforeBattle(){
		UpdateState ();
	}

	public void Battle(){
		
	}

	public void AfterBattle(){
		
		UpdateState ();
	}

	public void EndTurn(){
		Reset ();
		UpdateState ();
	}


	public void UpdateState(){
		if (G == GameState.NewTurn) {
			//GameTurn += 1;
			G+=1;
			GameTurn = 4;
		}

		if (G != GameState.Lose && G != GameState.Win) {
			//if (G == GameState.EndTurn_E) {
			if (G == GameState.EndTurn) {
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
		//Debug.Log ("this turn now" + Turn.ToString ());
		Invoke (Turn.ToString (),0.5f);
	}

	public void MoveCountDown(){
		movecount -= 1;
		if (movecount == 0) {
			Debug.Log ("end turn +++");
			GoToTurn (GameState.AfterBattle);
		}
	}

	public void GoToTurn(GameState GT){
		G = GT;
		UpdateState ();
	}

	public bool CheckBattle(){
		List<Mapinfo> Minfo =  MGM.GetAllMap();
		bool IsBattle = false;


		foreach (Mapinfo MIN in Minfo) {
			if (MIN.Character_C != null && MIN.Enemy_E != null) {
				if (MIN.Character_C.Count != 0 && MIN.Enemy_E.Count != 0) {
					GetBattle (MIN.Character_C, MIN.Enemy_E);
					IsBattle = true;
				}
			}
		}

		return IsBattle;
	}

	public void GetBattle(List<Character> Chara,List<Enemy> Enem){
		for (int i = 0; i < Chara.Count; i++) {
			for(int j = 0 ; j < Enem.Count;j++){
				BGM.Battle (Chara [i], Enem [i]);
			}
		}
	}

	public void JumpBack(){

	}

	public void Reset(){
		movecount = 3;
	}

}
