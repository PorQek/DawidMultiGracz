using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    public PhotonView pV;
    void Update()
    {
        if (!pV.IsMine) return;
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(10f * Time.deltaTime * Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(10f * Time.deltaTime * Vector3.right);
        }
    }
}
