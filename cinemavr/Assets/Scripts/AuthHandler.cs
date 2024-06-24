using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class AuthHandler : MonoBehaviour
{
    const string TITLE_ID = "F595F";

    #region Register
    [Header("Register UI:")]
    [SerializeField] TMP_InputField registerEmail;
    [SerializeField] TMP_InputField registerUsername;
    [SerializeField] TMP_InputField registerPassword;

    public void OnRegisterPressed() 
    {
        Debug.Log(registerEmail.text + " " + registerUsername.text + " " + registerPassword.text);
        return;
        //Register(registerEmail.text, registerUsername.text, registerPassword.text);
    }

    private void Register(string email, string username, string password)
    {
        password = Encrypt(password);
        var registerRequest = new RegisterPlayFabUserRequest {
            Email = email,
            Username = username,
            DisplayName = username,
            Password = password
        };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterRequestSuccess(username, password) , PlayFabFailure);
    }
    private void OnRegisterRequestSuccess() {
        Debug.Log("User Registered");
        Login(username, password);
    }
    #endregion

    #region Login
    [Header("Login UI:")]
    // [SerializedField] TMP_ImputField registerEmail;
    [SerializeField] TMP_InputField loginUsername;
    [SerializeField] TMP_InputField loginPassword;

    public void OnLoginPressed()
    {
        Login(loginUsername.text, loginPassword.text);
    }

    private void Login(string email, string password)
    {
        password = Encrypt(password);
        var loginRequest = new LoginWithPlayFabRequest {
            TitleId = TITLE_ID,
            Password = password,
            Username = username
        };
        PlayFabClientAPI.LoginWithPlayFab(loginRequest, OnLoginRequestSuccess, PlayFabFailure);
    }
    private void OnLoginRequestSuccess() {
        Debug.Log("User Logged");
    }
    #endregion
    
    private string Encrypt(string pw) 
    {
        System.Security.Crytography.MD5CryptpServiceProvider x = new System.Security.Crytography.MD5CryptpServiceProvider();
        byte[] epw = System.Text.Encoding.UTF8.GetBytes(pw);
        epw = x.ComputedHash(epw);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach (byte b in epw) {
            s.Append(b.ToString("x2").ToLower());
        }
        return s.ToString();
    }
    private void PlayFabFailure(PlayFabError error)
    {
        Debug.Log(error.Error + " : " + error.GenerateErrorReport());
    }
}
