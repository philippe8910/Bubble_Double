using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    [Header("UI")] 
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private Button ContinueButton = null;

    public static string DisPlayName { get; private set; }

    private const string PlayerPresNameKey = "PlayerName";
    
    // Start is called before the first frame update
    private void Start() => SetUpInputFiled();

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetUpInputFiled()
    {
        if (!PlayerPrefs.HasKey(PlayerPresNameKey))
        {
            return;
        }

        string defaultName = PlayerPrefs.GetString(PlayerPresNameKey);
        nameInputField.text = defaultName;

    }

    public void SetPlayerName(string name)
    {
        ContinueButton.interactable = !string.IsNullOrEmpty(name);
    }

    public void SavePlayerName()
    {
        DisPlayName = nameInputField.text;
        
        PlayerPrefs.SetString(PlayerPresNameKey , DisPlayName);
    }
    
}
