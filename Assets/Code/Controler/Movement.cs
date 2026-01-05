using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    GameInput input;
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

        input = new GameInput();
        input.Enable();
    }
    private void FixedUpdate() {
        time += Time.deltaTime;
        if (time >= spriteChengSpeed)
        {
            time = 0;
            spriteFrame = (spriteFrame + 1) % up.Length;
        }

        Vector3 move = input.Game.Move.ReadValue<Vector2>();
        transform.position += move * moveSpeed;
        if (move.Equals(Vector3.zero)) spriteFrame = 0;


        if (move.x > 0) {
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
