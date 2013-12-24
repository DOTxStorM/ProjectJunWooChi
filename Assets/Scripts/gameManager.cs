using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	private GameObject player1;
	private GameObject player2;
	public GameObject centerPilePrefab;
	public GameObject networkPrefab;

	private thePile centerScript;

	public Transform option1;
	public Transform option2;
	
	//private NetworkManagerScript NMScript;

	// Use this for initialization
	void Start () {
		InstantiateAllObjects();
	}

	void InstantiateAllObjects(){
		//set up the network
		GameObject networkManagerObject = Instantiate(networkPrefab, new Vector2(0, 0), Quaternion.identity) as GameObject;
		NetworkManagerScript NMScript = networkManagerObject.GetComponent<NetworkManagerScript>();
		NMScript.SetGameManager(this);
		//GameObject currP1 = Instantiate(player1, new Vector2(0, -5), Quaternion.identity) as GameObject;
		//GameObject currP2 = Instantiate(player2, new Vector2(0, 5), Quaternion.identity) as GameObject;
		//GameObject currPile = Instantiate(centerPile, new Vector2(0, 0), Quaternion.identity) as GameObject;

		//centerScript = currPile.GetComponent<thePile>();

		//centerScript.SetupPlayers(currP1, currP2);
		//centerScript.SetActivePlayer(currP1);
	}

	public void SetPlayer(GameObject player){
		if(player.transform.position.y > 0){
			player2 = player;//assumes both players are in game now and can start game
			player2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
			Network.Instantiate(centerPilePrefab, Vector2.zero, Quaternion.identity, 0);//make the center pile
		} else{
			player1 = player;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
