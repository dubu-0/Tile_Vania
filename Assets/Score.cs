using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    private static int _score;

    private void Start()
    {
        textMeshProUGUI.text = _score.ToString();
    }

    public void Add(int value)
    {
        _score += value;
        textMeshProUGUI.text = _score.ToString();
    }
}
