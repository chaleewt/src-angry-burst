using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    [SerializeField] Slider angryPointSlider;
    [SerializeField] GameObject hitParticle;
    [SerializeField] AudioClip hitSound;
    [SerializeField] Transform[] particleLocations;

    public static int angryPoint = 0;
    private int locationIndex = 0;

    private void Awake()
    {
        instance = this;
        angryPointSlider.maxValue = 500;
    }

    private void Update()
    {
        // Locked Mouse Cursor & Turn Off Timer Sound When The Time is Out 
        if (GameTimerScript.instance.bTimeOut)
        {
            SceneManagerScript.instance.CursorLocked();
            AudioManagerScript.instance.tsm_audioSource.Stop();
        }
    }

    public void IncreaseAngryPoint()
    {
        if (!GameTimerScript.instance.bTimeOut)
        {
            angryPoint += 1;
            angryPointSlider.value = angryPoint;

            if (hitParticle)
            {
                // Instantiate Particle Effect
                locationIndex = Random.Range(0, particleLocations.Length);
                GameObject vfx = Instantiate(hitParticle, particleLocations[locationIndex]);
                Destroy(vfx, 1.5f);
            }

            if (hitSound)
            {
                // Play Hit Sound
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.PlayOneShot(hitSound);
            }
        }
        else
        {
            return;
        }
    }

    public static void GameReset()
    {
        GameTimerScript.gameTimer = 0;
        angryPoint = 0;
    }
}
