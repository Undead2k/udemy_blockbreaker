using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	private float crackVolume = 0.03f;
	
	
	public SpriteRenderer blockColour;
	public Sprite[] hitSprites;
	
	public static int breakableCount = 0;
	
	private LevelManager levelManager;
	private int timesHit;
	private int maxHits;
	private bool isBreakable;
	
	
	// Use this for initialization
	void Start () {

		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
		isBreakable = (this.tag == "Breakable");
		if (isBreakable){
			breakableCount++;
			print(breakableCount);
		}
		
		blockColour = GetComponent<SpriteRenderer>();
		
		
		timesHit = 0;
		maxHits = hitSprites.Length +1;
		
		SetColours();
		
		
		
	}
	
	void Update () {
	}
	
	void OnCollisionEnter2D(Collision2D hit){
		if(isBreakable){
			HandleHits();
		}	
	}
	
	void HandleHits(){
		AudioSource.PlayClipAtPoint (crack, transform.position, crackVolume);
	
		timesHit++;
		print("HIT");
		
		if (timesHit >= maxHits){
			print ("boom");
			breakableCount--;
			print (breakableCount);
			levelManager.BrickDestroyed();
			Destroy(gameObject);
			
			
		} else {
			LoadSprites();
			SetColours();
		}			
	
	}
	
	void LoadSprites(){
		
		int spriteIndex = timesHit -1;
		
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];		
		}
	}
	
	void SetColours(){
		
		if(isBreakable == false){
			this.blockColour.color = new Color(255f, 255f, 255f, 1f);
		} else {
		
		if(timesHit == maxHits/2) {
			//middle hit
			this.blockColour.color = new Color(255f, 255f, 0f, 1f);
		}
		
		if(timesHit == maxHits - 2) {
			//second to last hit, yellow
			this.blockColour.color = new Color(255f, 255f, 0f, 1f);
		}
		
		if(timesHit == maxHits - 1){
			//last hit
			this.blockColour.color = new Color(255f, 0f, 0f, 1f);
		}
	}
		
	}
	
	void SimulateWin(){
		levelManager.LoadNextLevel();	
	}
}
