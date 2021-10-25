using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    Text text;
    public static int Scorecount;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = Scorecount.ToString();
    }
}
