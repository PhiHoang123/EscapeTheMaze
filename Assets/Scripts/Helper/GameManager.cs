using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
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
    }
    #endregion


    private void OnEnable()
    {
        //begin an event to next level
         Player.toNextLevel += ToNextLevel;
    }

    public void ToNextLevel()
    {
        //resume the game
        Time.timeScale = 1;

        //load the scence
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //hide the annoucement.
        UIManager.Instance.panel.SetActive(false);
    }
}
