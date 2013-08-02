using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemysetti : MonoBehaviour {
	
	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject Enemy3;
	public GameObject Enemy4;
	public GameObject Enemy5;
	
	public TimeTable[] timetable;
	public int NowPhase;
	private const int PhaseMax = 5;
	
//	private float INTERVAL = 0.5f;
	private float timer;
	
	
	public List<GameObject> Enemies = new List<GameObject>();
	
	public struct TimeTable{
		public int EnemySum;
		public int EnemyKind;
		public int EnemyLevel;
		public float Interval;
		
		public TimeTable(int EnemySum, int EnemyKind, int EnemyLevel, float Interval){
			this.EnemySum = EnemySum;
			this.EnemyKind = EnemyKind;
			this.EnemyLevel = EnemyLevel;
			this.Interval = Interval;
		}
	}
	
	// Use this for initialization
	void Start () {
		
		//timetable
		timetable = new TimeTable[] {
			
			new TimeTable(
				Setting.EnemySum[0],
				Setting.EnemyNum[0],
				Setting.EnemyLevel[0],
				Setting.EnemyInterval[0]
				),
			
			new TimeTable(
				Setting.EnemySum[1],
				Setting.EnemyNum[1],
				Setting.EnemyLevel[1],
				Setting.EnemyInterval[1]
				),
			
			new TimeTable(
				Setting.EnemySum[2],
				Setting.EnemyNum[2],
				Setting.EnemyLevel[2],
				Setting.EnemyInterval[2]
				),
			
			new TimeTable(
				Setting.EnemySum[3],
				Setting.EnemyNum[3],
				Setting.EnemyLevel[3],
				Setting.EnemyInterval[3]
				),
			
			new TimeTable(
				Setting.EnemySum[4],
				Setting.EnemyNum[4],
				Setting.EnemyLevel[4],
				Setting.EnemyInterval[4]
				),
		};
		//end
		
		NowPhase = 0;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		
		if(timer <= 0){
			if(NowPhase == PhaseMax){
				Application.LoadLevel("GameClear");
			}
			
			else if(timetable[NowPhase].EnemySum > 0){
				AddNewEnemy(timetable[NowPhase].EnemyKind, timetable[NowPhase].EnemyLevel);
				timetable[NowPhase].EnemySum--;
				timer = timetable[NowPhase].Interval;
			}
			
			else if(timetable[NowPhase].EnemySum == 0 && GameObject.FindWithTag("Enemy") == null){
				NowPhase++;
				if(NowPhase == PhaseMax){
					timer = 0;
				}
			}
		}
	}
	
	public void AddNewEnemy(int kind, int level){
		var enemy = ReturnPrefab(kind);
		Enemies.Add(enemy);
		enemy.GetComponent<Enemy>().kind = kind;
		enemy.GetComponent<Enemy>().level = level;
	}
	
	public void RemoveEnemy(GameObject enemy){
		Enemies.Remove(enemy);
	}
	
	public GameObject ReturnPrefab(int kind){
		switch(kind){
		case 0:
			var prefab1 = Instantiate (Enemy1, transform.position, transform.rotation) as GameObject;
			return prefab1;
		case 1:
			var prefab2 = Instantiate (Enemy2, transform.position, transform.rotation) as GameObject;
			return prefab2;
		case 2:
			var prefab3 = Instantiate (Enemy3, transform.position, transform.rotation) as GameObject;
			return prefab3;
		case 3:
			var prefab4 = Instantiate (Enemy4, transform.position, transform.rotation) as GameObject;
			return prefab4;
		case 4:
			var prefab5 = Instantiate (Enemy5, transform.position, transform.rotation) as GameObject;
			return prefab5;
		default:
			var DefaultPrefab = Instantiate (Enemy1, transform.position, transform.rotation) as GameObject;
			print ("ERROR");
			return DefaultPrefab;
		}
	}
}
