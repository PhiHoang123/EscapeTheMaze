using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    #region Singleton
    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    public int score;
    public int aiScore;
    public int levelCount;

    private void OnEnable()
    {
        //begin the event update score and counting levels
        Coin.onUpdateScore += UpdatePLayerScore;
        FinishLine.updateScoreForPlayer += UpdatePLayerScore;
        FinishLine.updateScoreForAI += UpdateAIScore;
        FinishLine.countingLevel += CountingLevel;
    }

    void Start()
    {
        //default value of score and level
        score = 0;
        aiScore = 0;
        levelCount = 1;
    }

    void UpdatePLayerScore()
    {
        //when player win the race , increase score by 1;
        score += 1;
    }

    void UpdateAIScore()
    {
        //when AI win the race , increase score by 1;
        aiScore += 1;
    }

    void CountingLevel()
    {
        //when player or AI reach the finish line , increase levelCount by 1;
        levelCount += 1;
    }
}
