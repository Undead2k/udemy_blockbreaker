using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private float mousePos;
	private float clamp;
	
	
	private ball ball;
	private float ballPos;
	
	private Vector3 paddlePos; 
	
	
	
	// Use this for initialization
	void Start (){
	
		ball = GameObject.FindObjectOfType<ball>();
		paddlePos = new Vector3 (8f, this.transform.position.y, 0f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(!autoPlay){
			MoveWithMouse();
		} else {
		MoveWithBall();
		}
	}
	
	void MoveWithMouse (){
		
		mousePos = Input.mousePosition.x / Screen.width * 16;
		clamp = Mathf.Clamp(mousePos,1f,15f);
		
		paddlePos.x = clamp;
		
		this.transform.position = paddlePos;
	}
	
	void MoveWithBall(){
		
		ballPos = ball.transform.position.x;
		clamp = Mathf.Clamp(ballPos,1f,15f);
		
		paddlePos.x = clamp;
		
		this.transform.position = paddlePos;
	
	}
}

