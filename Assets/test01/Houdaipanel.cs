using UnityEngine;
using System.Collections;

public class Houdaipanel : MonoBehaviour {
	
	public GameObject Gun1;
	public GameObject Gun2;
	public GameObject Gun3;
	public GameObject Gun4;
	public GameObject Gun5;
	public GameObject Gun6;
	
	public GameObject Plate;
	
	private int point;
	
	private int HoudaiNum ;
	
	private bool ShowGUI = false;
	
	//Level GUI
	private Vector3 ObjectPoint;
    private Vector3 ObjectPointPlus;
    private Vector3 GUIScreenPoint;
	private float ScreenHeight = Screen.height;

	// Use this for initialization
	void Start () {
		HoudaiNum = GameObject.Find("Look Point").GetComponent<Player>().Num;
	}
	
	// Update is called once per frame
	void Update () {
		HoudaiNum = GameObject.Find("Look Point").GetComponent<Player>().Num;
		
		//GUI
		ObjectPoint = transform.position;
		ObjectPointPlus = new Vector3(0,0,0) + ObjectPoint;
				
		GUIScreenPoint = Camera.mainCamera.WorldToScreenPoint(ObjectPointPlus);
		//END
	}
	
	void OnMouseDown(){
		if(GameObject.Find("Look Point").GetComponent<Player>().point >= 20){
			GameObject.Find("Look Point").GetComponent<Player>().point -= 20;
			
			switch(HoudaiNum){
			case 0:
				var houdai1 = Instantiate (Gun1, transform.position, transform.rotation) as  GameObject;
				houdai1.GetComponent<Houdai>().kind = HoudaiNum;
				Instantiate(Plate, transform.position, transform.rotation);
				Destroy(this.gameObject);
				break;
			case 1:
				var houdai2 = Instantiate (Gun2, transform.position, transform.rotation) as  GameObject;
				houdai2.GetComponent<Houdai>().kind = HoudaiNum;
				Instantiate(Plate, transform.position, transform.rotation);
				Destroy(this.gameObject);
				break;
			case 2:
				var houdai3 = Instantiate (Gun3, transform.position, transform.rotation) as  GameObject;
				houdai3.GetComponent<Houdai>().kind = HoudaiNum;
				Instantiate(Plate, transform.position, transform.rotation);
				Destroy(this.gameObject);
				break;
			case 3:
				var houdai4 = Instantiate (Gun4, transform.position, transform.rotation) as  GameObject;
				houdai4.GetComponent<Houdai>().kind = HoudaiNum;
				Instantiate(Plate, transform.position, transform.rotation);
				Destroy(this.gameObject);
				break;
			case 4:
				var houdai5 = Instantiate (Gun5, transform.position, transform.rotation) as  GameObject;
				houdai5.GetComponent<Houdai>().kind = HoudaiNum;
				Instantiate(Plate, transform.position, transform.rotation);
				Destroy(this.gameObject);
				break;
			case 5:
				var houdai6 = Instantiate (Gun6, transform.position, transform.rotation) as  GameObject;
				houdai6.GetComponent<Houdai>().kind = HoudaiNum;
				Instantiate(Plate, transform.position, transform.rotation);
				Destroy(this.gameObject);
				break;
			default:
				break;
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
			GUI.TextArea(new Rect(GUIScreenPoint.x - 60, ScreenHeight - GUIScreenPoint.y + 40, 120, 40),
				"You can set Tower\nwith 20 point.");
		}
	}
}
