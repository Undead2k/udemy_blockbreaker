using UnityEngine;
using System.Collections;

public class totalbrinks : MonoBehaviour {

	public LevelManager levelManager;

	public int totalBlocks;
			
	// Update is called once per frame
	void Update () {
		
		if(totalBlocks == 18){
			levelManager.LoadLevel("Level_02");
		}
	}
	
	public void Add (){
	totalBlocks++;
	
	}
	
}
