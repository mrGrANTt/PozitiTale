using UnityEngine;

public class HoverMove : HoverEvent
{
    public Vector2 moveTo = new Vector2(0f,0f);
    private Vector2 from;

    private void Start()
    {
        from = GetComponent<RectTransform>().localPosition;
    }

    public override void Enter()
    {
        GetComponent<RectTransform>().localPosition = moveTo;
    }
    public override void Exit()
    {
        GetComponent<RectTransform>().localPosition = from;
    }
}
