using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static SceneManagerScript instance;

    private void Awake()
    {
        instance = this;
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
        GameManagerScript.GameReset();
        CursorReleased();
    }

    public void LoadSelectionScene()
    {
        SceneManager.LoadScene("SelectionScene");
        GameManagerScript.GameReset();
        CursorReleased();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
        AudioManagerScript.instance.PlayTimerSound();
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene");
        AudioManagerScript.instance.tsm_audioSource.Stop();
    }

    public void GameExit()
    {
        Application.Quit();
        GameManagerScript.GameReset();
    }


    // Set Game Timer
    public void SetTimer_Upset()
    {
        GameTimerScript.gameTimer = 10f;
        Invoke("LoadGameScene", .5f);
    }

    public void SetTimer_Angry()
    {
        GameTimerScript.gameTimer = 15f;
        Invoke("LoadGameScene", .5f);
    }

    public void SetTimer_Outburst()
    {
        GameTimerScript.gameTimer = 20f;
        Invoke("LoadGameScene", .5f);
    }

    public void CursorLocked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CursorReleased()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
