using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameInput : MonoBehaviour {

    private InputField InputFieldUsername;
    public string Username;
    public static UsernameInput instance;

    private void Start()
    {
        instance = this;
        InputFieldUsername = GameObject.Find("Input Field").GetComponent<InputField>();
    }

    public void GetuserInput(string username)
    {
        Username = username;
        InputFieldUsername.DeactivateInputField();
    }
}
