using UnityEngine;
using UnityEngine.UI;

public class ToOtherLocation : MonoBehaviour
{
    public Image balck;
    public Vector2 to;
    public float fadeTime = 1;
    public GameKeybord keybord;
    public int rotAfterTp;
    public bool neadTalk = false;

    private float time;
    private bool tp = false;
    private Collider2D collision;
    private void Start() { time = -fadeTime; }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((neadTalk && Vareables.TalkWith) || !neadTalk)
        {
            if (collision.tag == "Player"){
                this.collision = collision;
                tp = true;
                keybord.move.Disable();
            }
        }
    }
    private void Update()
    {
        if(tp) {
            time += Time.deltaTime;
            float y = (1-time*time/fadeTime);
            balck.color = new Color(0,0,0,y);
            if (time > 0) { 
                collision.transform.position = to;
                collision.GetComponent<Movement>().rotationZ = rotAfterTp;
            }
            if(y<0) {
                tp = false;
                time = -fadeTime;
                keybord.move.Enable();
            }
        }
    }
}
