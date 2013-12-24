using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class thePile : deck {

	private int pileSize = 100;

	private GameObject player1;
	private GameObject player2;
	private GameObject currPlayer;//this is who gets the cards

	public GameObject redCard;
	public GameObject blueCard;
	public GameObject purpleCard;
	public GameObject greenCard;

	public Stack<GameObject> pile = new Stack<GameObject>();
	public int size;
	// Use this for initialization
	void Start () {
		InitializeDeck();
		size = pileSize;
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

	public void SetupPlayers(GameObject inPlayer1, GameObject inPlayer2){
		player1 = inPlayer1;
		player2 = inPlayer2;
	}

	public void SetActivePlayer(GameObject player){
		currPlayer = player;
	}

	// Update is called once per frame
	void Update () {
		size = pile.Count;
	}

	[RPC]
	void Draw(){
		Debug.Log (currPlayer + " gets cards.");
		Debug.Log(pile.Pop().ToString());
		Debug.Log("Pile size: " + pile.Count);
	}

	void OnMouseDown(){
		networkView.RPC("Draw",RPCMode.All);
	}
}
