using UnityEngine;
using System.Collections;

public class Setting : MonoBehaviour {
	
	public static int[] EnemyNum;
	public static int[] EnemySum;
	public static int[] EnemyLevel;
	public static float[] EnemyInterval;
	
	private int[] SumData;
	private float[] IntervalData;
	
	// Use this for initialization
	void Start () {
		EnemyNum = new int[]{0, 0, 0, 0, 0};
		EnemySum = new int[]{50, 50, 50, 50, 50};
		EnemyLevel = new int[]{0, 0, 1, 2, 3};
		EnemyInterval = new float[]{0.75f, 0.75f, 0.75f, 0.75f, 0.75f};
		
		SumData = new int[]{50, 50, 20, 2, 20};
		IntervalData = new float[]{0.75f, 0.5f, 1.0f, 10.0f, 0.8f};
	}
	
	// Update is called once per frame
	void Update () {
		var Num = EnemyNum[SelectPhase.NowPhase] = SelectEnemyNum.NowEnemyNum;
		EnemySum[SelectPhase.NowPhase] = SumData[Num];
		EnemyInterval[SelectPhase.NowPhase] = IntervalData[Num];
	}
}
