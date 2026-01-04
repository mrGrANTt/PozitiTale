using UnityEngine;

public class ParticlesSpawner : MonoBehaviour
{
    public GameObject prop;
    public float pereud;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > pereud)
        {
            timer = 0;
            GameObject obj = Instantiate(prop, new Vector2(Random.Range(-9f,9f), transform.position.y), Quaternion.identity);
            float rand = Random.Range(1f, 3f);
            obj.transform.localScale = new Vector2(
                obj.transform.localScale.x*rand, 
                obj.transform.localScale.y*rand);
        }
    }
}
