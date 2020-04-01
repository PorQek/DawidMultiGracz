using System.IO;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AvatarSetup : MonoBehaviour
{
    private PhotonView _myPhotonView;
    public GameObject myCharacter;
    public int characterValue;

    private void Awake()
    {
        _myPhotonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if(_myPhotonView.IsMine)
        {
            _myPhotonView.RPC("RPC_AddCharacters", RpcTarget.AllBuffered, PlayerInfo.playerInfoInstance.mySelectedCharacter);
        }
    }

    [PunRPC]
    void RPC_AddCharacter(int p_characterIndex)
    {
        characterValue = p_characterIndex;
        myCharacter = Instantiate(PlayerInfo.playerInfoInstance.allCharacters[p_characterIndex], transform.position, transform.rotation, transform);
    }
}
