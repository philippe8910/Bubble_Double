using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NetworkRoomPlayerUH : NetworkBehaviour
{
   [Header("UI")] 
   [SerializeField] private GameObject LobbyUI = null;
   [SerializeField] private TMP_Text[] PlayerNameText = new TMP_Text[2];
   [SerializeField] private TMP_Text[] PlayerReadyText = new TMP_Text[2];
   [SerializeField] private Button StartGameBitton = null;
   
   
}
