using System.Collections;
using UnityEngine;

public class talkInteract : TextEvent
{
    public bool waitOnlyFirstTime = false;
    public bool waitEvryFirstTime = false;
    public bool waitEvryLastTime = false;
    public bool waitEvryTime = false;
    public float wait = 0;
    bool _First = true;
    public override void run(DialogMain parent)
    {
        GetComponent<Animator>().SetTrigger("talk");
        StartCoroutine(waiter(parent));
    }
    IEnumerator waiter(DialogMain parent)
    {
        if(wait > 0) {
            if (waitEvryTime 
                || (waitEvryFirstTime && parent.dialogState == 1) 
                || (waitOnlyFirstTime && _First)
                || (waitEvryLastTime && parent.dialogState == 2)) {
                yield return new WaitForSeconds(wait);
                _First = false;
            }
        }
        if (parent.dialogState==1) parent.run();
        else parent.end();
    }
}
