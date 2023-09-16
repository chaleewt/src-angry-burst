using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerScript : MonoBehaviour
{
    public static GameTimerScript instance;

    [SerializeField] Slider timerSlider;

    public static float gameTimer = 0;

    [System.NonSerialized]
    public bool bTimeOut = false;


    private void Awake()
    {
        instance = this;
        timerSlider.maxValue = gameTimer;
    }

    private void FixedUpdate()
    {
        TimeCounter();
    }

    private void TimeCounter()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
            timerSlider.value = gameTimer;
        }

        if (gameTimer <= 0)
        {
            bTimeOut = true;
            gameTimer = 0;
            timerSlider.value = gameTimer;
            Invoke("LoadEndScene", 2.5f);
        }
    }

    private void LoadEndScene()
    {
        SceneManagerScript.instance.LoadEndScene  ();
        SceneManagerScript.instance.CursorReleased();
    }
}
