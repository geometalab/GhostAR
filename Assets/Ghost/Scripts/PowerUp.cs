using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private bool _isCatched = false;
    private float _timeSinceCatched = 0;
    private Transform tf;
    private Vector3 originPosition;

    private void Start()
    {

        tf = gameObject.transform;
        originPosition = tf.position;
    }

    private void Update()
    {

        if (_isCatched)
        {

            tf.position += (Vector3.down / 100f) * 1.5f;
            _timeSinceCatched += Time.deltaTime;

            if (_timeSinceCatched >= 3)
            {

                tf.position = originPosition;
                _isCatched = false;
                _timeSinceCatched = 0;

            }

        }

    }

    private void OnMouseDown()
    {
        _isCatched = true;
        GhostCatcher._colorOfLastCaughtGhost = "-";
        Score.instance.SetGhostColorText("-");
        Score.instance.Decrease();

    }
}
