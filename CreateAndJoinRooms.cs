using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    
    public InputField createInput;
    public InputField joinInput;

    public void CreateRoom(){
        PhotonNetwork.CreateRoom(createInput.text);
        Debug.Log($"Haz creado una sala con nombre: " + createInput.text);
    }

    public void JoinRoom(){
        PhotonNetwork.JoinRoom(joinInput.text);
        Debug.Log($"Te haz unido  una sala con nombre: " + joinInput.text);
    }

    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("Level_1");

    }


}
