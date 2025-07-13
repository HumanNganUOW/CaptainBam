using System.Collections;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] Transform sp1;
    [SerializeField] Transform sp2;
    [SerializeField] Transform sp3;

    [SerializeField] GameObject fruit;
    [SerializeField] GameObject barrier;
    [SerializeField] GameObject biggie;
    GameObject empty;

    private void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        int spawnIndex=Random.Range(0,24);

        switch (spawnIndex)
        {
            case 0:  easierSpawn(empty, biggie, empty);break;
            case 1:  easierSpawn(empty, fruit, barrier);break;
            case 2:  easierSpawn(barrier, fruit, biggie);break;
            case 3:  easierSpawn(biggie, empty, barrier);break;
            case 4:  easierSpawn(biggie, empty, fruit);break;
            case 5:  easierSpawn(barrier, fruit, biggie);break;
            case 6:  easierSpawn(fruit, biggie, fruit);break;
            case 7:  easierSpawn(barrier, fruit, barrier);break;
            case 8:  easierSpawn(barrier, empty, biggie);break;
            case 9:  easierSpawn(barrier, biggie, empty);break;
            case 10:  easierSpawn(biggie, empty, barrier);break;
            case 11:  easierSpawn(empty, barrier, empty);break;
            case 12:  easierSpawn(fruit, empty, fruit);break;
            case 13:  easierSpawn(biggie, barrier, empty);break;
            case 14:  easierSpawn(empty, biggie, barrier);break;
            case 15:  easierSpawn(empty, barrier, biggie);break;
            case 16:  easierSpawn(fruit, fruit, biggie);break;
            case 17:  easierSpawn(barrier, fruit, fruit);break;
            case 18:  easierSpawn(empty, fruit, empty);break;
            case 19:  easierSpawn(empty, empty, barrier);break;
            case 20:  easierSpawn(empty, barrier, empty);break;
            case 21:  easierSpawn(biggie, empty, empty);break;
            case 22:  easierSpawn(fruit, fruit, fruit);break;
        }
            
      

        yield return new WaitForSeconds(1.7f);
        StartCoroutine(spawn());
    }

    void easierSpawn(GameObject a,GameObject b, GameObject c)
    {
        if (a != null)  
        Instantiate(a, sp1.position, Quaternion.identity);
        if (b != null)
        Instantiate(b, sp2.position, Quaternion.identity);
        if(c!=null)
        Instantiate(c, sp3.position, Quaternion.identity);
    }
}
