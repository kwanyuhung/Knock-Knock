using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MapGM : MonoBehaviour {
	
	public enum MapType 
	{
		none,
		glass, 
		sand, 
		fire, 
		lava, 
		posion 

	}

	CharacterGM CGM;

	public GameObject OBJ_map;

	public GameObject MapBox;

	static private Dictionary<MapType, Mapinfo> characterTypesInfo;

	public int MapRange;

	public GameObject[] MapList;

	public Mapinfo[] MapinList;

	public Mapinfo[,] Mapdata;

	public int maxX;
	public int maxY;




	void setMapinfo(GameObject G, int x, int y, MapType map){
		G.name = "{ "+x+" , "+y+" }";
		G.GetComponent<Mapinfo> ().mapX = x;
		G.GetComponent<Mapinfo> ().mapY = y;

		Mapdata [x, y] = G.GetComponent<Mapinfo> ();

		G.GetComponent<Mapinfo> ().Type = RandomColor();

	}
		

	public void SelectMap(GameObject map){ //action
		foreach (Mapinfo M in MapinList) {
			if (M != null) {
				if (M.mapX == map.GetComponent<Mapinfo> ().mapX && M.mapY == map.GetComponent<Mapinfo> ().mapY) {
					moveTurn (M); // map Move
					this.gameObject.GetComponent<CharacterGM>().move (M); // character move
				}
			}
		}
	}

	public void CreateMap(int mapx, int mapy){
		maxX = mapx;
		maxY = mapy;

		float x = 0;
		float y = 0;
		int nameX = 0;
		int nameY = 0;
		OBJ_map.transform.localPosition = new Vector3 ((mapx-1)*-20f*0.5f, (mapx-1)*-20f*0.5f);

		MapRange = mapx * mapy;

		MapList = new GameObject[MapRange];
		MapinList = new Mapinfo[MapRange];
		Mapdata = new Mapinfo[mapx,mapy];


		for (int i = 0; i < MapRange; i++) {
			GameObject G =  Instantiate (OBJ_map);
			G.SetActive (true);
			G.transform.SetParent(MapBox.transform);
			G.transform.localPosition = new Vector2 (OBJ_map.transform.localPosition.x+x,OBJ_map.transform.localPosition.y+ y);
			setMapinfo (G,nameX,nameY,MapType.none);
			MapList[i] = G;
			MapinList [i] = G.GetComponent<Mapinfo> ();
			if (x < 20*(mapx-1)) {
				x += 20;
				nameX += 1;
			} else {
				x = 0;
				y += 20;
				nameX = 0;
				nameY += 1;
			}
		}
		updateColor ();
		MapBox.transform.Rotate (0, 0, 45);

	}
		
	public void moveTurn(Mapinfo M){
		MoveDelRoad (M); 
	}
		
	public List<Mapinfo> GetTopRow(Mapinfo M){
		List<Mapinfo> Map = new List<Mapinfo>();
		foreach(Mapinfo map in Mapdata){
			if (map.mapX == M.mapX && map.mapY > M.mapY && map != M) {
				Map.Add (map);
			}
		}
		return Map;
	}

	public List<Mapinfo> GetDownRow(Mapinfo M){
		List<Mapinfo> Map = new List<Mapinfo>();
		foreach(Mapinfo map in Mapdata){
			if (map.mapX == M.mapX && map.mapY < M.mapY && map != M) {
				Map.Add (map);
			}
		}
		return Map;
	}



	public List<Mapinfo> GetLeftRow(Mapinfo M){
		List<Mapinfo> Map = new List<Mapinfo>();
		foreach(Mapinfo map in Mapdata){
			if (map.mapY == M.mapY && map.mapX < M.mapX && map != M) {
				Map.Add (map);
			}
		}
		return Map;
	}

	public List<Mapinfo> GetRightRow(Mapinfo M){
		List<Mapinfo> Map = new List<Mapinfo>();
		foreach(Mapinfo map in Mapdata){
			if (map.mapY == M.mapY && map.mapX > M.mapX && map != M) {
				Map.Add (map);
			}
		}
		return Map;
	}


	public Mapinfo Gettop(Mapinfo M){
		if (CheckisOver (M.mapX, M.mapY + 1)) {
			return M; //aleardy top 
		} else {
			return Mapdata [M.mapX, M.mapY + 1];
		}
	}

	public Mapinfo Getdown(Mapinfo M){
		if (CheckisOver (M.mapX, M.mapY - 1)) {
			return M; //already down 
		} else {
			return Mapdata [M.mapX, M.mapY - 1];
		}
	}

	public Mapinfo Getleft(Mapinfo M){
		if (CheckisOver (M.mapX-1, M.mapY)) {
			return M; //already down 
		} else {
			return Mapdata [M.mapX-1, M.mapY];
		}
	}

	public Mapinfo Getright(Mapinfo M){
		if (CheckisOver (M.mapX+1, M.mapY)) {
			return M; //already down 
		} else {
			return Mapdata [M.mapX+1, M.mapY];
		}
	}


	public bool CheckisOver(int x , int y){
		if (x > 6 || x < 0 || y > 6 || x < 0) {
			return true;
		}
		return false;
	}

	void updateColor(){
		foreach(Mapinfo map in MapinList){
			if (map != null) {
				MapType M = map.Type;

				if (M != MapGM.MapType.none) {
					if (M == MapGM.MapType.fire) {
						map.gameObject.transform.GetChild (0).GetComponent<Image> ().color = Color.red;
					}
					if (M == MapGM.MapType.glass) {
						map.gameObject.transform.GetChild (0).GetComponent<Image> ().color = Color.green;
					}
					if (M == MapGM.MapType.lava) {
						map.gameObject.transform.GetChild (0).GetComponent<Image> ().color = Color.blue;
					}
					if (M == MapGM.MapType.posion) {
						map.gameObject.transform.GetChild (0).GetComponent<Image> ().color = Color.cyan;
					}
					if (M == MapGM.MapType.sand) {
						map.gameObject.transform.GetChild (0).GetComponent<Image> ().color = Color.yellow;
					}
				} else {
					map.gameObject.transform.GetChild (0).GetComponent<Image> ().color = Color.white;
				}
			}
		}
	}
		

	public MapType RandomColor(){
		
		MapType M = (MapType)Random.Range (0, System.Enum.GetValues (typeof(MapType)).Length);
		M = MapType.none;
		return M;
	}

	void MoveDelRoad(Mapinfo M){
		List<Mapinfo> Top  = GetTopRow (M);
		List<Mapinfo> Down = GetDownRow (M);
		List<Mapinfo> Left = GetLeftRow(M);
		List<Mapinfo> Right= GetRightRow(M);

		if (Top.Count != 0) {
			for (int i = 0; i < Top.Count; i++) {
				if (i + 1 != Top.Count) {
					Top [i].Type = Top [i + 1].Type;
				}
			}
			Top [Top.Count - 1].Type = RandomColor();
		}

		if (Down.Count != 0) {
			for (int i = Down.Count-1; i>=0; i--) {
				if (i- 1 >= 0) {
					Down [i].Type = Down [i-1].Type;
				}
			}
			Down [0].Type = RandomColor();
		}
		if (Left.Count != 0) {
			for (int i = Left.Count-1; i >=0; i--) {
				if (i- 1 >= 0) {
					Left [i].Type = Left [i - 1].Type;
				}
			}
			Left [0].Type = RandomColor();
		}
		if (Right.Count != 0) {
			for (int i = 0; i < Right.Count; i++) {
				if (i + 1 != Right.Count) {
					Right [i].Type = Right [i + 1].Type;
				}
			}
			Right [Right.Count - 1].Type = RandomColor();
		}
		updateColor ();
	}
		
	public Mapinfo getmap(int x, int y){
		Mapinfo m = Mapdata [x, y];
		return m;
	}

	public int GetmaxX(){
		return maxX;
	}

	public int GetmaxY(){
		return maxY;
	}
}
