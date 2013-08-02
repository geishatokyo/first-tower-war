using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	private int[,] HP;
	private float[,] SPEED;
	private int[,] DEFENCE;
	private int[,] GETPOINT;
	
	public int level;
	public int kind;
	
	private Vector3[] movepath;
	
	private Vector3 prev;
	
	//Explosion Particle
	public GameObject Explosion;
	
	// Use this for initialization
	void Start () {
		SetDirection();
		prev = transform.position;
		
		HP = new int[,]{
			{70, 80, 90, 100},
			{50, 60, 80, 100},
			{100, 200, 300, 1000},
			{500, 1000, 3000, 6000},
			{5, 8, 11, 14},
		};
		
		SPEED = new float[,] {
			{3.0f, 3.0f, 4.0f, 6.0f},
			{10.0f, 10.0f, 15.0f, 20.0f},
			{3.0f, 3.0f, 4.0f, 5.0f},
			{2.0f, 2.0f, 2.0f, 2.0f},
			{7.0f, 8.0f, 9.0f, 10.0f},
		};
		
		DEFENCE = new int[,]{
			{0, 0, 0, 0},
			{0, 0, 0, 0},
			{0, 0, 0, 0},
			{0, 0, 0, 0},
			{50, 60, 300, 10000},
		};
		
		GETPOINT = new int[,]{
			{2, 3, 4, 5},
			{1, 1, 2, 2},
			{5, 10, 15, 20},
			{20, 50, 100, 200},
			{1, 2, 4, 5},
		};

		movepath = new Vector3[]{
			new Vector3(-20, 0, 16),
			new Vector3(13, 0, 16),
			new Vector3(13, 0, 8),
			new Vector3(-13, 0, 8),
			new Vector3(-13, 0, 0),
			new Vector3(13, 0, 0),
			new Vector3(13, 0, -8),
			new Vector3(-13, 0, -8),
			new Vector3(-13, 0, -16),
			new Vector3(20, 0, -16),
		};
		
		iTween.MoveTo(this.gameObject, iTween.Hash(
			"path", movepath,
			"speed", SPEED[kind, level], 
			"easetype", iTween.EaseType.linear,
			"oncomplete", "CompleteHandler"));
	}
	
	// Update is called once per frame
	void Update () {
		var diff = transform.position - prev;
		if(diff.magnitude > 0.01){
			transform.rotation = Quaternion.LookRotation(diff);	
		}
		prev = transform.position;
		
		SetDirection();
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Dangan"){ 
			//damaged
			HP[kind, level] -= SetDamage(other.GetComponent<Dangan>().damage);
			
			//if killed
			if(HP[kind, level] <= 0){
				GameObject.Find("Enemy Setti").GetComponent<Enemysetti>().RemoveEnemy(this.gameObject);
				Destroy(this.gameObject);
				GameObject.Find("Look Point").GetComponent<Player>().point += GETPOINT[kind, level];
				
				//Explosion
				Instantiate (Explosion, transform.position, transform.rotation);
			}
			Destroy(other.gameObject);
		}
		
	}
	
	//compelete tween
	void CompleteHandler(){
		Destroy (this.gameObject);
		Player.Life--;
		if(Player.Life <= 0){
			Application.LoadLevel("GameOver");	
		}
	}
	
	//calculate damage
	int SetDamage(int DefaultDamage){
		int damage;
		damage = DefaultDamage - DEFENCE[kind, level];
		if(damage <= 0) damage = 1;
		return damage;
	}
	
	void SetDirection(){
		if(kind == 2) transform.Rotate(-90, 0, 0);	
	}
}
