using UnityEngine;
using UnityEngine.InputSystem;

public class GameKeybord : MonoBehaviour
{
    private GameInput input;

    public InputAction move;
    public InputAction cansel;
    public InputAction openMenu;

    void Start()
    {
        input = new GameInput();
        input.Enable();

        move = input.Game.Move;
        cansel = input.Game.Cansel;
        openMenu = input.Game.OpenMenu;

        openMenu.performed += GetComponent<GameMenu>().CallbackPause;
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
