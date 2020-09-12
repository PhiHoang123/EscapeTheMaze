using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FinishLine : MonoBehaviour
{
    public static Action countingLevel;


    public static Action updateScoreForPlayer;
    public static Action updateScoreForAI;

    public static Action announce;

    //check if player is winner
    public static bool playerWin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //if player win the race, UI will display announce the player is winner.
            playerWin = true;

            //when player reach the finishline , the level is finished
            GameManager.Instance.isFinished = true;

            //stop the game
            Time.timeScale = 0;

            //create an event counting level when player reach the finish line
            if (countingLevel != null)
                countingLevel();

            //create an event announce the player when player reach the finish line
            if (announce != null)
                announce();

            //update score for Player
            if (updateScoreForPlayer != null)
                updateScoreForPlayer();
        }

        if (other.CompareTag("AI"))
        {
            //if AI win the race, UI will display announce the player is loser.
            playerWin = false;

            //when AI reach the finishline , the level is finished
            GameManager.Instance.isFinished = true;

            //stop the game
            Time.timeScale = 0;

            //create an event counting level when AI reach the finish line
            if (countingLevel != null)
                countingLevel();

            //create an event announce the player when AI reach the finish line
            if (announce != null)
                announce();

            //update score for AI
            if (updateScoreForAI != null)
                updateScoreForAI();
        }
    }
}
