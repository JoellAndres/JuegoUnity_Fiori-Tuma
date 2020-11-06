using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float parallaxSpeed = 0.02f;
    public RawImage background;
    public RawImage platform;
    public GameObject uiIdle;

    public enum GameState {Idle, Playing};
    public GameState gameState = GameState.Idle;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gameState == GameState.Idle && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {
            gameState = GameState.Playing;
            uiIdle.SetActive(false);
            player.SendMessage("UpdateState", "PlayerRuning");
        }
        else if (gameState == GameState.Playing)
        {
            Parallax();
        }
    }

    void Parallax()
    {
        float finalSped = parallaxSpeed * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + finalSped, 0.0f, 1.0f, 1.0f);
        platform.uvRect = new Rect(platform.uvRect.x + finalSped * 4, 0.0f, 1.0f, 1.0f);
    }
}
