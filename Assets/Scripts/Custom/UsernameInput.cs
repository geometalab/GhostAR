using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameInput : MonoBehaviour {

    public InputField InputFieldUsername;
    public string Username;
    public static UsernameInput s_instance;

    private void Awake()
    {
        s_instance = this;
        InputFieldUsername.gameObject.SetActive(false);
    }

    /// <summary>
    /// Method that gets called when the user types in a username
    /// </summary>
    /// <param name="username">The username that got typed in</param>
    public void GetuserInput(string username)
    {
        Username = username;
    }
}
