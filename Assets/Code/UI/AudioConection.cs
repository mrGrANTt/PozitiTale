using UnityEngine;

public class AudioConection : MonoBehaviour
{
    public bool isMusic = false;
    public bool isSound = false;

    private AudioSource audioSource;
    private float startVolume;

    private void Start() { 
        audioSource = GetComponent<AudioSource>();
        startVolume = audioSource.volume;
    }

    void Update() {
        if(isMusic) audioSource.volume = startVolume*Vareables.Music;
        if (isSound) audioSource.volume = startVolume*Vareables.Sound;
    }
}
