using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public GameObject setings, buttons;

    public void Play() { SceneManager.LoadScene("Play"); }
    public void NewGame() { SceneManager.LoadScene("NewGame"); }
    public void Setings() { 
        setings.SetActive(true);
        buttons.SetActive(false); 
    }
    public void Exit() { Application.Quit(); }
}
