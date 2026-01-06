using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject setings, buttons, menu;
    public GameKeybord gameKeybord;
    public Text screenText;

    public void CallbackPlay(InputAction.CallbackContext c) { Play(); }
    public void CallbackPause(InputAction.CallbackContext c) { Pause(); }
    public void CallbackBack(InputAction.CallbackContext c) { Back(); }

    public void Play() {
        gameKeybord.openMenu.performed += CallbackPause;
        gameKeybord.openMenu.performed -= CallbackPlay;
        gameKeybord.gameObject.GetComponent<Movement>().enabled = true;
        menu.SetActive(false);
    }
    public void Pause() {
        gameKeybord.openMenu.performed += CallbackPlay;
        gameKeybord.openMenu.performed -= CallbackPause;
        gameKeybord.gameObject.GetComponent<Movement>().enabled = false;
        menu.SetActive(true);
    }
    public void Back() {
        Vareables.saveData();
        setings.SetActive(false);
        buttons.SetActive(true);
        gameKeybord.openMenu.performed -= CallbackBack;
        gameKeybord.openMenu.performed += CallbackPlay;
    }
    public void Setings() {
        setings.SetActive(true);
        buttons.SetActive(false);
        gameKeybord.openMenu.performed += CallbackBack;
        gameKeybord.openMenu.performed -= CallbackPlay;
        updateScreenText(!Screen.fullScreen);
    }
    public void Save() { Vareables.saveData(); }
    public void Exit() { 
        SceneManager.LoadScene("MainMenu");
        Vareables.saveData();
    }
    public void newScreen() {
        Screen.fullScreen = !Screen.fullScreen;
        updateScreenText(Screen.fullScreen);
    }

    public void updateScreenText(bool isFull) {
        screenText.text = isFull ? "Window mode" : "Full screen";
    }
}
