
using UnityEngine;
using TMPro;
using System.Collections;

public class timer : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI timeText;
    [SerializeField]TextMeshProUGUI speedText;
    int sec,min=0;
    string secStr,minStr,spdStr;

    [SerializeField] trailController tC;
    int speedInt = 60;

    IEnumerator add()
    {
        sec++;
        if(sec>=60)
        {
            sec -= 60;min += 1;
        }

        if(sec<10)secStr = $"0{sec}";
        else secStr =sec.ToString();

        if (min < 10) minStr = $"0{min}";
        else minStr =min.ToString();

        timeText.text = minStr+":"+secStr;
        yield return new WaitForSeconds(1);
        StartCoroutine(add());
    }

    IEnumerator speed()
    {
        if (tC.TrailCount == 0)
        {
            if (speedInt > 60)
            {
                speedInt--;
            }
        }
        if (tC.TrailCount == 1)
        {
            if (speedInt < 120)
            {
                speedInt++;
            }
            else if (speedInt > 120) speedInt--;
        } 
        if (tC.TrailCount == 2)
        {
            if (speedInt < 180)
            {
                speedInt++;
            }
            else if (speedInt > 180) speedInt--;
        } 
        if (tC.TrailCount == 3)
        {
            if (speedInt < 240)
            {
                speedInt++;
            }
            else if (speedInt > 240) speedInt--;
        } 
        if (tC.TrailCount == 4)
        {
            if (speedInt < 300)
            {
                speedInt++;
            }
            //else speedInt--;
        }

        yield return new WaitForSeconds(0.02f);
        spdStr = speedInt.ToString()+"km/h";
        speedText.text = spdStr;
        StartCoroutine (speed());
       
    }

    private void Start()
    {
        StartCoroutine(add());
        StartCoroutine(speed());
    }
}
