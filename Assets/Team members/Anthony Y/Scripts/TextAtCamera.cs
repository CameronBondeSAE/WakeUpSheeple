using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using Mirror.Examples.Chat;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using TMPro;
using UnityEngine;

public class TextAtCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro playerName;
    private PlayerBehaviour playerBehaviour;
    void Awake()
    {
        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        playerName.text = playerBehaviour?.Owner?.GetComponent<NetworkGamePlayer>()?.displayName;
    }
}
