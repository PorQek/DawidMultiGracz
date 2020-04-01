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

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button[] _characterButtons;

    private void Start()
    {
        for(int i = 0; i < _characterButtons.Length; i++)
        {
            int number = i;
            _characterButtons[i].onClick.AddListener(delegate { OnClickCharacterPick(number); });
        }
    }

    private void OnClickCharacterPick(int p_characterIndex)
    {
        if(PlayerInfo.playerInfoInstance != null)
        {
            PlayerInfo.playerInfoInstance.mySelectedCharacter = p_characterIndex;
            PlayerPrefs.SetInt("MyCharacter", p_characterIndex);
        }
    }
}
