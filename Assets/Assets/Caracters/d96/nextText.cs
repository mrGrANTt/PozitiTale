using Unity.Mathematics;
using UnityEngine;

public class nextText : TextEvent
{
    [TextArea()]
    public string[] text2;
    [TextArea()]
    public string[] text3;
    [TextArea()]
    public string[] text4;
    [TextArea()]
    public string[] text5;
    [TextArea()]
    public string[] text6;

    private string[][] all;
    private int count;

    private void Start()
    {
        count = 0;
        all = new string[5][];
        all[0] = text2;
        all[1] = text3;
        all[2] = text4;
        all[3] = text5;
        all[4] = text6;
    }

    public override void run(DialogMain parent)
    {
        parent.texts = all[math.min(count++, 4)];
        parent.end();
    }
}
