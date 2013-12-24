using UnityEngine;
using System.Collections;

public class NetworkManagerScript : MonoBehaviour {
	//http://www.paladinstudios.com/2013/07/10/how-to-create-an-online-multiplayer-game-with-unity/
	private float btnX;
	private float btnY;
	private float btnW;
	private float btnH;

	private string typeName = "JunWooChi";
	private string gameName = "testRoom1";

	private HostData[] hostList;

	private gameManager currGameManagerScript;

	public GameObject playerPrefab;
	//public GameObject centerPilePrefab;


	// Use this for initialization
	void Start () {
		btnX = Screen.width * 0.05f;
		btnY = Screen.width * 0.05f;
		btnW = Screen.width * 0.1f;
		btnH = Screen.width * 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetGameManager(gameManager currGM){
		currGameManagerScript = currGM;
	}

	void SpawnPlayer(int sign){
		GameObject player = Network.Instantiate(playerPrefab, new Vector2(0, 5 * sign), Quaternion.identity, 0) as GameObject;
		currGameManagerScript.SetPlayer(player);
	}

	void StartServer(){
		Network.InitializeServer(2, 25001, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);
	}

	void RefreshHostList(){
		MasterServer.RequestHostList(typeName);
	}

	void JoinServer(HostData hostData){
		Network.Connect(hostData);
	}

	void OnServerInitialized(){
		Debug.Log("Server Initialized");
		SpawnPlayer(-1);
		Debug.Log("Player spawned");
		//Network.Instantiate(centerPilePrefab, Vector2.zero, Quaternion.identity, 0);
	}

	void OnConnectedToServer(){
		Debug.Log("Joined Server");
		SpawnPlayer(1);
		Debug.Log("Player spawned");
	}

	void OnMasterServerEvent(MasterServerEvent mse){
		if(mse == MasterServerEvent.RegistrationSucceeded){
			Debug.Log("Registrated Server");
		} else if(mse == MasterServerEvent.HostListReceived){
			hostList = MasterServer.PollHostList();
			Debug.Log(hostList.Length);
		}
	}

	void OnGUI(){
		if(!Network.isClient && !Network.isServer){//seeing if user is neither a server nor a client
			if(GUI.Button(new Rect(btnX, btnY, btnW, btnH),"Start Server")){
				Debug.Log("Starting Server");
				StartServer();
			}
		
			if(GUI.Button(new Rect(btnX, btnY * 1.2f + btnH, btnW, btnH),"Refresh Host")){
				Debug.Log("Refresh Host");
				RefreshHostList();
			}

			if(hostList != null){
				for(int i = 0; i < hostList.Length; ++i){
					if(GUI.Button (new Rect(btnX * 1.2f + btnW, btnY * 1.2f + (btnH * i), btnW, btnH), hostList[i].gameName)){
						JoinServer (hostList[i]);
					}
				}
			}
		}
	}
}
