using UnityEngine;

public class Particles : MonoBehaviour
{
    public Sprite[] textures;

    void Start()
    {
        if(textures.Length > 0)
            gameObject.GetComponent<SpriteRenderer>().sprite = textures[Random.Range(0, textures.Length)];
    }
}
