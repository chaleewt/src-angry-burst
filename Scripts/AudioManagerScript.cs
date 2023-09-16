using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript instance;

    [SerializeField] AudioClip timerCountSound;

    [System.NonSerialized]
    public AudioSource bgm_audioSource;

    [System.NonSerialized]
    public AudioSource tsm_audioSource;


    private void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        SetupBackgroundMusic();
    }

    private void SetupBackgroundMusic()
    {
        if (bgm_audioSource)
        {
            bgm_audioSource.playOnAwake = true;
            bgm_audioSource.loop = true;
            bgm_audioSource.volume = 0.4f;
        }
    }

    public void PlayTimerSound()
    {
        tsm_audioSource = gameObject.AddComponent<AudioSource>();
        if (tsm_audioSource)
        {
            tsm_audioSource.PlayOneShot(timerCountSound);
            tsm_audioSource.loop = true;
            tsm_audioSource.volume = 1f;
        }
    }
}
