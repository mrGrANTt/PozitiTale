using Unity.Mathematics;
using UnityEngine;

public class DialogMainWG : DialogMain
{
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
                GetComponent<Animator>().SetTrigger("talk");
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
