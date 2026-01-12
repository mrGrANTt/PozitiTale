using UnityEngine;

public class gate : MonoBehaviour
{
    public Sprite openedSprite;
    void Update()
    {
        if(Vareables.TalkWith)
        {
            GetComponent<SpriteRenderer>().sprite = openedSprite;
        }   
    }
}
