using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;


public class PPlayer : MonoBehaviour
{
    private PhotonView _myPhotonView;
    private int _spawnPicker;
    public GameObject myAvatar;

    void Awake()
    {
        _myPhotonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        _spawnPicker = PhotonNetwork.PlayerList.Length - 1;

        if (_myPhotonView.IsMine)
        {
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvatar"), GameSetup.gameSetupInstance.spawnPoints[_spawnPicker].position, GameSetup.gameSetupInstance.spawnPoints[_spawnPicker].rotation, 0);
        }
    }
}
