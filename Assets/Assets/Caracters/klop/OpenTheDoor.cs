using UnityEngine;

public class OpenTheDoor : TextEvent
{
    public override void run(DialogMain parent)
    {
        Vareables.TalkWith = true;
        parent.end();
    }
}
