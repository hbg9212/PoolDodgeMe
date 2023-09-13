using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStop : MonoBehaviour
{
    public Button Btn;
    public GameObject Option;
    bool pause = false;
    public void StopTime()
    {
        Option.SetActive(true);
        if (Option.activeSelf == true && !pause)
        {
            pause = true;
            Time.timeScale = 0;
        }
        else if (Option.activeSelf == true && pause)
        {
            pause = false;
            Option.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void StopTimex()
    {
        pause = false;
        Option.SetActive(false);
        Time.timeScale = 1;
    }

    public AudioClip Click;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = Click;
    }

    public void PlaySoundOnClick()
    {
        audioSource.Play();
    }
}

