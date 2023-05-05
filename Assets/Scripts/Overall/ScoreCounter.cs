using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static int Score = 0;
    TextMeshProUGUI ScoreShower;
    private void Awake()
    {
        ScoreShower = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        ScoreShower.text = Score.ToString();
    }
}
