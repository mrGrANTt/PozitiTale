using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class DialogMain : MonoBehaviour
{
    public Text text;
    public GameObject parent;
    public AudioSource audioSource;
    public float simbolPearSecond = 5;
    public float soundPeriod = 0.1f;
    public GameKeybord gameKeybord;
    public bool needMoveOut = false;
    public float dialogDistance = 0.2f;

    public TextEvent beforeText;
    [TextArea()]
    public string[] texts;
    public TextEvent afterText;
    public int dialogState = 0;

    protected int text_index = -1;
    protected float time = 0;
    protected float playSoundTimer = 0;

    public void Interact()
    {
        if (text_index != -1) return;
        dialogState = 1;
        if (beforeText != null) { beforeText.run(this); }
        else run();
    }
    public void skip()
    {
        if (text_index != -1 && text_index < texts.Length) 
            time = texts[text_index].Length/simbolPearSecond; 
    }

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
        dialogState = 0;
    }

    private void Update()
    {
        if (text_index > -1 && text_index < texts.Length) {
            time += Time.deltaTime;
            playSoundTimer += Time.deltaTime;
            text.text = texts[text_index].Substring(0, math.min(
                (int) (time*simbolPearSecond), texts[text_index].Length));
            if(playSoundTimer >= soundPeriod && text.text.Length > 0 
                && text.text[text.text.Length - 1] != ' '
                && text.text.Length < texts[text_index].Length)
            {
                playSoundTimer = 0;
                audioSource.Play();
            }
            if (time * simbolPearSecond >= texts[text_index].Length 
                && gameKeybord != null && gameKeybord.interact.IsPressed()) {
                time = 0;
                if (++text_index >= texts.Length)
                {
                    dialogState = 2;
                    if (afterText != null) afterText.run(this);
                    else end();
                }
            }
        }
    }
}
