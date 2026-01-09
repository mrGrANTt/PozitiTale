using Unity.Mathematics;
using UnityEngine;

public class LoreCatsceneStart : TextEvent
{
    public GameKeybord keybord;
    public TextInteract interact;
    public CameraMovment _camera;
    public float moveTo = 1;
    public float timeToMove = 1;
    public DialogMain dialog;

    private Vector3 start;
    private bool move = false;
    private float time = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(time != -1) {
            _camera.enabled = false;
            interact.interactObj(dialog);
        }
    }
    public override void run(DialogMain parent) {
        move = true;
        start = _camera.transform.position;
    }
    private void Update() {
        if (move) {
            time += Time.deltaTime;
            _camera.transform.position
                = new Vector3(start.x+math.min(time*moveTo/timeToMove, moveTo), start.y, start.z);
            if(time >= timeToMove) {
                move = false;
                time = -1;
                dialog.run();
            }
        }
    }
}
