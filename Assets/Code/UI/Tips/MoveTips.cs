using Unity.Mathematics;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTips : MonoBehaviour
{
    public float speed = 1f;
    public float LastY = 3200f;
    public int finishTime = 1000;

    private float time = 0;

    private void Update()
    {
        time += Time.deltaTime;
        GetComponent<RectTransform>().localPosition = new Vector2(0, math.min(LastY, -3450 + time * speed));
        if (time > finishTime) SceneManager.LoadScene("MainMenu");
    }
}
