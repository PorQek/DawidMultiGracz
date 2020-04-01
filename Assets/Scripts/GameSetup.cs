using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public static GameSetup gameSetupInstance;
    public Transform[] spawnPoints;

    private void OnEnable()
    {
        if(GameSetup.gameSetupInstance == null)
        {
            GameSetup.gameSetupInstance = this;
        }
    }
}
