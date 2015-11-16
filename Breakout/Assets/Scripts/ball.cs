﻿using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {

	private Paddle paddle;
			
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
	
	//private Vector2 tweak;


	// Use this for initialization
	void Start () {
	
	paddle = GameObject.FindObjectOfType<Paddle>();
	
	paddleToBallVector = this.transform.position - paddle.transform.position;
		
	//tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
	
	}
	
	// Update is called once per frame
	void Update () {
	if (!hasStarted){
		this.transform.position = paddle.transform.position + paddleToBallVector;
		}
	
		if(Input.GetMouseButtonDown(0)){
			
			hasStarted = true;
			this.rigidbody2D.velocity = new Vector2(2f, 10f);
			
		
		}
	
	}
	

	void OnCollisionEnter2D(Collision2D hit){
	
	
	
	if(hasStarted){
		audio.Play();
		
		//rigidbody2D.velocity += tweak;
		
		}
	}
	
	
	
}
