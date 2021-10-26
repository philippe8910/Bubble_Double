using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEditor;
using UnityEngine;

public class NetworkManagerUH : NetworkManager
{
    [SerializeField] private int MinPlayer = 2;

    [Scene] [SerializeField] private string MenuScene = string.Empty;

    [Header("Room")] 
    [SerializeField] private NetworkRoomPlayerUH RoomPLayerPrefab = null;

    [Header("Game")] 
    [SerializeField] private NetworkGamePlayerUH GamePLayerPrefab = null;
    [SerializeField] private GameObject PlayerSpawnSystem;
    [SerializeField] private GameObject RoundSystem;

    public static event Action OnClientConnected;
    public static event Action OnClientDisconnected;
    public static event Action<NetworkConnection> OnServerReadied;

    public List<NetworkRoomPlayerUH> RoomPlayer { get; } = new List<NetworkRoomPlayerUH>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
