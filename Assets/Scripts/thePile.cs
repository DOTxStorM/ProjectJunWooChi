using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class thePile : deck {

	private int pileSize = 100;

	public GameObject redCard;
	public GameObject blueCard;
	public GameObject purpleCard;
	public GameObject greenCard;

	public Stack<GameObject> pile = new Stack<GameObject>();



	// Use this for initialization
	void Start () {
		InitializeDeck();
	}

	void InitializeDeck(){		
		GameObject[] initPile = new GameObject[pileSize];
		
		for(int i = 0; i < pileSize; ++i){
			if(i < 25){
				initPile[i] = redCard;
			} else if(i < 50){
				initPile[i] = blueCard;
			} else if(i < 75){
				initPile[i] = greenCard;
			} else{
				initPile[i] = purpleCard;
			}
		}
		
		Shuffle(initPile);
		
		for(int i = 0; i < pileSize; ++i){
			pile.Push(initPile[i]);
		}
	}



	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		Debug.Log ("Draw Cards");
	}
}
