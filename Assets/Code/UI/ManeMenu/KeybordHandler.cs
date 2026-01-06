using UnityEngine;
using UnityEngine.InputSystem;

public class KeybordHandler : MonoBehaviour
{ 
    public ButtonControl buttonControl;
    private GameInput input;
    
    private void Start()
    {
        input = new GameInput();
        input.Enable();
        input.Menu.Cansel.performed += hendleCansel;
    }
    private void OnDisable() {
        input.Disable();
    }

    private void hendleCansel (InputAction.CallbackContext ia) { buttonControl.Back(); }
}
