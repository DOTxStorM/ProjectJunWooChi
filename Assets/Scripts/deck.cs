using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class deck : MonoBehaviour {
	
	protected void Shuffle(GameObject[] currDeck){
		for(int i = 0; i < currDeck.Length; ++i){
			int rand = (int)Random.Range(0, currDeck.Length);

			GameObject temp = currDeck[i];
			currDeck[i] = currDeck[rand];
			currDeck[rand] = temp;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
