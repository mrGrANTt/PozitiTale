using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class AudioConection : MonoBehaviour
{
    public bool isMusic = false;
    public bool isSound = false;
    public float fadeTime = 0.5f;
    public bool startFade = true;
    public bool fadeIn;

    private AudioSource audioSource;
    private float startVolume;
    private float fading;
    private bool runFade;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        startVolume = audioSource.volume;
        runFade = startFade;
        fading = fadeIn ? 0 : fadeTime;
        if(!runFade && fadeIn) fadeIn = false;
    }

    void Update() {
        float fade = 1;
        if (fadeTime > 0) {
            if(runFade && (fading > 0 || fading < fadeTime)) fading += Time.deltaTime * (fadeIn ? 1 : -1);
            if (fading < 0 || fading > fadeTime) fading = fadeIn ? fadeTime : 0;
            if (fading == 0 || fading == fadeTime) runFade = false;
            fade = fading / fadeTime;
        }
        
        if (isMusic) audioSource.volume = fade*startVolume*Vareables.Music;
        if (isSound) audioSource.volume = fade*startVolume*Vareables.Sound;
    }

    public void Toggle()
    {
        fadeIn = !fadeIn;
        runFade = true;
    }
}
