using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class ConnectToServer : MonoBehaviourPunCallbacks
{
    

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Start is called before the first frame update
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

   public override void OnJoinedLobby(){
        SceneController.LoadScene("Lobby");
   }


    
}
