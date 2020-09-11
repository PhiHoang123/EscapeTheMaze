using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton
    private static SoundManager _instance;
    public static SoundManager Instance
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

    [SerializeField]
    private AudioSource collectCoinSound;

    public void CollectCoinSound()
    {
        collectCoinSound.Play();
    }
}
