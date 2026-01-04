using UnityEngine;

public class HoverScale : HoverEvent
{
    public RectTransform _transform;
    public float multiplier;

    public override void Enter() {
        _transform.localScale *= multiplier;
    }

    public override void Exit()
    {
        _transform.localScale /= multiplier;
    }
}
