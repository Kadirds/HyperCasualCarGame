using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameState Gamestate;
    public enum Panels
    {
        Startp,
        Ingamep,
        Nextp,
        Gameoverp,
    }
    private void Start()
    {
        Gamestate = GameState.Start;
    }
    private void Update()
    {
        switch (Gamestate)
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
