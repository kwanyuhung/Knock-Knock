using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemInfo : MonoBehaviour {

	public int X;
	public int Y;

	public Mapinfo Myposition = null;

	public Enemy me = null;

	public void Add(int X_,int Y_, Mapinfo Myposition_,Enemy me_){
		this.X = X_;
		this.Y = Y_;
		this.Myposition = Myposition_;
		this.me = me_;
	}
}
