using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreSystem : MonoBehaviour
{
    public delegate void ChangeScoreUI(string score);
    public static event ChangeScoreUI OnChangeScoreUI;

    public static ScoreSystem Instance = null;

    private int _currentScore;

    private void Start()
    {
        _currentScore = 0;

        if (Instance == null)
        { 
            Instance = this; 
        }
        else if (Instance == this)
        { 
            Destroy(gameObject); 
        }
    }
    
    public void IncrementScore()
    {
        _currentScore++;

        OnChangeScoreUI?.Invoke(_currentScore.ToString());
    }
}
