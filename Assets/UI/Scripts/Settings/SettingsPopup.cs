using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Game.UI
{
    public sealed class SettingsPopup : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup canvasGroup;

        [SerializeField]
        private Slider soundSlider;

        [SerializeField]
        private Slider musicSlider;


        [SerializeField]
        private AudioMixer mixer;

        private void OnEnable()
        {
            this.canvasGroup.alpha = 0.5f;
            this.canvasGroup.DOFade(1, 0.5f);

            this.mixer.GetFloat("SoundVolume", out float soundVolume);
            this.soundSlider.value = DbToPercent(soundVolume);
            this.soundSlider.onValueChanged.AddListener(this.OnSoundVolumeChanged);

            this.mixer.GetFloat("MusicVolume", out float musicVolume);
            this.musicSlider.value = DbToPercent(musicVolume);
            this.musicSlider.onValueChanged.AddListener(this.OnMusicVolumeChanged);
        }

        private void OnDisable()
        {
            this.soundSlider.onValueChanged.RemoveListener(this.OnSoundVolumeChanged);
            this.musicSlider.onValueChanged.RemoveListener(this.OnMusicVolumeChanged);
        }

        private void OnSoundVolumeChanged(float volume)
        {
            this.mixer.SetFloat("SoundVolume", this.PercentToDb(volume));
        }

        private float PercentToDb(float volume)
        {
            return volume switch
            {
                <= 0 => -80,
                >= 1 => 0,
                _ => 20 * Mathf.Log10(volume)
            };
        }
        
        private float DbToPercent(float db)
        {
            return db switch
            {
                <= -80 => 0,
                >= 0 => 1,
                _ => Mathf.Pow(10, db / 20)
            };
        }

        private void OnMusicVolumeChanged(float volume)
        {
            this.mixer.SetFloat("MusicVolume", this.PercentToDb(volume));
        }
    }
}