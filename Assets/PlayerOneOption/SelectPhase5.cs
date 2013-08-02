using UnityEngine;
using System.Collections;

public class SelectPhase5 : MonoBehaviour {
	
	public static int EnemyNum;
	public static float Interval;
	public static int EnemySum;

	// Use this for initialization
	void Start () {
		EnemyNum = 0;
		Interval = 0.5f;
		EnemySum = 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnSelectionChange(string val){
		switch(val){
		case "Normal":
			EnemyNum = 0;
			Interval = 0.5f;
			EnemySum = 50;
			break;
		case "Fast":
			EnemyNum  = 1;
			Interval = 0.2f;
			EnemySum = 50;
			break;
		case "Heavy":
			EnemyNum = 2;
			Interval = 1.0f;
			EnemySum = 20;
			break;
		case "Boss":
			EnemyNum = 3;
			Interval = 10.0f;
			EnemySum = 2;
			break;
		case "Shield":
			EnemyNum = 4;
			Interval = 0.5f;
			EnemySum = 20;
			break;
		default:
			break;
		}
	}
}
