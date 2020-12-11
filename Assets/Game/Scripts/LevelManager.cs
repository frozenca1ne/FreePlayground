using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    #region Singleton 
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public Action OnCoinsCountChange = delegate { };

    [Header("Score")]
    [SerializeField] int score;
    [SerializeField] Text scoreText;

    [Header("Portal")]
    [SerializeField] GameObject portal;

    private int coinsCount;
    private Coin[] coins;

    public int ScoreUp
    {
        get
        {
            return score;
        }
        set
        {
            score += value;
            UpdateScore();
        }
    }
    public void ChangeCoinsCount()
    {
        coinsCount -= 1;
        OnCoinsCountChange();
    }
    private void Start()
    {
        coins = FindObjectsOfType<Coin>();
        coinsCount = coins.Length;
        OnCoinsCountChange += ActivatePortal;
    }
    private void UpdateScore()
    {
        scoreText.text = "SCORE : " + ScoreUp;
    }

    private void ActivatePortal()
    {
        if (coinsCount <= 0)
        {
            portal.gameObject.SetActive(true);
        }

    }

}
