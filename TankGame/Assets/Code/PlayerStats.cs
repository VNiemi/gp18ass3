using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public UnityEngine.UI.Text _livetext, _scoretext;

    // Not doing localization, sorry. I did actually look into it, but I had an issue with the editor and 90 minutes to dead line...
    // Maybe because I did not have the time to install the CORRECT version of Unity?

    public void UpdateLives(int lives)
    {
        String livetext;

        if(lives==0)
        {
            livetext = "You died and lost.";
        }
        else
        {
            livetext = "Lives left is " + lives.ToString() + " and lives lost (probably) three minus that.";
        }

        _livetext.text = livetext;

    }

    public void UpdateScore(int score, int winningScore)
    {
        String scoretext;

        if (score >= winningScore)
        {
            scoretext = "You won, as a reward the game will freeze...";
            Time.timeScale = 0;
        }
        else
        {
            scoretext = "Ypur score is "+score.ToString()+" of "+winningScore.ToString()+" needed to win.";
        }

        _scoretext.text = scoretext;

    }

    
    
}
