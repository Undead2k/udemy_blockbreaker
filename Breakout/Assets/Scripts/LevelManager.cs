using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	

	public void LoadLevel(string name){
		print("Level load requested for: "+name);
		Application.LoadLevel(name);
	
	}
	
	public void QuitRequest(){
		print("quit request");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
}
