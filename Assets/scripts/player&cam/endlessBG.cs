using UnityEngine;

public class endlessBG : MonoBehaviour
{
    private float startPos ,length;
    public float parallaxEffect;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.y;
        length=GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movement = Camera.main.transform.position.y;

        transform.position=new Vector3 (transform.position.x, startPos, transform.position.z);


        if (movement > startPos + length) startPos += length;
    }
}
