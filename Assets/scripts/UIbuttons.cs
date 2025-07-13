using UnityEngine;
using UnityEngine.SceneManagement;

public class UIbuttons : MonoBehaviour
{
    [SerializeField] GameObject leaderboard;
    [SerializeField] GameObject tut;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject lvlSelect;

    [SerializeField]AudioSource audios;
    [SerializeField]AudioSource audios2;

    static int lvl;

   

    public void replayButton()
    {
        Debug.Log(lvl+2);
        SceneManager.LoadScene(lvl+2);
        audios.Play();
    }

    public void nextLevelButton()
    {
        SceneManager.LoadScene(lvl + 3);
        audios.Play();
        lvl++;
    }

    public void playButton(int level)
    {
        lvl = level;
        audios.Play();
        SceneManager.LoadScene(level+2);
     
    }

    public void lvlSelectButton()
    {
        lvlSelect.SetActive(true);
        audios.Play();
    }

 

    public void MainMenu()
    {
        audios.Play();
        SceneManager.LoadScene("MainMenu");
 
    }

    public void howPlay()
    {
        audios.Play();
        tut.SetActive(true);
    }

    public void lead()
    {
        audios.Play();
        leaderboard.SetActive(true);
    }  
    public void shopp()
    {
        audios.Play();
        shop.SetActive(true);
    }

    public void buy()
    {
        if(audios2!=null)
        audios2.Play();
    }

    public void close()
    {
        if (tut != null && leaderboard != null && shop != null && lvlSelect != null)
        {
            tut.SetActive(false);
            leaderboard.SetActive(false);
            shop.SetActive(false);
            lvlSelect.SetActive(false);

            audios.Play();
        }
    }
}
