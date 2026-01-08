using UnityEngine;
using UnityEngine.InputSystem;

public class TextInteract : MonoBehaviour
{
    public ContactManager contactManager;
    public void tryInteract(InputAction.CallbackContext ct) {
        GameObject g = contactManager.GetContact();
        if (g == null) return;
        DialogMain dialog = g.GetComponent<DialogMain>();
        if (dialog != null) {
            dialog.Interact();
        }
    }
    public void skip(InputAction.CallbackContext ct)
    {
        GameObject g = contactManager.GetContact();
        if (g == null) return;
        DialogMain dialog = g.GetComponent<DialogMain>();
        if (dialog != null)
        {
            dialog.skip();
        }
    }
}
