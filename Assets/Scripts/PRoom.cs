using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    private static PRoom _roomInstance;
    private PhotonView _photonView;
    
    private int _currentSceneIndex;
    [SerializeField] private int multiplayerSceneIndex = 0;
    
    private void Awake()
    {
        if (PRoom._roomInstance == null)
        {
            PRoom._roomInstance = this;
        }
        else
        {
            if (PRoom._roomInstance != this)
            {
                Destroy(PRoom._roomInstance.gameObject);
                PRoom._roomInstance = this;
            }
        }
        
        
        DontDestroyOnLoad(this.gameObject);

        _photonView = GetComponent<PhotonView>();
    }
    
    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }
    
    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        _currentSceneIndex = scene.buildIndex;
        if (_currentSceneIndex == multiplayerSceneIndex)
        {
            CreatePlayer();
        }
    }

    private void CreatePlayer()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), new Vector3(0, 0, 0),
            Quaternion.identity, 0);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("In Room");

        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        StartGame();
    }

    private void StartGame()
    {
        PhotonNetwork.LoadLevel(multiplayerSceneIndex);
    }
    
}
