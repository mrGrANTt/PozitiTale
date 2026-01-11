using System.Collections;
using UnityEngine;

public class talkInteract : TextEvent
{
    public bool waitOnlyFirstTime = false;
    public float wait = 0;
    bool first = true;
    bool _First = true;
    public override void run(DialogMain parent)
    {
        GetComponent<Animator>().SetTrigger("talk");
        StartCoroutine(waiter(parent));
    }
    IEnumerator waiter(DialogMain parent)
    {
        if(wait > 0) {
            if (waitOnlyFirstTime) {
                if (_First) {
                    yield return new WaitForSeconds(wait);
                    _First = false;
                }
            }
            else {
                yield return new WaitForSeconds(wait);
            }
        }
        if (first) parent.run();
        else parent.end();
        first = !first;
    }
}
