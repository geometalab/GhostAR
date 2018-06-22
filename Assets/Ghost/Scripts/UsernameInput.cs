using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameInput : MonoBehaviour {

    public InputField InputFieldUsername;
    public string Username;
    public static UsernameInput instance;

    private void Awake()
    {
        instance = this;
        InputFieldUsername.gameObject.SetActive(false);
    }

    public void GetuserInput(string username)
    {
        Username = username;
    }
}
