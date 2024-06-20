using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AuthHandler : MonoBehaviour
{
    const string LAST_EMAIL_KEY = "LAST_EMAIL", LAST_PASSWORD = "LAST_PASSWORD";

    #region Register
    [Header("Register UI:")]
    [SerializedField] TMP_ImputField registerEmail;
    [SerializedField] TMP_ImputField registerUsername;
    [SerializedField] TMP_ImputField registerPassword;

    public void OnRegisterPressed() 
    {
        Register(registerEmail.text, registerUsername.text, registerPassword.text);
    }

    private void Register(string email, string username, string password)


    #endregion

    #region Login
    [Header("Login UI:")]
    // [SerializedField] TMP_ImputField registerEmail;
    [SerializedField] TMP_ImputField registerUsername;
    [SerializedField] TMP_ImputField registerPassword;
    #endregion
}
