using UnityEngine;

public class EndGameDoor : MonoBehaviour
{
    public AudioSource source;
    public AudioSource music;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        source.Play();
        music.Stop();
        Destroy(gameObject);
    }
}
