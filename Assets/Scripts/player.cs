using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	private int m_health = 100;//default HP to 100

	void TakeDamage(int damage){
		m_health -= damage;
		if(m_health <= 0){
			GameOver();
		}
	}

	void GameOver(){

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
