using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] CanvasGroup menu;
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider effectsSlider;
    public void ShowMenu()
    {

        menu.gameObject.SetActive(true);
        menu.alpha = 0;
        menu.DOFade(1, fadeDuration).SetUpdate(true);
        Time.timeScale = 0;
        musicSlider.value = AudioManager.Instance.GetMusicVolume() * musicSlider.maxValue;
        effectsSlider.value = AudioManager.Instance.GetEffectsVolume() * effectsSlider.maxValue;
    }
    public void HideMenu()
    {

        menu.DOFade(0, fadeDuration).OnComplete(() =>
        {
            menu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        ).SetUpdate(true);

    }

    public void MusicVolumeChange()
    {
        AudioManager.Instance.SetMusicVolume(musicSlider.value / musicSlider.maxValue);
    }
    public void EffectVolumeChange()
    {
        AudioManager.Instance.SetEffectsVolume(effectsSlider.value / effectsSlider.maxValue);
    }
}
