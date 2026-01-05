using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    public GameObject person;

    void Update()
    {
        transform.position = person.transform.position + new Vector3(0, 0, -10);
    }
}
