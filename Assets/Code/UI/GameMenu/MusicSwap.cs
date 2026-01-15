using UnityEngine;

public class MusicSwap : MonoBehaviour
{
    public AudioConection music;
    public AudioConection music2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") {
            music.Toggle();
            music2.Toggle();
        }
    }
}
