using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject setings, buttons, menu, saveIndecator;
    public GameKeybord gameKeybord;
    public Text screenText;

    private void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void CallbackPlay(InputAction.CallbackContext c) { Play(); }
    public void CallbackPause(InputAction.CallbackContext c) { Pause(); }
    public void CallbackBack(InputAction.CallbackContext c) { Back(); }

    public void Play() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameKeybord.GameSetup();
        menu.SetActive(false);
    }
    public void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameKeybord.MenuSetup();
        menu.SetActive(true);
    }
    public void Back() {
        Vareables.saveData();
        setings.SetActive(false);
        buttons.SetActive(true);
        gameKeybord.MenuSetup();
    }
    public void Setings() {
        setings.SetActive(true);
        buttons.SetActive(false);
        gameKeybord.SetingsSetup();
        updateScreenText(!Screen.fullScreen);
    }
    public void Save() { 
        saveIndecator.SetActive(true); 
        Vareables.saveData();
    }
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
