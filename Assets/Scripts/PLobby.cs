using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class PLobby : MonoBehaviourPunCallbacks
{
    private static PLobby _lobbyInstance;

    public static PLobby LobbyInstance
    {
        get
        {
            if (!_lobbyInstance)
            {
                Debug.LogError("Lobby instance not found");
            }

            return _lobbyInstance;
        }
    }

    [SerializeField] private TextMeshProUGUI textPanel;

    [SerializeField] private Button joinButton;
    [SerializeField] private Button leaveButton;
    [SerializeField] private Button connectButton;
    [SerializeField] private Button disconnectButton;

    private void Awake()
    {
        _lobbyInstance = this;
        joinButton.onClick.AddListener(OnJoinButtonClick);
        leaveButton.onClick.AddListener(OnLeaveRoomButtonClick);
        connectButton.onClick.AddListener(OnConnectButtonClick);
        disconnectButton.onClick.AddListener(OnDisconnectButtonClick);
    }

    private void Start()
    {
        leaveButton.interactable = false;
        joinButton.interactable = false;
        disconnectButton.interactable = false;
    }

    public override void OnConnectedToMaster()
    {
        textPanel.text += "Connected to Master server\n";
        PhotonNetwork.AutomaticallySyncScene = true;
        connectButton.interactable = false;
        joinButton.interactable = true;
        disconnectButton.interactable = true;
    }

    public override void OnJoinedRoom()
    {
        textPanel.text += "Joined room\n";
        joinButton.interactable = false;
        leaveButton.interactable = true;
    }
    
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        textPanel.text += "Cannot connect to room\n";
        CreateRoom();
    }

    private void CreateRoom()
    {
        Random random = new Random();
        int randomRoomIndex = random.Next(0, 10000);
        RoomOptions roomOptions = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = 2};
        PhotonNetwork.CreateRoom("Room" + randomRoomIndex, roomOptions);
        textPanel.text += "Created room" + randomRoomIndex + "\n";
    }

    public override void OnCreatedRoom()
    {
        textPanel.text += "Created new room\n";
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        textPanel.text += "Failed to create room\n";
        CreateRoom();
    }
    
    private void OnJoinButtonClick()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    private void OnLeaveRoomButtonClick()
    {
        PhotonNetwork.LeaveRoom();
    }
    
    public override void OnLeftRoom()
    {
        leaveButton.interactable = false;
        textPanel.text += "Player disconnected\n";
    }

    private void OnConnectButtonClick()
    {
        textPanel.text = "";
        PhotonNetwork.ConnectUsingSettings();
    }

    private void OnDisconnectButtonClick()
    {
        PhotonNetwork.Disconnect();
    }
    
    public override void OnDisconnected(DisconnectCause cause)
    {
        connectButton.interactable = true;
        leaveButton.interactable = false;
        joinButton.interactable = false;
        disconnectButton.interactable = false;
        textPanel.text += "Disconnected because " + cause + "\n";
    }
}
