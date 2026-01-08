using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageControl : MonoBehaviour
{
    public Sprite[] textures;
    public float newPlateTime = 10f;
    public float fadeTime = 1f;
    public AudioSource _audio;

    private bool _isPlayed = false;
    private Image image;
    private float time = -3;
    private int lastPlate = 0;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update() {
        if(image == null) return;
        time += Time.deltaTime;

        if (time >= newPlateTime-fadeTime) {
            if (time < newPlateTime) {
                Color color = new Color(1f, 1f, 1f, (newPlateTime-time)/fadeTime);
                image.color = color;
            } else {
                Color color = new Color(1f, 1f, 1f, 0f);
                image.color = color;
                if (lastPlate >= textures.Length) {
                    SceneManager.LoadScene("Game");
                    return;
                }
                time = 0;
                image.sprite = textures[lastPlate++];
            }
        } else {
            Color color;
            if (time <= fadeTime) 
                color = new Color(1f, 1f, 1f, time/fadeTime);
            else {
                color = Color.white;
                if (lastPlate == textures.Length && !_isPlayed) {
                    _audio.Play();
                    _isPlayed = true;
                }
            }
            image.color = color;
        }
    }
}
