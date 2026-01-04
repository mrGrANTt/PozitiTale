using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject setings, buttons;
    public Text screenText;

    public void Play() { SceneManager.LoadScene("Play"); }
    public void NewGame() { SceneManager.LoadScene("NewGame"); }
    public void Setings() {
        setings.SetActive(true);
        buttons.SetActive(false);
        updateScreenText(!Screen.fullScreen);
    }
    public void Back() {
        setings.SetActive(false);
        buttons.SetActive(true);
    }
    public void Exit() { Application.Quit(); }

    public void newScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        updateScreenText(Screen.fullScreen);
    }
    public void updateScreenText(bool isFull)
    {
        screenText.text = isFull ? "Window mode" : "Full screen";
    }
}
