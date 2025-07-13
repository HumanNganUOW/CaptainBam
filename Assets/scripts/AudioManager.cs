using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    AudioSource audioSource;

    [SerializeField]AudioClip eatDim;
    [SerializeField] AudioClip eatFru;
    [SerializeField] AudioClip corr;
    [SerializeField] AudioClip wron;
    [SerializeField] AudioClip bump;
    [SerializeField] AudioClip dedge;
    [SerializeField] AudioClip move;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);

        audioSource = GetComponent<AudioSource>();
    }


    public IEnumerator eatCorr()
    {
        audioSource.clip = eatFru;
        audioSource.Play();
        yield return new WaitForSeconds(1);
        audioSource.clip=corr; 
        audioSource.Play();
    }
    public IEnumerator eatWron()
    {
        audioSource.clip = eatFru;
        audioSource.Play();
        yield return new WaitForSeconds(1);
        audioSource.clip=wron; 
        audioSource.Play();
    }

    public void eatDiamond()
    {
        audioSource.clip = eatDim;
        audioSource.Play();
    }

    public void Dedge()
    {
        audioSource.clip = dedge;
        audioSource.Play();
    }
    public void Bump()
    {
        audioSource.clip = bump;
        audioSource.Play();
    }

    public void Move()
    {
        audioSource.clip = move;
        audioSource.Play();
    }
}
