using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Text text;
    void Update()
    {
        text.text = " " + (int)(-transform.position.y * 100);
    }
}
