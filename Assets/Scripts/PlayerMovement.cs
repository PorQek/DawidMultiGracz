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

public class PlayerMovement : MonoBehaviour
{
    private PhotonView _myPhotonView;
    private CharacterController _myCharacterController;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    private float _mouseX;

    void Awake()
    {
        _myPhotonView = GetComponent<PhotonView>();
        _myCharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(_myPhotonView.IsMine)
        {
            Movement();
            Rotation();
        }
    }

    private void Movement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            _myCharacterController.Move(transform.forward * Time.deltaTime * _movementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _myCharacterController.Move(-transform.right * Time.deltaTime * _movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _myCharacterController.Move(-transform.forward * Time.deltaTime * _movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _myCharacterController.Move(transform.right * Time.deltaTime * _movementSpeed);
        }
    }

    private void Rotation()
    {
        _mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _rotationSpeed;
        transform.Rotate(new Vector3(0, _mouseX, 0));
    }
}
