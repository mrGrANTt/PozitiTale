using UnityEngine;

public class HoverSound : HoverEvent
{
    public AudioSource audioSource;

    override public void Enter()
    {
        audioSource.Play();
    }

    override public void Exit() {}
}
