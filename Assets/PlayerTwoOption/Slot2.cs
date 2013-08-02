using UnityEngine;
using System.Collections;

public class Slot2 : MonoBehaviour {
	public static int SelectNum;
	public static string SelectName;
	
	// Use this for initialization
	void Start () {
		SelectNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		TextAsset Text2;
		
		switch(SelectNum){
		case 0:
			Text2 = Resources.Load("TextHoudai1") as TextAsset;
			GameObject.Find("TextSlot2").GetComponent<UILabel>().text = Text2.text;
			break;
		case 1:
			Text2 = Resources.Load("TextHoudai2") as TextAsset;
			GameObject.Find("TextSlot2").GetComponent<UILabel>().text = Text2.text;
			break;
		case 2:
			Text2 = Resources.Load("TextHoudai3") as TextAsset;
			GameObject.Find("TextSlot2").GetComponent<UILabel>().text = Text2.text;
			break;
		case 3:
			Text2 = Resources.Load("TextHoudai4") as TextAsset;
			GameObject.Find("TextSlot2").GetComponent<UILabel>().text = Text2.text;
			break;
		case 4:
			Text2 = Resources.Load("TextHoudai5") as TextAsset;
			GameObject.Find("TextSlot2").GetComponent<UILabel>().text = Text2.text;
			break;
		case 5:
			Text2 = Resources.Load("TextHoudai6") as TextAsset;
			GameObject.Find("TextSlot2").GetComponent<UILabel>().text = Text2.text;
			break;
		default:
			break;
		}
	}
	
	void OnSelectionChange(string val){
		switch(val){
		case "Normal Gun":
			SelectNum = 0;
			SelectName = "Normal";
			break;
		case "Fast Gun":
			SelectNum = 1;
			SelectName = "Fast";
			break;
		case "Heavy Gun":
			SelectNum = 2;
			SelectName = "Heavy";
			break;
		case "Pulse Gun":
			SelectNum = 3;
			SelectName = "Pulse";
			break;
		case "Ultimate Gun":
			SelectNum = 4;
			SelectName = "Ultimate";
			break;
		case "Sniper Gun":
			SelectNum = 5;
			SelectName = "Sniper";
			break;
		default:
			break;
		}
	}
}
