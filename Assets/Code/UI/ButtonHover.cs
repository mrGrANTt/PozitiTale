using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour
{
    private HoverEvent[] eventHandle;

    private void Start() {
        eventHandle = GetComponents<HoverEvent>();
        EventTrigger et = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener(mouseEnter);
        et.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener(mouseExit);
        et.triggers.Add(entry);

    }

    public void mouseEnter(BaseEventData data) {
        foreach(HoverEvent he in eventHandle)
        {
            he.Enter();
        }
    }

    public void mouseExit(BaseEventData data)
    {
        foreach (HoverEvent he in eventHandle)
        {
            he.Exit();
        }
    }
}
