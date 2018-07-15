using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {


	public enum GameState
	{
		NewTurn, //0
		BeforeStart,
		Start,
		BeforeJump,
		Jump,
		AfterJump,
		SkillTurn,
		BeforeMove,
		move,
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
		
	public GameState G = GameState.NewTurn;

	public GameState Turn {get { return G;}}

	public MapGM MGM;
	public CharacterGM CGM;

	public Text LOG;

	public void UpdateState(){
		if (G == GameState.NewTurn) {
			G+=1;
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
	}
		
	void updateText(){
		LOG.text = G.ToString();
	}

	public void Start(){
		UpdateState ();
	}
}
