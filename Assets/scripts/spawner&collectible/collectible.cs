using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectible : MonoBehaviour
{
    [SerializeField] Sprite biggie;
    [SerializeField] Sprite barrier;
    [SerializeField] Sprite apple;
    [SerializeField] Sprite banana;
    [SerializeField] Sprite Wmelon;
    [SerializeField] Sprite grape;
    [SerializeField] Sprite diamond;

    AudioManager Amanager;

    int fruitIndex;
    SpriteRenderer sr;
    trailController tC;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        tC = GameObject.FindGameObjectWithTag("Player").GetComponent<trailController>();
    }

    private void Start()
    {
        Amanager = AudioManager.instance;

        if (this.gameObject.CompareTag("barrier")) 
        {
            sr.sprite = barrier;
        }
        else if (this.gameObject.CompareTag("biggie")) 
        {
            sr .sprite = biggie;
        }
        else if (this.gameObject.CompareTag("fruit")) 
        {
            fruitIndex=Random.Range(0, 5);
            switch (fruitIndex)
            {
                case 0:sr.sprite= apple; break;
                case 1:sr.sprite= banana; break;
                case 2:sr.sprite= Wmelon; break;
                case 3:sr.sprite= grape; break;
                case 4:sr.sprite= diamond; break;
            }
        }

    }

    IEnumerator lose()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("LoseScreen");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (this.gameObject.CompareTag("barrier"))
            {
                tC.hitBarrier();
                Amanager.Bump();
            }
            else if (this.gameObject.CompareTag("biggie"))
            {
                tC.TrailCount = 0;
                tC.gameObject.GetComponent<testLookAt>().initialMovespeed = 1;
                tC.smoke.SetActive(true);
                Amanager.Dedge();
                StartCoroutine(tC.ResetTrail());
                StartCoroutine(lose());

            }
            else if (this.gameObject.CompareTag("fruit"))
            {
                switch (fruitIndex)
                {
                    case 0:
                        {
                            //if (tC.RYGP[0] == false)
                            //{
                            if(tC.TrailCount<tC.trailColors.Length)
                                tC.toRed();
                            //}
                            break;
                        }
                    case 1:
                        {
                            //if (tC.RYGP[1] == false)
                            //{
                            if (tC.TrailCount < tC.trailColors.Length)
                                tC.toYellow();
                            //}
                            break;
                        }
                    case 2:
                        {
                            //if (tC.RYGP[2] == false)
                            //{
                            if (tC.TrailCount < tC.trailColors.Length)
                                tC.toGreen();
                            //}
                            break;
                        }
                    case 3:
                        {
                            //if (tC.RYGP[3] == false)
                            //{
                            if (tC.TrailCount < tC.trailColors.Length)
                                tC.toPurple();
                            //}
                            break;
                        }
                    case 4:
                        {

                            //do smth
                            var dim = GameObject.FindGameObjectWithTag("diamond").GetComponent<diamond>();
                            dim.diamondInt++;
                            Amanager.eatDiamond();
                            break;
                        }

                }
                Destroy(this.gameObject);
            }

     

           
        }
    }
}
