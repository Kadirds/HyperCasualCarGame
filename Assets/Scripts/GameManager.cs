using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager StartP, InGameP, NextP, GameOverP;
    public float CountDown = 2F;

    [SerializeField] private int asynSceneIndex = 1;

    public enum GameState{
        
        Start,
        Ingame,
        Next,
        Gameover


    }
    public GameState gamestate;
    public enum Panels
    {
        Startp,
        Ingame,
        Nextp,
        Gameoverp,
    }
    private void Start()
    {
        gamestate = GameState.Start;
    }
    private void Update()
    {
        switch (gamestate)
        {
            case GameState.Start:
                break;

            case GameState.Ingame:
                break;

            case GameState.Next:
                break;

            case GameState.Gameover:
                break;
        }
    }
}
