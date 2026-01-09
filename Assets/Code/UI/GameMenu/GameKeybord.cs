using UnityEngine;
using UnityEngine.InputSystem;

public class GameKeybord : MonoBehaviour
{
    private GameInput input;

    public InputAction move;
    public InputAction interact;
    public InputAction cansel;
    public InputAction openMenu;

    public GameMenu menu; 
    public TextInteract textInteract;
    void OnEnable()
    {

        input = new GameInput();
        input.Enable();

        move = input.Game.Move;
        interact = input.Game.Interact;
        cansel = input.Game.Cansel;
        openMenu = input.Game.OpenMenu;

        GameSetup();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    // Setup
    public void GameSetup()
    {
        Debug.Log("GameSetup");
        move.Enable();
        openMenu.performed -= menu.CallbackPlay;
        openMenu.performed += menu.CallbackPause;
        interact.performed += textInteract.tryInteract;
        cansel.performed -= textInteract.skip;
    }
    public void DialogSetup()
    {
        Debug.Log("DialogSetup");
        move.Disable();
        openMenu.performed -= menu.CallbackPause;
        interact.performed -= textInteract.tryInteract;
        cansel.performed += textInteract.skip;
    }
    public void MenuSetup()
    {
        Debug.Log("MenuSetup");
        move.Disable();
        openMenu.performed -= menu.CallbackPause;
        openMenu.performed -= menu.CallbackBack;
        openMenu.performed += menu.CallbackPlay;
    }
    public void SetingsSetup()
    {
        Debug.Log("SetingsSetup");
        openMenu.performed -= menu.CallbackPlay;
        openMenu.performed += menu.CallbackBack;
    }
}