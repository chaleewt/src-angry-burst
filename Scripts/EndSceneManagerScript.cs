using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneManagerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] GameObject[] backgrounds;
    [SerializeField] GameObject creditsCanvas;
    [SerializeField] GameObject mainGameCanvas;

    private void Awake()
    {
        mainGameCanvas.SetActive(true );
        creditsCanvas.SetActive (false);

        backgrounds[0].SetActive(true );
        backgrounds[1].SetActive(false);
        backgrounds[2].SetActive(false);
    }

    private void Start()
    {
        if (pointText)
        {
            pointText.text = GameManagerScript.angryPoint.ToString();
        }
    }

    private void QuitGame()
    {
        SceneManagerScript.instance.GameExit();
    }

    private void LoadSelectionScene()
    {
        SceneManagerScript.instance.LoadSelectionScene();
    }

    public void QuitGamePreLoad()
    {
        SceneManagerScript.instance.CursorLocked();

        backgrounds[0].SetActive(false);
        backgrounds[1].SetActive(true );
        backgrounds[2].SetActive(false);
        Invoke("QuitGame", 2f);
    }

    public void SelectionScenePreLoad()
    {
        SceneManagerScript.instance.CursorLocked();

        backgrounds[0].SetActive(false);
        backgrounds[1].SetActive(false);
        backgrounds[2].SetActive(true );
        Invoke("LoadSelectionScene", 2f);
    }

    public void OpenCreidtsCanvas()
    {
        mainGameCanvas.SetActive(false);
        creditsCanvas.SetActive (true );
    }

    public void CloseCreidtsCanvas()
    {
        creditsCanvas.SetActive (false);
        mainGameCanvas.SetActive(true );
    }
}
