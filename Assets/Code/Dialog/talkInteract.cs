using UnityEngine;

public class talkInteract : TextEvent
{
    bool first = true;
    public override void run(DialogMain parent)
    {
        GetComponent<Animator>().SetTrigger("talk");
        if(first) parent.run();
        else parent.end();
        first = !first;
    }
}
