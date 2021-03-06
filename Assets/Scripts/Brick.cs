﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	private int timesHit;
	private LevelManager levelManager;
	public static int breakableCount = 0;
	private bool isBreakable;
	public GameObject smoke;
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
			AudioSource.PlayClipAtPoint (crack, transform.position, 0.4f);
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
		} else{
			LoadSprites();
		}
	}
	
	void PuffSmoke() {
	
		GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit -1;
		
		if (hitSprites[spriteIndex]) {
			 	
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else{
			Debug.LogError("Brick Sprite Missing");
		}
	 
	}

}
