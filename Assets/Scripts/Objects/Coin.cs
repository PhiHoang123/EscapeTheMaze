using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public static Action onUpdateScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.CollectCoinSound();
            //create an event when player collide with coin, the score UI will update.
            if (onUpdateScore != null)
                onUpdateScore();

            Destroy(gameObject);
        }
    }
}
