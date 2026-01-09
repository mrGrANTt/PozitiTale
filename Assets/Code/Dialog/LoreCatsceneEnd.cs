using Unity.Mathematics;
using UnityEngine;

public class LoreCatsceneEnd : TextEvent
{
    public CameraMovment _camera;
    public Vector2 cleshPos;
    public GameObject clesh;
    public float moveFrom = 1;
    public float timeToMove = 1;

    private Vector3 start;
    private DialogMain dialog;
    private bool move = false;
    private float time = 0;
    public override void run(DialogMain parent)
    {
        dialog = parent;
        start = _camera.transform.position;
        move = true;
    }
    private void Update()
    {
        if (move) {
            time += Time.deltaTime;
            _camera.transform.position
                = new Vector3(start.x- math.min(time*moveFrom/timeToMove, moveFrom), start.y, start.z);
            if (time >= timeToMove) {
                move = false;
                _camera.enabled = true;
                dialog.end();
                clesh.transform.position = cleshPos;
                gameObject.SetActive(false);
            }
        }
    }
}
