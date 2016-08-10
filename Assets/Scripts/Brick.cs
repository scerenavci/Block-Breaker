﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	private int timesHit;
	private LevelManager levelManager;
	public static int breakableCount = 0;
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		
		if (isBreakable) {
			breakableCount++;
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D col){
		
		if (isBreakable) {
			HandleHits();
		}		
	}
	
	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			Debug.Log(breakableCount);
			AudioSource.PlayClipAtPoint (crack, transform.position, 0.4f);
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else{
			LoadSprites();
		}
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit -1;
		
		if (hitSprites[spriteIndex]) {
			 	
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	 
	}

}
