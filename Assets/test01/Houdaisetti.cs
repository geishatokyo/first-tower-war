using UnityEngine;
using System.Collections;

public class Houdaisetti : MonoBehaviour {
	
	public GameObject prefab;
	
	private int[,] HoudaiOnOff;
	
	// Use this for initialization
	void Start () {
		HoudaiOnOff = new int[,]{
			{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
			{1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
			{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
			{1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
			{1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
			{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
			{1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
		};
		
		int x, z;
		
		for(z=20; z>=-20; z-=4){
			for(x=-20; x<=20; x+=4){
				if(HoudaiOnOff[ (z-20)/(-4) , (x+20)/4 ] == 1){
					Instantiate(prefab, new Vector3(x, 0, z), transform.rotation);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
