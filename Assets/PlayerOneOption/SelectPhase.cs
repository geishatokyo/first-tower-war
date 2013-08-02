using UnityEngine;
using System.Collections;

public class SelectPhase : MonoBehaviour {
	
	public static int NowPhase;
	
	// Use this for initialization
	void Start () {
		NowPhase = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnSelectionChange(string val){
		switch(val){
		case "Phase 1":
			NowPhase = 0;
			break;
			
		case "Phase 2":
			NowPhase = 1;
			break;
			
		case "Phase 3":
			NowPhase = 2;
			break;
			
		case "Phase 4":
			NowPhase = 3;
			break;
			
		case "Phase 5":
			NowPhase = 4;
			break;
			
		default:
			break;
		}
	}
}
