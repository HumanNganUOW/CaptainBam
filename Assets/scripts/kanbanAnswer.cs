using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kanbanAnswer : MonoBehaviour
{
    public Image[] kanbanSil=new Image[4];
    [SerializeField] trailController tC;
    public Sprite[] kanbanAnswers=new Sprite[4];
    public int ansCount=0;

    AudioManager audioManager;

    int doOnce=0;

    public Sprite appleRed;
    public Sprite appleGreen;
    public Sprite bananaRed;
    public Sprite bananaGreen;
    public Sprite WmelonRed;
    public Sprite WmelonGreen;
    public Sprite grapeRed;
    public Sprite grapeGreen;

    private void Awake()
    {
        setSprite();
    }

    private void Start()
    { 
        audioManager = AudioManager.instance;
    }

    void setSprite()
    {
        for (int i = 0; i < kanbanAnswers.Length; i++)
        {
            if (kanbanAnswers[i] == appleGreen)
            {
                kanbanSil[i].sprite = appleGreen;
                ansCount++;
            }
            else if (kanbanAnswers[i] == bananaGreen)
            {
                kanbanSil[i].sprite = bananaGreen;
                ansCount++;
            }
            else if (kanbanAnswers[i] == WmelonGreen)
            {
                kanbanSil[i].sprite = WmelonGreen;
                ansCount++;
            }
            else if (kanbanAnswers[i] == grapeGreen)
            {
                kanbanSil[i].sprite = grapeGreen;
                ansCount++;
            }
            else if (kanbanAnswers[i] == null)
            {
                kanbanSil[i].color = Color.clear;
            }
        }
    }
   

    IEnumerator win()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("winScreen");

    }

    private void Update()
    {
        if (doOnce < tC.TrailCount)
        {
            doOnce = tC.TrailCount;
            bool[] isCorrect = new bool[ansCount];
            int correctIndex = 0;

            //for (int i = 0; i < kanbanSil.Length; i++)
            for (int i = 0; i < ansCount; i++)
            {
               
                if (tC.trailColors[i] == tC.red || tC.trailColors[i] == tC.yellow || tC.trailColors[i] == tC.green || tC.trailColors[i] == tC.purple)
                {
                    kanbanSil[i].color = Color.white;

             

                    if (tC.trailColors[i] == tC.red && kanbanAnswers[i] == appleGreen)
                    {
                        kanbanSil[i].sprite = appleGreen;
                        StartCoroutine(audioManager.eatCorr());
                        isCorrect[i]=true;
            
                    }
                    if (tC.trailColors[i] == tC.red && kanbanAnswers[i] != appleGreen)
                    {
                        kanbanSil[i].sprite = appleRed;
                        StartCoroutine(audioManager.eatWron());
                        isCorrect[i] = false;
                    }

                    //
                    if (tC.trailColors[i] == tC.yellow && kanbanAnswers[i] == bananaGreen)
                    {
                        kanbanSil[i].sprite = bananaGreen;
                        StartCoroutine(audioManager.eatCorr());
                        isCorrect[i] = true;

                    }
                    if (tC.trailColors[i] == tC.yellow && kanbanAnswers[i] != bananaGreen)
                    {
                        kanbanSil[i].sprite = bananaRed;
                        StartCoroutine(audioManager.eatWron());
                        isCorrect[i] = false;
                    }

                    //
                    if (tC.trailColors[i] == tC.green && kanbanAnswers[i] == WmelonGreen)
                    {
                        kanbanSil[i].sprite = WmelonGreen;
                        StartCoroutine(audioManager.eatCorr());
                        isCorrect[i] = true;

                    }
                    if (tC.trailColors[i] == tC.green && kanbanAnswers[i] != WmelonGreen)
                    {
                        kanbanSil[i].sprite = WmelonRed;
                        StartCoroutine(audioManager.eatWron());
                        isCorrect[i] = false;
                    }

                    //
                    if (tC.trailColors[i] == tC.purple && kanbanAnswers[i] == grapeGreen)
                    {
                        kanbanSil[i].sprite = grapeGreen;
                        StartCoroutine(audioManager.eatCorr());
                        isCorrect[i] = true;

                    }
                    if (tC.trailColors[i] == tC.purple && kanbanAnswers[i] != grapeGreen)
                    {
                        kanbanSil[i].sprite = grapeRed;
                        StartCoroutine(audioManager.eatWron());
                        isCorrect[i] = false;
                    }

                    
                }



            }

            foreach(bool c in isCorrect)
            {

                if (c)
                {
                    correctIndex++;
                    Debug.Log(correctIndex);

                    if (correctIndex == ansCount)
                    {
                        StartCoroutine(win());
                    }
                }
            }
        }
        else if (doOnce > tC.TrailCount)
        {
           

            for (int i = tC.TrailCount; i < doOnce; i++)
            {
                if (tC.trailColors[i] != tC.red || tC.trailColors[i] != tC.yellow || tC.trailColors[i] != tC.green || tC.trailColors[i] != tC.purple)
                {
                    kanbanSil[i].color = Color.black;
                    if (kanbanAnswers[i] == appleGreen)
                    {
                        kanbanSil[i].sprite = appleGreen;
                    }
                    else if (kanbanAnswers[i] == bananaGreen)
                    {
                        kanbanSil[i].sprite = bananaGreen;
                    }
                    else if (kanbanAnswers[i] == WmelonGreen)
                    {
                        kanbanSil[i].sprite = WmelonGreen;
                    }
                    else if (kanbanAnswers[i] == grapeGreen)
                    {
                        kanbanSil[i].sprite = grapeGreen;
                    }
                    else if (kanbanAnswers[i] == null)
                    {
                        kanbanSil[i].color = Color.clear;
                    }
                }
            }

            doOnce = tC.TrailCount;
        }


        
    }


}
