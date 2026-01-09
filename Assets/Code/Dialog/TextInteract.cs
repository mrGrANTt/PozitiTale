using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TextInteract : MonoBehaviour
{
    public ContactManager contactManager;

    private DialogMain last;
    public void tryInteract(InputAction.CallbackContext ct)
    {
        GameObject g = contactManager.GetContact();
        if (g == null) return;
        DialogMain dialog = g.GetComponent<DialogMain>();
        if (dialog != null)
        {
            last = dialog;
            Vector2 dir = g.transform.position - transform.position;
            if (dialog.needMoveOut && dir.sqrMagnitude < dialog.dialogDistance)
                StartCoroutine(moveBack(g.transform.position - transform.position));
            else
            {
                GetComponent<GameKeybord>().DialogSetup();
                dialog.Interact();
            }
        }
    }
    public void interactObj(DialogMain dialog)
    {
        last = dialog;
        GetComponent<GameKeybord>().DialogSetup();
        dialog.Interact();
    }

    IEnumerator moveBack(Vector2 direct)
    {   
        GetComponent<GameKeybord>().DialogSetup();
        Vector2 now = direct;
        float time = 0;
        Movement movement = GetComponent<Movement>();
        movement.enabled = false;
        Sprite[] sprites;

        if (movement.rotationZ % 180 == 0)
            if (movement.rotationZ == 0) {
                sprites = movement.right;
                direct = new Vector2(-1,0);
            }
            else {
                sprites = movement.left;
                direct = new Vector2(1, 0);
            }
        else
            if (movement.rotationZ == 90) {
                sprites = movement.up;
                direct = new Vector2(0, -1);
            }
            else { 
                sprites = movement.down;
                direct = new Vector2(0, 1);
            }

        while (now.sqrMagnitude < last.dialogDistance)
        {
            time += Time.fixedDeltaTime;
            transform.position += (Vector3) (direct * movement.moveSpeed);
            GetComponent<SpriteRenderer>().sprite 
                = sprites[(int) (time / movement.spriteChengSpeed) % sprites.Length];
            now += direct * movement.moveSpeed;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        movement.enabled = true;
        last.Interact();
    }
    public void skip(InputAction.CallbackContext ct)
    {
        if (last != null) {
            last.skip();
        }
    }
}
