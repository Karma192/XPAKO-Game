using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvTime : MonoBehaviour
{
    private float time;
    public Text timeText;

    void Start ()
    {
        timeText = gameObject.GetComponent<Text>();
    }

    void OnEnable ()
    {
        time = GameObject.Find("Timer").GetComponent<Timer>().Timefixed;

        if (time < 0)
        {
            time = 0;
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = time % 1 * 1000;

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
