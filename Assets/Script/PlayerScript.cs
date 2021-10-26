using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerScript : NetworkBehaviour
{
    public GameObject Info;
    public TextMesh nameText;
    public CharacterController _CharacterController;

    public float RotateSpeed;
    public float Speed;

    private Material playerMaterialClone;


    [SyncVar(hook = nameof(OnPlayerNameChange))]
    private string PlayerName;
    
    [SyncVar(hook = nameof(OnPlayerColorChange))]
    private Color PlayerColor;



    private void OnPlayerNameChange(string oldStr , string newStr)
    {
        nameText.text = newStr;
    }

    private void OnPlayerColorChange(Color oldCol , Color newCol)
    {
        nameText.color = newCol;
        
        playerMaterialClone = new Material(GetComponent<Renderer>().material);
        playerMaterialClone.SetColor("_EmissionColor" , newCol);

        GetComponent<Renderer>().material = playerMaterialClone;
    }

    [Command]
    private void CmdSetUpPlayer(string nameValue , Color colorValue)
    {
        PlayerName = nameValue;
        PlayerColor = colorValue;
    }
    
    public override void OnStartLocalPlayer()
    {
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = Vector3.zero;
        
        Info.transform.localPosition = new Vector3(0 , -.3f , .6f);
        Info.transform.localScale = new Vector3(.1f , .1f , .1f);

        var TempName = "Player" + (Random.Range(0, 100));
        var TempColor = new Color
            (
                Random.Range( 0 , 1f),
                Random.Range( 0 , 1f),
                Random.Range( 0 , 1f),
                1
            );
        
         //CmdSetUpPlayer(TempName , TempColor);
    }

    private void Update()
    {
        if (!isLocalPlayer)
        {
            Info.transform.LookAt(Camera.main.transform);
            return;
        }

        float X = Input.GetAxis("Mouse X") * RotateSpeed;
        float Y = Input.GetAxis("Mouse Y") * RotateSpeed;
        
        Camera.main.transform.localRotation = Camera.main.transform.localRotation * Quaternion.Euler(-Y,0,0);
        transform.localRotation = transform.localRotation * Quaternion.Euler(0, X, 0);
        
        float x = Input.GetAxis("Horizontal");//input水平
        float z = Input.GetAxis("Vertical");//input垂直

        Vector3 move = transform.right * x + transform.forward * z;


        _CharacterController.Move(move * Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.C))
        {
            var TempName = "Player" + (Random.Range(0, 100));
            var TempColor = new Color
            (
                Random.Range( 0 , 1f),
                Random.Range( 0 , 1f),
                Random.Range( 0 , 1f),
                1
            );
        
            CmdSetUpPlayer(TempName , TempColor);
        }
    }
}
