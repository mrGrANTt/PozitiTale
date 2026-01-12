using UnityEngine;

public class boon : talkInteract
{
    public Animator animator;
    public override void run(DialogMain parent)
    {
        animator.SetTrigger("talk");
        base.run(parent);
    }
}
