using UnityEngine;
using UnityEngine.UI;

public class GameSaved : MonoBehaviour
{
    public float disableTime = 1.0f;
    public Color color;

    private float time = 0;

    private void OnEnable() {
        GetComponent<Text>().color = color;
        time = 0;
    }


    private void Update() {
        time += Time.deltaTime;
        if(time > disableTime / 2) {
            if(time > disableTime) gameObject.SetActive(false);
            GetComponent<Text>().color = new Color(color.r, color.g, color.b, 2*(disableTime-time)/disableTime);
        }
    }
}
