using UnityEngine;
using System.Collections;


public class Houdai : MonoBehaviour {
	
	public GameObject prefab;
	
	public int level;
	public int kind;
	
	//show GUI
	private bool ShowGUI = false;
	
	//Level GUI
	private Vector3 ObjectPoint;
    private Vector3 ObjectPointPlus;
    private Vector3 GUIScreenPoint;
	private float ScreenHeight = Screen.height;
	
	//Houdai status
	private float[,] INTERVAL;
	private int[,] POWER;
	private float[,] RANGE;
	private float[,] SPEED;
	private int[,] COST;
	
	private float timer;
	
	public Enemysetti enemyContainer;
	
	// Use this for initialization
	void Start () {
		SetDirection();
		
		INTERVAL = new float[,]{
			{1.0f, 0.9f, 0.8f, 0.7f, 0.5f},
			{0.4f, 0.4f, 0.2f, 0.2f, 0.1f},
			{2.0f, 2.0f, 3.0f, 3.0f, 5.0f},
			{0.1f, 0, 0, 0, 0},
			{1.0f, 1.0f, 1.0f, 1.0f, 0.5f},
			{3.0f, 2.5f, 2.5f, 2.0f, 2.0f},
		};
		
		POWER = new int[,]{
			{50, 60, 80, 90, 100},
			{20, 25, 30, 35, 35},
			{70, 100, 150, 200, 600},
			{1, 0, 0, 0, 0},
			{10, 10, 10, 10, 100},
			{60, 80, 100, 120, 150},
		};
		
		RANGE = new float[,]{
			{10, 10, 15, 15, 15},
			{10, 10, 10, 15, 15},
			{10, 15, 15, 15, 20},
			{10, 0, 0, 0, 0},
			{10, 10, 10, 10, 100},
			{100, 100, 100, 100, 100},
		};
		
		SPEED = new float[,]{
			{0.5f, 0.5f, 0.5f, 0.5f, 0.5f},	
			{0.5f, 0.5f, 0.5f, 0.5f, 0.5f},
			{0.5f, 0.5f, 0.5f, 0.5f, 0.5f},
			{0.5f, 0, 0, 0, 0},
			{0.5f, 0.5f, 0.5f, 0.5f, 0.5f},
			{0.5f, 0.5f, 0.5f, 0.5f, 0.5f},
		};
		
		COST = new int[,]{
			{10, 20, 30, 40, -1},	
			{15, 25, 35, 45, -1},
			{20, 25, 35, 50, -1},
			{-1, -1, -1, -1, -1},
			{5, 5, 10, 80, -1},
			{20, 25, 30, 50, -1},
		};
		
		timer = 0;
		enemyContainer = GameObject.Find("Enemy Setti").GetComponent<Enemysetti>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//GUI
		ObjectPoint = transform.position;
		ObjectPointPlus = new Vector3(0,0,0) + ObjectPoint;
				
		GUIScreenPoint = Camera.mainCamera.WorldToScreenPoint(ObjectPointPlus);
		//END
		
		
		if(timer > 0) timer -= Time.deltaTime;
		
		if(timer <= 0){
			var target = FindTarget();
			if(target != null){
				transform.LookAt(target.transform);
				SetDirection();
				ShotTo(target);
				timer = INTERVAL[kind, level];
			}
		}
	}
	
	void OnMouseDown(){
		if(level < 4){
			//強化できない砲台
			if(COST[kind, level] < 0){
				print ("This Object cannot strengthening.");	
			}
			
			else if(GameObject.Find("Look Point").GetComponent<Player>().point >= COST[kind, level]){
				GameObject.Find("Look Point").GetComponent<Player>().point -= COST[kind, level];
				level++;
				timer = 0;
			}
		}
	}
	
	void OnMouseEnter(){
		ShowGUI = true;
	}
	
	void OnMouseExit(){
		ShowGUI = false;
	}
	
	void OnGUI () {
		if(ShowGUI){
			string LevelString = "Level : " + (level + 1).ToString() + "\n";
			string CostString;
			
			if(COST[kind, level] < 0) CostString = "No Next Level";
			else CostString = "Next Level : " + COST[kind, level].ToString();
			
			GUI.TextArea(new Rect(GUIScreenPoint.x - 60, ScreenHeight - GUIScreenPoint.y + 40, 120, 40),
				LevelString + CostString);
		}
	}
	
	void ShotTo(GameObject target){
		var obj = Instantiate (prefab, transform.position, transform.rotation) as GameObject;
		obj.GetComponent<Dangan>().damage = POWER[kind, level];
		obj.GetComponent<Dangan>().speed = SPEED[kind, level];
		obj.transform.position = this.transform.position;
		obj.GetComponent<Dangan>().SetTarget(target);
	}
	
	GameObject FindTarget(){
		var pos = transform.position;
		var distanceSq = RANGE[kind, level] * RANGE[kind, level];
		GameObject target = null;
		foreach(var enemy in enemyContainer.Enemies){
				if(enemy != null){
				var l = (enemy.transform.position - pos).sqrMagnitude;
				if(l < distanceSq){
					distanceSq = l;
					target = enemy;
					break;
				}
			}
		}
		return target;
	}
	
	void SetDirection(){
		if(kind == 0) transform.Rotate(-90, 0, 0);
		if(kind == 1) transform.Rotate(-90, 0, 0);
		if(kind == 2) transform.Rotate(90, 0, 0);
		if(kind == 4) transform.Rotate(0, 180, 0);
		if(kind == 5) transform.Rotate(0, -90, 0);
	}
}
