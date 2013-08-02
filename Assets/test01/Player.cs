using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	private const float speed = 0.2f;
	public static int Life = 3;
	
	public int point;
	
	private int[] SelectNums = {Slot1.SelectNum, Slot2.SelectNum,Slot3.SelectNum};
	private int toolbarInt = 0;
	public int Num;
	private string[] toolbarStrings = {Slot1.SelectName, Slot2.SelectName, Slot3.SelectName};
	
	// Use this for initialization
	void Start () {
		point = 40;
		Num = SelectNums[toolbarInt];
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(Input.GetAxis("Horizontal")*speed, 0, Input.GetAxis("Vertical")*speed);
	}
	
	void OnGUI () {
		toolbarInt = GUI.Toolbar (new Rect (0, 0, 250, 30), toolbarInt, toolbarStrings);
		Num = SelectNums[toolbarInt];
		GUI.TextArea(new Rect(Screen.width-100, 0, 100, 40),
			"POINT : " + point.ToString() 
			+"\n" + "LIFE : " + Life.ToString() );
	}
}
