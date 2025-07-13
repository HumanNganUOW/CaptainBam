using System.Collections;
using TMPro;
using UnityEngine;

public class diamond : MonoBehaviour
{
    public int diamondInt;
    TextMeshProUGUI diamondText;

    private void Awake()
    {
        diamondText = GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(updateDiamond());
    }

    IEnumerator updateDiamond()
    {
        diamondText.text = diamondInt.ToString();
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(updateDiamond());
    }


    

}
