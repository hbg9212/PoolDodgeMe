using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public static AudioManager I;
    private void Awake()
    {
        I = this;
        Init();
    }
    [Header("#BGM")]
    public Dropdown bgmDropdown;
    public AudioClip bgmClip;
    public AudioClip bgmClip2;
    public AudioClip bgmClip3;
    public float bgmVolume;
    AudioSource bgmPlayer;
    AudioHighPassFilter bgmEffect;
    public Slider bgm_Slider;
    public GameObject bgm_Mute;

    [Header("#SFX")]
    public AudioClip[] sfxClip;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayer;
    int channelIndex;
    public Slider sfx_Slider;
    public GameObject sfx_Mute;

    private void Start()
    {
        bgmDropdown.onValueChanged.AddListener(ChangeBGM);
        bgmPlayer = gameObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.clip = bgmClip;
    }
    private void ChangeBGM(int bgmIndex)
    {
        // Dropdown에서 선택한 BGM 인덱스에 따라 BGM을 변경합니다.
        switch (bgmIndex)
        {
            case 0:
                bgmPlayer.clip = bgmClip;
                break;
            case 1:
                bgmPlayer.clip = bgmClip2;
                break;
            case 2:
                bgmPlayer.clip = bgmClip3;
                break;
            default:
                bgmPlayer.clip = null;
                break;
        }

        // BGM 재생
        if (bgmPlayer.clip != null)
        {
            bgmPlayer.Play();
        }
    }

    public enum Sfx { Poop, Hit, Bomb, Freez };
    private void Init()
    {
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;
        bgmEffect = Camera.main.GetComponent<AudioHighPassFilter>();

        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayer = new AudioSource[channels];

        for (int index = 0; index < sfxPlayer.Length; index++)
        {
            sfxPlayer[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayer[index].playOnAwake = false;
            sfxPlayer[index].volume = sfxVolume;
            sfxPlayer[index].bypassListenerEffects = true;
        }
    }

    public void PlayBgm(bool isPlay)
    {
        if (isPlay)
        {
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }
    }

    public void EffectBgm(bool isPlay)
    {
        bgmEffect.enabled = isPlay;
    }

    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayer.Length; index++)
        {
            int loopIndex = (index + channelIndex) % sfxPlayer.Length;

            if (sfxPlayer[loopIndex].isPlaying)
                continue;

            int ranIndex = 0;
            if (sfx == Sfx.Hit || sfx == Sfx.Poop)
            {
                ranIndex = Random.Range(0, 2);
            }

            channelIndex = loopIndex;
            sfxPlayer[loopIndex].clip = sfxClip[(int)sfx];
            sfxPlayer[loopIndex].Play();
            break;
        }

    }
    public void SetMusicVolume(float volume)
    {
        bgmPlayer.volume = volume;
        if (bgm_Slider.value == 0)
        {
            bgm_Mute.SetActive(true);
        }
        else
        {
            bgm_Mute.SetActive(false);
        }
    }
    public void SfxVolume(float volume)
    {

        sfxVolume = volume;

        for (int index = 0; index < sfxPlayer.Length; index++)
        {
            sfxPlayer[index].volume = sfxVolume;
        }

        if (sfx_Slider.value == 0)
        {
            sfx_Mute.SetActive(true);
        }
        else
        {
            sfx_Mute.SetActive(false);
        }
    }

    public void BgmMute()
    {
        if (bgm_Slider.value == 0)
        {
            bgm_Slider.value = 1;
            bgm_Mute.SetActive(false);
        }
        else
        {
            bgm_Slider.value = 0;
            bgm_Mute.SetActive(true);
        }
    }
    public void SfxMute()
    {
        if (sfx_Slider.value == 0)
        {
            sfx_Slider.value = 1;
            sfx_Mute.SetActive(false);
        }
        else
        {
            sfx_Slider.value = 0;
            sfx_Mute.SetActive(true);
        }
    }
}
