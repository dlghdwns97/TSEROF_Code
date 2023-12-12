using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public AudioSource bgSound;
    public AudioClip[] bgList;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = new SoundManager();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if(_instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for(int i = 0; i < bgList.Length; i++)
        {
            if(arg0.name == bgList[i].name)
            {
                BgSoundPlay(bgList[i]);
            }
        }
    }

    private void BgSoundPlay(AudioClip audioClip)
    {
        bgSound.clip = audioClip;
        bgSound.loop = true;
        bgSound.volume = 0.25f;
        bgSound.Play();
    }
}
