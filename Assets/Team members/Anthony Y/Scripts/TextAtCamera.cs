using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using TMPro;
using UnityEngine;

public class TextAtCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro playerName;
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerName.text = GetComponent<PlayerBehaviour>().Owner.GetComponent<NetworkGamePlayer>().displayName;
    }
}
