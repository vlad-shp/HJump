using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreUI : MonoBehaviour
{
    private Text _textUI;

    private void Start()
    {
        _textUI = GetComponent<Text>();
        _textUI.text = "0";
    }

    private void OnEnable()
    {
        ScoreSystem.OnChangeScoreUI += UpdateScoreText;
    }

    private void OnDisable()
    {
        ScoreSystem.OnChangeScoreUI -= UpdateScoreText;
    }

    public void UpdateScoreText(string score)
    {
        _textUI.text = score;
    }
}
