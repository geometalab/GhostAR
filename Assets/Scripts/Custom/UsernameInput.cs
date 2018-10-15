using UnityEngine;
using UnityEngine.UI;

public class UsernameInput : MonoBehaviour
{
    public InputField InputFieldUsername;
    public string Username;

    private void Awake()
    {
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
