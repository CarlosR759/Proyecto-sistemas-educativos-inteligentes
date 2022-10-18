using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Photon.Pun;


public class PlayfabLogin : MonoBehaviour
{

    [SerializeField] private string username;
    #region Unity Methods
    void Start()
    {
        if(string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = ""; //HAY QUE BORRAR ID
        }

    }
    #endregion


    #region Private Methods
    private bool IsValidUsername()
    {
        bool isValid = false;
        if(username.Length >= 3 && username.Length <= 24)
            isValid = true;
        return isValid; 
    }

    private void LoginWithCustomId()
    {
        Debug.Log($"Logeado en playfab como {username}");
        var request = new LoginWithCustomIDRequest {CustomId = username, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginCustomIdSuccess, OnFailure);
        //Codigo para agregar a photon al login. Solo ingresamos con el nickname//
       //No hay funciones del juego implementadas aqui// 
        //PhotonNetwork.NickName = username;
        //PhotonNetwork.ConnectUsingSettings();
    }
   
    private void UpdateDisplayName(string displayname)
    {
        Debug.Log($"Actualizando nombre de usario en playfab como: {displayname}");
        var request = new UpdateUserTitleDisplayNameRequest {DisplayName = displayname};
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameSuccess, OnFailure);
    }

    #endregion

    #region Public Methods
    public void SetUsername(string name)
    {
        username = name;
        PlayerPrefs.SetString("USERNAME", username);
    }
  
    public void Login()
    {
        //if(!IsValidUsername) return; 
        LoginWithCustomId();
    }
    #endregion

    #region Playfab Callbacks

    private void OnLoginCustomIdSuccess(LoginResult result)
    {
        Debug.Log($"Haz logeado exitosamente en playfab usando la id {username}");
        UpdateDisplayName(username);
    }
  
    private void OnDisplayNameSuccess(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log($"Haz actualizado el nombre de usario en servidor de playfab para tu cuenta playfab");
        SceneController.LoadScene("Loading");
    }

    private void OnFailure(PlayFabError error)
    {
        Debug.Log($"Hay ocurrido un error en playfab {error.GenerateErrorReport()}");

    }

    #endregion
   
    

}
