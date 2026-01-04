using UnityEngine;
using UnityEngine.UI;

public class ScrollbarHendling : MonoBehaviour
{
    public Scrollbar music, sound;

    private void Start()
    {
        music.value = Vareables.Music;
        sound.value = Vareables.Sound;
    }

    public void scrollSounds(float val) { Vareables.Sound = val; }
    public void scrollMusic(float val) { Vareables.Music = val; }
}
