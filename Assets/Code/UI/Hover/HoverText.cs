using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class HoverText : HoverEvent
{
    public Text text;
    private string value = "";

    private void Start()
    {
        if (text != null)
        {
            value = text.text;
            text.text = "    " + value;
        }
    }

    override public void Enter() {
        if (text != null) text.text = "> " + value;
    }

    override public void Exit() {
        if (text != null) text.text = "    " + value;
    }
}
