using UnityEngine;
using System.Collections;

public class Dangan : MonoBehaviour {
	
	private Transform target;
	public float speed;
	
	public int damage;
	
	Vector3 tmpDirection;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null){
			var direction = (target.position - transform.position).normalized * speed;
			tmpDirection = direction;
			
			transform.position += direction;
			
			if(Mathf.Abs(transform.position.x) > 22 || Mathf.Abs (transform.position.z) > 22){
				Destroy(this.gameObject);	
			}
		}
		
		else if(target == null){
			transform.position += tmpDirection;
			
			if(Mathf.Abs(transform.position.x) > 22 || Mathf.Abs (transform.position.z) > 22){
				Destroy(this.gameObject);	
			}
		}
	}
	
	public void SetTarget(GameObject target){
		this.target = target.transform;
		transform.LookAt (this.target);
	}
}
