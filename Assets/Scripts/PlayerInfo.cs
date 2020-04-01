using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo playerInfoInstance;

    public int mySelectedCharacter;

    public GameObject[] allCharacters;

    private void OnEnable()
    {
        if(PlayerInfo.playerInfoInstance == null)
        {
            PlayerInfo.playerInfoInstance = this;
        }
        else
        {
            if(PlayerInfo.playerInfoInstance != this)
            {
                Destroy(PlayerInfo.playerInfoInstance.gameObject);
                PlayerInfo.playerInfoInstance = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        if(PlayerPrefs.HasKey("MyCharacter"))
        {
            mySelectedCharacter = PlayerPrefs.GetInt("MyCharacter");
        }
        else
        {
            mySelectedCharacter = 0;
            PlayerPrefs.SetInt("MyCharacter", mySelectedCharacter);
        }
    }
}
