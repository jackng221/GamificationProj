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

    public AudioSource bgmPlayer;
    public AudioSource sfxPlayer;

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
        DOTween.To(() => bgmPlayer.volume, x => bgmPlayer.volume = x, 0, 1f)
            .OnComplete( () => {
                //Debug.Log("volume to 0");
                bgmPlayer.clip = bgm;
                bgmPlayer.Play();
                DOTween.To(() => bgmPlayer.volume, y => bgmPlayer.volume = y, 1, 1f)
                .OnComplete( ()=> {
                    //Debug.Log("volume to 1");
                });
            });
    }
    public void PlaySfx(AudioClip sfx)
    {
        sfxPlayer.PlayOneShot(sfx);
    }
    public AudioSource GetBgmPlayer()
    {
        return bgmPlayer;
    }
    [ContextMenu("BgmPlay")]
    void TestPlay()
    {
        bgmPlayer.Play();
    }
}
