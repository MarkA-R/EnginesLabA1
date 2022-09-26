using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;

    public int score;
    private void Awake()
    {
        //singleton
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    public void changeScore(int adder)
    {
        score += adder;
        Debug.Log("SCORE: " + score);
    }


    
}
