using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastScore : MonoBehaviour
{

    public Text lastScoreText;

    private void Start()
    {
        lastScoreText.text = "Letzte Session: " + PlayerPrefs.GetInt("Last Score", 0).ToString();
    }

}
