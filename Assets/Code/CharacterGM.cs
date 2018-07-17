using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharacterGM : MonoBehaviour {

	public MapGM MGM;
	public BattleGM BGM;
	public DropBoxUI DBUI;

	  public GameObject Camera;

	public List<Character> characterlist = new List<Character>();
	public List<Enemy> Enemy = new List<Enemy> ();

	public GameObject OBJ_Character;

	public List<Chainfo> Cha_info;
	public List<EnemInfo> Ene_info;

	int BeforeX;
	int BeforeY;

	public void DropCharacter(){

	}
		
	public void Addchararcter(Character C, int x, int y ){
		Mapinfo map = MGM.getmap (x,y);
		//AddCharacterDropBox (C);
		ADDCharacterToMap (C, map);
	}

	public void Addchararcter(Enemy E, int x, int y ){
		Mapinfo map = MGM.getmap (x,y);
		ADDCharacterToMap (E, map);
	}
		
	public void ADDCharacterToMap(Character C_, Mapinfo M){
		M.Character_C.Add(C_);
		characterlist.Add (C_);
		CreateCharacterOnMap (C_, M);
		updateCharacterBox ();
	}

	public void ADDCharacterToMap(Enemy E_, Mapinfo M){
		M.Enemy_E.Add(E_);
		Enemy.Add (E_);
		CreateCharacterOnMap (E_, M);
	}

		
	public void CreateCharacterOnMap(Character C_, Mapinfo M){
		string number = C_.ID.ToString();
		Sprite icon = Resources.Load <Sprite> ("icon/Character_"+number);
		GameObject G = Instantiate (OBJ_Character, Camera.transform);
		G.transform.position = new Vector3 (M.transform.position.x, M.transform.position.y, 0.0f);
		G.AddComponent<Chainfo> ();
		G.GetComponent<Chainfo> ().Add(M.mapX,M.mapY,M,C_);
		Cha_info.Add (G.GetComponent<Chainfo> ());
		Image Img = G.GetComponent<Image> ();
		Img.sprite = icon;
	}

	public void CreateCharacterOnMap(Enemy E_, Mapinfo M){
		string number = E_.ID.ToString();
		Sprite icon = Resources.Load <Sprite> ("icon/Character_"+number);
		GameObject G = Instantiate (OBJ_Character, Camera.transform);
		G.transform.position = new Vector3 (M.transform.position.x, M.transform.position.y, 0.0f);
		G.AddComponent<EnemInfo> ();
		G.GetComponent<EnemInfo> ().Add(M.mapX,M.mapY,M,E_);
		Ene_info.Add (G.GetComponent<EnemInfo> ());
		Image Img = G.GetComponent<Image> ();
		Img.sprite = icon;
	}




	public void move(Mapinfo M){
		//if(gm.Turn == GM.GameState.)
		MovePlayer(M);
		MoveEnemy (M);
	}

	public void MovePlayer(Mapinfo M){
		List<Chainfo> Top = GetTopRow_Character (M);
		List<Chainfo> Down = GetDownRow_Character (M);
		List<Chainfo> Left = GetLeftRow_Character (M);
		List<Chainfo> Right = GetRightRow_Character (M);

		if (Top.Count != 0) {
			for (int i = 0; i < Top.Count; i++) {
				if (Top [i].me != null) {
					if (Top [i].Y > 0) {
						updateMap (Top [i]);
						Top [i].Y -= 1;
						Updatemove (Top [i]);
					}
				}
			}
		}
		if (Down.Count != 0) {
			for (int i = 0; i < Down.Count; i++) {
				if (Down [i].me != null) {
					if (Down [i].Y < MGM.GetmaxY ()) {
						updateMap (Down [i]);
						Down [i].Y += 1;
						Updatemove (Down [i]);
					}
				}
			}
		}
		if (Left.Count != 0) {
			for (int i = 0; i < Left.Count; i++) {
				if (Left [i].me != null) {
					if (Left [i].X < MGM.GetmaxX ()) {
						updateMap (Left [i]);
						Left [i].X += 1;
						Updatemove (Left [i]);		
					}
				}
			}
		}

		if (Right.Count != 0) {
			for (int i = 0; i < Right.Count; i++) {
				if (Right [i].me != null) {
					if (Right [i].X > 0) {
						updateMap (Right [i]);
						Right [i].X -= 1;
						Updatemove (Right [i]);	
					}
				}
			}
		}
	}
	public void MoveEnemy(Mapinfo M){
		List<EnemInfo> Top_E = GetTopRow_CharacterE (M);
		List<EnemInfo> Down_E = GetDownRow_CharacterE (M);
		List<EnemInfo> Left_E = GetLeftRow_CharacterE (M);
		List<EnemInfo> Right_E = GetRightRow_CharacterE (M);
		//enemy 
		if (Top_E.Count != 0) {
			for (int i = 0; i < Top_E.Count; i++) {
				if (Top_E [i].me != null) {
					if (Top_E [i].Y > 0) {
						updateMap (Top_E [i]);
						Top_E [i].Y -= 1;
						Updatemove (Top_E [i]);
					}
				}
			}
		}
		if (Down_E.Count != 0) {
			for (int i = 0; i < Down_E.Count; i++) {
				if (Down_E [i].me != null) {
					if (Down_E [i].Y < MGM.GetmaxY ()) {
						updateMap (Down_E [i]);
						Down_E [i].Y += 1;
						Updatemove (Down_E [i]);
					}
				}
			}
		}
		if (Left_E.Count != 0) {
			for (int i = 0; i < Left_E.Count; i++) {
				if (Left_E [i].me != null) {
					if (Left_E [i].X < MGM.GetmaxX ()) {
						updateMap (Left_E [i]);
						Left_E [i].X += 1;
						Updatemove (Left_E [i]);		
					}
				}
			}
		}
		if (Right_E.Count != 0) {
			for (int i = 0; i < Right_E.Count; i++) {
				if (Right_E [i].me != null) {
					if (Right_E [i].X > 0) {
						updateMap (Right_E [i]);
						Right_E [i].X -= 1;
						Updatemove (Right_E [i]);	
					}
				}
			}
		}
	}

	public List<Chainfo> GetTopRow_Character(Mapinfo M){
		List<Mapinfo> m = MGM.GetTopRow (M);
		return CheckInRange_Character (m);
	}
	public List<Chainfo> GetDownRow_Character(Mapinfo M){
		List<Mapinfo> m = MGM.GetDownRow (M);
		return CheckInRange_Character (m);
	}

	public List<Chainfo> GetLeftRow_Character(Mapinfo M){
		List<Mapinfo> m = MGM.GetLeftRow (M);
		return CheckInRange_Character (m);
	}

	public List<Chainfo> GetRightRow_Character(Mapinfo M){
		List<Mapinfo> m = MGM.GetRightRow (M);
		return CheckInRange_Character (m);
	}

	// EmeInfo

	public List<EnemInfo> GetTopRow_CharacterE(Mapinfo M){
		List<Mapinfo> m = MGM.GetTopRow (M);
		return CheckInRange_CharacterE (m);
	}

	public List<EnemInfo> GetDownRow_CharacterE(Mapinfo M){
		List<Mapinfo> m = MGM.GetDownRow (M);
		return CheckInRange_CharacterE (m);
	}

	public List<EnemInfo> GetLeftRow_CharacterE(Mapinfo M){
		List<Mapinfo> m = MGM.GetLeftRow (M);
		return CheckInRange_CharacterE (m);
	}

	public List<EnemInfo> GetRightRow_CharacterE(Mapinfo M){
		List<Mapinfo> m = MGM.GetRightRow (M);
		return CheckInRange_CharacterE (m);
	}

	public List<Chainfo> CheckInRange_Character(List<Mapinfo> MList){
		List<Chainfo> CINFO = new List<Chainfo> ();
		foreach (Mapinfo info in MList) {
			if (info.Character_C != null) {
				foreach (Chainfo cinfo in Cha_info) {
					if (info.Character_C.Contains (cinfo.me)) {
						CINFO.Add (cinfo);
					}
				}
			}
		}
		return CINFO;
	}

	public List<EnemInfo> CheckInRange_CharacterE(List<Mapinfo> MList){
		List<EnemInfo> EINFO = new List<EnemInfo> ();
		foreach (Mapinfo info in MList) {
			if (info.Enemy_E != null) {
				foreach (EnemInfo Einfo in Ene_info) {
					if (info.Enemy_E.Contains(Einfo.me)) {
						EINFO.Add (Einfo);
					}
				}
			}
		}
		return EINFO;
	}

	public List<EnemInfo> CheckInRange_Enemy(List<Mapinfo> MList){
		List<EnemInfo> EINFO = new List<EnemInfo> ();
		foreach (Mapinfo info in MList) {
			if (info.Enemy_E != null) {
				foreach (EnemInfo Einfo in Ene_info) {
					if (info.Enemy_E.Contains(Einfo.me)) {
						EINFO.Add (Einfo);
					}
				}
			}

		}
		return EINFO;
	}


	public void Updatemove(Chainfo C){
		Mapinfo M = MGM.getmap (C.X, C.Y);
		M.Character_C.Add(C.me);
		Vector3 V = M.gameObject.transform.position;
		C.gameObject.transform.position = V;
		C.Myposition = M;
	}

	public void Updatemove(EnemInfo E){
		Mapinfo M = MGM.getmap (E.X, E.Y);
		M.Enemy_E.Add(E.me);
		Vector3 V = M.gameObject.transform.position;
		E.gameObject.transform.position = V;
		E.Myposition = M;
	}

	public void updateMap(Chainfo C){ // use to set map 
		Mapinfo M = MGM.getmap (C.X, C.Y);
		if (M.Character_C.Contains (C.me)) {
			M.Character_C.Remove (C.me);
		}
	}

	public void updateMap(EnemInfo C){
		Mapinfo M = MGM.getmap (C.X, C.Y);
		if (M.Enemy_E.Contains (C.me)) {
			M.Enemy_E.Remove (C.me);
		}
	}

	public void AddCharacterDropBox(List<Character> c){
		//test 
		DBUI.CreateBox (c);
	}

	public void updateCharacterBox(){
		DBUI.updateBox ();
	}
}
