using System.Collections;
using UnityEngine;

public class LeftRightButton : MonoBehaviour
{
    [SerializeField] GameObject target;
    Vector3 t = new();
    float targetX;

    AudioManager Amanager;



    private void Awake()
    {
   
       targetX = t.x;
    }

    private void Start()
    {
        Amanager = AudioManager.instance;
    }

    public void leftButton()
    {
        if (target != null)
        {
            Amanager.Move();
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(xDec());
           
        }
    } 
    public void rightButton()
    {
        if (target != null)
        {
            Amanager.Move();
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine (xInc());
        }
    }

    IEnumerator xInc()
    {
     

        if (targetX < 1.5f)
        {
            t = target.transform.position;
            targetX += 0.8f;
            target.transform.position = new Vector3(targetX, t.y, t.z);
            if (targetX > 0.05f||targetX<-0.05f)
            {
                yield return new WaitForSeconds(0.1f);
                StartCoroutine(xInc());
            }
            else targetX = 0;
        }

    }
    
    IEnumerator xDec()
    {

        if (targetX > -1.5f)
        {
            t = target.transform.position;
            targetX -= 0.8f;
            target.transform.position = new Vector3(targetX, t.y, t.z);
            if (targetX > 0.05f || targetX < -0.05f)
            {
                yield return new WaitForSeconds(0.1f);
                StartCoroutine(xDec());
            }
            else targetX = 0;
        }

    }
}
