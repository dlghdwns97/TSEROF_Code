using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class BgmController : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider BGMSlider;
    public Slider SFXSlider;
    private bool _isBGMPlay = true;
    private bool _isSFXPlay = true;
    private float bgmSound;
    private float sfxSound;

    public void BgmControl(out float bgmSound)
    {
        bgmSound = BGMSlider.value;
    }
    public void BgmControl()
    {
        BgmControl(out bgmSound);
        if (bgmSound == -40f)
        {
            masterMixer.SetFloat("BGM", -80);
        }
        else
        {
            masterMixer.SetFloat("BGM", bgmSound);
        }
    }

    public void SFXControl(out float sfxSound)
    {
        sfxSound = SFXSlider.value;
    }
    public void SFXControl()
    {
        SFXControl(out sfxSound);
        if (sfxSound == -40f)
        {
            masterMixer.SetFloat("SFX", -80);
        }
        else
        {
            masterMixer.SetFloat("SFX", sfxSound);
        }
    }

    public void ToggleBGMVolume()
    {
        if (_isBGMPlay == false)
        {
            masterMixer.SetFloat("BGM",bgmSound);
            _isBGMPlay = true;
        }
        else if(_isBGMPlay == true)
        {
            masterMixer.SetFloat("BGM", -80);
            _isBGMPlay = false;
        }
    }

    public void ToggleSFXVolume()
    {
        if (_isSFXPlay == false)
        {
            masterMixer.SetFloat("SFX", sfxSound);
            _isSFXPlay = true;
        }
        else if (_isSFXPlay == true)
        {
            masterMixer.SetFloat("SFX", -80);
            _isSFXPlay = false;
        }
    }
}
