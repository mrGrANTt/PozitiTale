using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SofaWork : MonoBehaviour
{
    public Texture2D sofa1, sofa2;
    public float changeTime = 0.5f;
    public float changeNormalChanse = 0.01f;
    public float changeCreppeChanse = 0.9f;
    public float maxMove = 0.1f;

    private Vector3 startPos;
    private RawImage image;
    private RectTransform _transform;
    private float time = 0;

    private void Start()
    {
        _transform = GetComponent<RectTransform>();
        startPos = _transform.position;
        image = GetComponent<RawImage>();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (image != null && time >= changeTime)
        {
            time = 0;
            float rand = Random.Range(0f, 1f);
            if (image.texture == sofa1 && rand <= changeNormalChanse)
                image.texture = sofa2;
            else if (rand <= changeCreppeChanse)
                image.texture = sofa1;
        }
        Mouse mouse = Mouse.current;
        if (mouse != null) {
            float x = System.Math.Min(System.Math.Max(mouse.position.value.x, 0), Screen.width),
                y = System.Math.Min(System.Math.Max(mouse.position.value.y, 0), Screen.height);

            _transform.position = new Vector3(
                startPos.x + x * maxMove / Screen.width,
                startPos.y + y * maxMove / Screen.height,
                startPos.z
                );
        }
    }
}
