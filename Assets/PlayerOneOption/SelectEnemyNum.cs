using UnityEngine;
using System.Collections;

public class SelectEnemyNum : MonoBehaviour {

//	private int NowPhase;
	public static int NowEnemyNum;
	
	// Use this for initialization
	void Start () {
		NowEnemyNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		TextAsset Text;
		
		switch(NowEnemyNum){
		case 0:
			Text = Resources.Load("TextEnemy1") as TextAsset;
			GameObject.Find("TextEnemy").GetComponent<UILabel>().text = Text.text;
			break;
		case 1:
			Text = Resources.Load("TextEnemy2") as TextAsset;
			GameObject.Find("TextEnemy").GetComponent<UILabel>().text = Text.text;
			break;
		case 2:
			Text = Resources.Load("TextEnemy3") as TextAsset;
			GameObject.Find("TextEnemy").GetComponent<UILabel>().text = Text.text;
			break;
		case 3:
			Text = Resources.Load("TextEnemy4") as TextAsset;
			GameObject.Find("TextEnemy").GetComponent<UILabel>().text = Text.text;
			break;
		case 4:
			Text = Resources.Load("TextEnemy5") as TextAsset;
			GameObject.Find("TextEnemy").GetComponent<UILabel>().text = Text.text;
			break;
		default:
			break;
		}
	}
	
	void OnSelectionChange(string val){
		switch(val){
		case "Normal":
			NowEnemyNum = 0;
			break;
			
		case "Fast":
			NowEnemyNum = 1;
			break;
			
		case "Heavy":
			NowEnemyNum = 2;
			break;
			
		case "Boss":
			NowEnemyNum = 3;
			break;
			
		case "Shield":
			NowEnemyNum = 4;
			break;
			
		default:
			break;
		}
	}
}
