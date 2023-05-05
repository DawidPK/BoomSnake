using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DeathScoreShower;

    private void Awake()
    {
        DeathScoreShower = GetComponent<TextMeshProUGUI>();
        
    }
    private void OnEnable()
    {
        DeathScoreShower.text = "Your Score: " + ScoreCounter.Score.ToString();
    }
}
