using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class mrg_LoreCatsceneStart : TextEvent
{
    public GameKeybord keybord;
    public TextInteract interact;
    public Animator anim;
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
    private IEnumerator waiter()
    {
        yield return new WaitForSeconds(2.1f);
        dialog.run();
    }

    private void Update() {
        if (move) {
            time += Time.deltaTime;
            _camera.transform.position
                = new Vector3(start.x+math.min(time*moveTo/timeToMove, moveTo), start.y, start.z);
            if(time >= timeToMove) {
                move = false;
                time = -1;
                anim.SetTrigger("talk");
                StartCoroutine(waiter());
            }
        }
    }
}
