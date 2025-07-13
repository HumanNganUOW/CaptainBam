using UnityEngine;

public class testLookAt : MonoBehaviour
{
   [SerializeField]Transform mLookAt;
    public float initialMovespeed;
    public float increasedMovespeed;
    Vector3 dir;

    private void Update()
    {
        increasedMovespeed=initialMovespeed+(GetComponent<trailController>().TrailCount/2);


        dir=mLookAt.position-transform.position;
        float angle=Mathf.Atan2 (dir.y,dir.x)*Mathf.Rad2Deg;
        

        transform.rotation = Quaternion.Euler(0, 0, angle-90);
        transform.position = Vector3.MoveTowards(transform.position, mLookAt.position, increasedMovespeed * Time.deltaTime);



     
    }
}
