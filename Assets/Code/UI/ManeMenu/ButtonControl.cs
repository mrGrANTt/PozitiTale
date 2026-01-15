using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject setings, buttons;
    public Text screenText;
    public AudioConection _audio;

    public void Play() {
        StartCoroutine(fadeMusic(Vareables.FirstRun));
    }
    public void NewGame() {
        Vareables.FirstRun = false;
        Vareables.TalkWith = false;
        Vareables.saveData();
        StartCoroutine(fadeMusic(true));
    }
    private IEnumerator fadeMusic(bool comics)
    {
        _audio.Toggle();
        yield return new WaitForSeconds(_audio.fadeTime);
        Vareables.FirstRun = false;
        Vareables.saveData();
        if (comics) SceneManager.LoadScene("Comics");
        else SceneManager.LoadScene("Game");
    }
    public void Setings() {
        setings.SetActive(true);
        buttons.SetActive(false);
        updateScreenText(!Screen.fullScreen);
    }
    public void Back() {
        Vareables.saveData();
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
