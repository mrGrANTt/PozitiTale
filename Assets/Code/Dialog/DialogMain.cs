using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class DialogMain : MonoBehaviour
{
    public Text text;
    public GameObject parent;
    public float simbolPearSecond = 5;
    public GameKeybord gameKeybord;

    public TextEvent beforeText;
    public string[] texts;
    public TextEvent afterText;

    private int text_index = -1;
    private float time = 0;

    public void Interact()
    {
        if (text_index != -1) return;
        gameKeybord.DialogSetup();
        if (beforeText != null) { beforeText.run(this); }
        else run();
    }
    public void skip() { time = texts[text_index].Length/simbolPearSecond; }

    public void run()
    {
        text.text = "";
        parent.SetActive(true);
        text_index = 0;
    }

    public void end()
    {
        parent.SetActive(false);
        text_index = -1;
        gameKeybord.GameSetup();
    }

    private void Update()
    {
        if (text_index != -1) {
            time += Time.deltaTime;
            text.text = texts[text_index].Substring(0, math.min(
                (int) (time*simbolPearSecond), texts[text_index].Length));
            if(time * simbolPearSecond >= texts[text_index].Length 
                && gameKeybord != null && gameKeybord.interact.IsPressed())
            {
                time = 0;
                if(++text_index >= texts.Length)
                {
                    if(afterText!= null) afterText.run(this);
                    else end();
                }
            }
        }
    }
}
