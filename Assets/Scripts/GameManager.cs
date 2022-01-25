using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public GameObject StartP, InGameP, NextP, GameOverP;
    public float countDown = 2F;

    [SerializeField] private int asynSceneIndex = 1;
    public float speed = 5;

    public enum GameState{
        
        Start,
        Ingame,
        Next,
        Gameover


    }
    public GameState gameState;
    public enum Panels
    {
        Startp,
        Ingamep,
        Nextp,
        Gameoverp,
    }
    private void Start()
    {
        gameState = GameState.Start;
    }
    private void Update()
    {
        switch (gameState)
        {
            case GameState.Start: GameStart();
                break;

            case GameState.Ingame: GameInGame();
                break;

            case GameState.Next: GameFinish();
                break;

            case GameState.Gameover: GameOver(); 
                break;
        }
    }

    void PanelController(Panels currentPanel)
    {
        StartP.SetActive(false);
        InGameP.SetActive(false);
        NextP.SetActive(false);
        GameOverP.SetActive(false);

        switch (currentPanel)
        {
            case Panels.Startp:
                StartP.SetActive(true);
                break;
            case Panels.Ingamep:
                InGameP.SetActive(true);
                break;
            case Panels.Nextp:
                NextP.SetActive(true);
                break;
            case Panels.Gameoverp:
                GameOverP.SetActive(true);
                break;
            
        }
    }

    void GameStart()
    {
        PanelController(Panels.Startp);
    }
    void GameInGame()
    {
        PanelController(Panels.Ingamep);
    }
    void GameFinish()
    {
        PanelController(Panels.Nextp);
    }
    void GameOver()
    {
        PanelController(Panels.Gameoverp);
    }

    public void RestartButton()
    {

    }

    public void NextLevelButton()
    {

    }
}
