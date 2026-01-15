using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameKeybord gameKeybord;
    public Image image;
    public float exitTime = 5f;

    private float time = 0;
    public bool play = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            gameKeybord.enabled = false;
            play = true;
        }
    }

    private void Update()
    {
        if(play) {
            time += Time.deltaTime;
            image.color = new Color(0, 0, 0, time / exitTime);
            if (time >= exitTime)
                SceneManager.LoadScene("Tips");
        }
    }
}
