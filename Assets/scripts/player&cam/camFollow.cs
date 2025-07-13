using System.Collections;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    [SerializeField] Transform playerTrans;
    public float yOffset;
    public bool isBoosting;

    private void Update()
    {
        //Vector3 playerPos=new Vector3(playerTrans.position.x,playerTrans.position.y+yOffset,-10f);
        //float distance=Vector3.Distance(playerTrans.position, playerPos)*Time.deltaTime;

        //transform.position = Vector3.MoveTowards(transform.position, playerPos, distance/1.5f);

        transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y+yOffset,-10f);


       
   
    }


    public IEnumerator boost()
    {
        if (yOffset > -1.2f&&yOffset<0.1f&&isBoosting)
        {
            yOffset -= 0.15f;
        }
        else if (yOffset < -0.1f)
        {
            isBoosting = false;
            yOffset +=0.01f;
        }
        else yOffset = 0;

        yield return new WaitForSeconds(0.1f);
        StartCoroutine(boost());
    }
}
