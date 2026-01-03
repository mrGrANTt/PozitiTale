using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    private string value = "";
    public Text text;

    private void Start() {
        value = text.text;
        text.text = "    " + value;
    }

    public void mouseEnter() {
        text.text = "> " + value;
    }

    public void mouseExit() {
        text.text = "    " + value;
    }
}
