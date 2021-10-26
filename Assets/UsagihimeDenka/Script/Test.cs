using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private NetworkManager _networkManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartHost()
    {
        _networkManager.StartHost();
    }

    public void OnClient()
    {
        _networkManager.StartClient();
    }

    public void StopCluient()
    {
        _networkManager.StopClient();
    }

    public void OnStopHost()
    {
        _networkManager.StopHost();
    }
}
