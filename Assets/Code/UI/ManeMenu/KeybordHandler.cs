using UnityEngine;
using UnityEngine.InputSystem;

public class KeybordHandler : MonoBehaviour
{ //https://www.youtube.com/watch?v=kP7BawiCCZU
    public ButtonControl buttonControl;
    private GameInput input;
    
    private void Start()
    {
        input = new GameInput();
        input.Enable();
        input.Menu.Cansel.performed += hendleCansel;
    }

    private void hendleCansel (InputAction.CallbackContext ia)
    {
        Debug.Log(1);
        buttonControl.Back();
    }
}
