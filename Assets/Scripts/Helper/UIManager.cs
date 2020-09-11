using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        //if UIManager is exist, destroy another UIManager instance.
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
     
        //Don't destroy the canvas when reload scene. Avoid missing reference UI when reload scene
        if(GameObject.Find("Canvas").transform != null)
            DontDestroyOnLoad(GameObject.Find("Canvas").transform);
    }
    #endregion

    public TextMeshProUGUI playerScoreText;

    public TextMeshProUGUI aiScoreText;

    public TextMeshProUGUI levelCountText;

    public TextMeshProUGUI annoucementText;

    public GameObject panel;

    private void OnEnable()
    {
        //begin event announce winner when player reach the finishline
        FinishLine.announce += Announce;
    }

    private void Update()
    {
        //Display the score text 
        playerScoreText.text = ScoreManager.Instance.score + "";

        //Display AI score text
        aiScoreText.text = ScoreManager.Instance.aiScore + "";

        //Display the level count text
        levelCountText.text = ScoreManager.Instance.levelCount + "";
    }

    void Announce()
    {
        //display the announcement
        panel.SetActive(true);

        //if player win display you won text, if player lose display you lose text.
        if(FinishLine.playerWin == true)
        {
            annoucementText.text = "You Won !";
        }
        else
        {
            annoucementText.text = "You Lose !";
        }
    }
}
