using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class fakeAnim : MonoBehaviour
{
    [SerializeField]  Sprite a1;
    [SerializeField]  Sprite a2;
    [SerializeField]  Sprite a3;
    [SerializeField]  Sprite a4;
    [SerializeField]  Sprite a5;
    [SerializeField]  Sprite a6;
    [SerializeField]  Sprite a7;
    [SerializeField]  Sprite a8;

    [SerializeField] bool isFour;

    float interval=0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!isFour)
            StartCoroutine(firstSix());

        else StartCoroutine(firstFour());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator firstSix()
    {
        this.gameObject.GetComponent<Image>().sprite = a1;
        yield return new WaitForSeconds(interval);
        this.gameObject.GetComponent<Image>().sprite = a2;
        yield return new WaitForSeconds(interval);
        this.gameObject.GetComponent<Image>().sprite = a3;
        yield return new WaitForSeconds(interval);
        this.gameObject.GetComponent<Image>().sprite = a4;
        yield return new WaitForSeconds(interval);
        this.gameObject.GetComponent<Image>().sprite = a5;
        yield return new WaitForSeconds(interval);
        this.gameObject.GetComponent<Image>().sprite = a6;
        yield return new WaitForSeconds(interval);
        if (a7 != null)
        {
            this.gameObject.GetComponent<Image>().sprite = a7;
            StartCoroutine(lastTwo());
        }
        else StartCoroutine(firstSix());
    } 
    
    IEnumerator firstFour()
    {
        this.gameObject.GetComponent<Image>().sprite = a1;
        yield return new WaitForSeconds(interval);
        this.gameObject.GetComponent<Image>().sprite = a2;
        yield return new WaitForSeconds(interval);
        this.gameObject.GetComponent<Image>().sprite = a3;
        yield return new WaitForSeconds(interval);
        this.gameObject.GetComponent<Image>().sprite = a4;
        yield return new WaitForSeconds(interval);
      
         StartCoroutine(firstFour());
    }

    IEnumerator lastTwo()
    {
        if (this.gameObject.GetComponent<Image>().sprite == a7)
            this.gameObject.GetComponent<Image>().sprite = a8;
        else if (this.gameObject.GetComponent<Image>().sprite == a8)
            this.gameObject.GetComponent<Image>().sprite = a7;

        yield return new WaitForSeconds(interval);
        StartCoroutine(lastTwo());
    }
}
