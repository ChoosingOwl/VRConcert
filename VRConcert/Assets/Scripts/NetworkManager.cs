﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

    string _room = "My_Room";
    // Use this for initialization
    void Start()
    {

        PhotonNetwork.ConnectUsingSettings("0.01");
        if (PhotonNetwork.connected)
        {
            Debug.Log("Connected");
        }

    }
    void OnJoinedLobby()
    {
        print("In Lobby");

        RoomOptions roomOptions = new RoomOptions() { };
        PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.playerList.Length);

        if(PhotonNetwork.playerList.Length < 2)
        {
           //Instantiates the avatar here, and the position where it spawns.
            PhotonNetwork.Instantiate("Player1", new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
        }else if (PhotonNetwork.playerList.Length < 3)
        {
            PhotonNetwork.Instantiate("Player2", new Vector3(100f, 0f, 0f), Quaternion.identity, 0);
        }
    }

}
