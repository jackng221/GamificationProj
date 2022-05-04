using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioPlayer : MonoBehaviour
{
    private static AudioPlayer instance;
    public static AudioPlayer Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public AudioSource audioSource;

    public AudioClip titleBgm;
    public AudioClip gameBgm;

    public AudioClip winSfx;
    public AudioClip loseSfx;
    public AudioClip buttonSfx;

    private void Start()
    {
        SwitchBgm(titleBgm);
    }
    public void SwitchBgm(AudioClip bgm)
    {
        DOTween.To(() => audioSource.volume, x => audioSource.volume = x, 0, 1f)
            .OnComplete( () => {
                //Debug.Log("volume to 0");
                audioSource.clip = bgm;
                audioSource.Play();
                DOTween.To(() => audioSource.volume, y => audioSource.volume = y, 1, 1f)
                .OnComplete( ()=> {
                    //Debug.Log("volume to 1");
                });
            });
    }
    public void PlaySfx(AudioClip sfx)
    {
        AudioSource.PlayClipAtPoint(sfx, Vector3.zero, 0.6f);
    }
    public AudioSource GetAudioSource()
    {
        return audioSource;
    }
    [ContextMenu("Play")]
    void TestPlay()
    {
        audioSource.Play();
    }
}
