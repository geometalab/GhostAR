using UnityEngine;
using UnityEngine.UI;

public class ProhibitedSign : MonoBehaviour
{
    private float timeShown = 0f;

    private void Update()
    {
        Image prohibitedImage = gameObject.GetComponent<Image>();

        if (prohibitedImage.enabled)
        {
            timeShown += Time.deltaTime;

            if (timeShown >= 1f)
            {
                timeShown = 0f;
                GameObject.Find("ARCamera").GetComponent<Score>().prohibitedInfo.enabled = false;
                prohibitedImage.enabled = false;
            }
        }
    }
}
