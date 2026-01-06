using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    public float spriteChengSpeed = 0.25f;
    public GameObject interact;
    public Sprite[] up;
    public Sprite[] down;
    public Sprite[] left;
    public Sprite[] right;

    public float rotationZ = 0;
    private float time = 0;
    private int spriteFrame = 0;
    private SpriteRenderer _renderer;
    void Start()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate() {
        time += Time.deltaTime;
        if (time >= spriteChengSpeed)
        {
            time = 0;
            spriteFrame = (spriteFrame + 1) % up.Length;
        }

        Vector3 move = GetComponent<GameKeybord>().move.ReadValue<Vector2>();
        transform.position += move * moveSpeed;


        if (move.x == 0 && move.y == 0) { 
            spriteFrame = 0;
            switch(rotationZ)
            {
                case 0: _renderer.sprite = right[spriteFrame]; break;
                case 90: _renderer.sprite = up[spriteFrame]; break;
                case 180: _renderer.sprite = left[spriteFrame]; break;
                case -90: _renderer.sprite = down[spriteFrame]; break;
            }
        }
        else if (move.x > 0) {
            _renderer.sprite = right[spriteFrame];
            rotationZ = 0;
        }
        else if (move.x < 0) {
            _renderer.sprite = left[spriteFrame];
            rotationZ = 180;
        }
        else if (move.y > 0) {
            _renderer.sprite = up[spriteFrame];
            rotationZ = 90;
        }
        else if (move.y < 0) {
            _renderer.sprite = down[spriteFrame];
            rotationZ = -90;
        }
        interact.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
