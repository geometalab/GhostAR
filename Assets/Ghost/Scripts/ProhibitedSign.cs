using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProhibitedSign : MonoBehaviour
{

    private float _timeShown = 0f;

    private void Update()
    {

        Image prohibitedImage = gameObject.GetComponent<Image>();

        if (prohibitedImage.enabled)
        {
            _timeShown += Time.deltaTime;

            if (_timeShown >= 1f)
            {
                _timeShown = 0f;
                Score.instance.prohibitedInfo.enabled = false;
                prohibitedImage.enabled = false;
            }
        }
    }
}
