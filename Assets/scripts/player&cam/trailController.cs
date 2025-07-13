using System;
using System.Collections;
using UnityEngine;

public class trailController: MonoBehaviour
{

    [SerializeField] TrailRenderer trailL;
    [SerializeField] TrailRenderer trailML;
    [SerializeField] TrailRenderer trailM;
    [SerializeField] TrailRenderer trailMR;
    [SerializeField] TrailRenderer trailR;

    [SerializeField] kanbanAnswer kb;
    public GameObject smoke;


    public int TrailCount = 0;
    private int priTrailCount;
    //public bool[] RYGP= new bool[4] {false,false,false,false };
    public Gradient[] trailColors;
    public Gradient red;
    public Gradient yellow;
    public Gradient green;
    public Gradient purple;
    public Gradient white;

    private void Awake()
    {
        StartCoroutine(ResetTrail());

        TrailCount = 0;
        priTrailCount = TrailCount;
    }

    public IEnumerator ResetTrail()
    {
      
        trailL.gameObject.SetActive(false);
        trailML.gameObject.SetActive(false);
        trailM.gameObject.SetActive(false);
        trailMR.gameObject.SetActive(false);
        trailR.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.02f);


    }

    private void Start()
    {
        trailColors = new Gradient[kb.ansCount];

    
        GradientColorKey[] gckR;
        GradientAlphaKey[] gakR;
        red = new Gradient();
        gckR = new GradientColorKey[2];
        red.mode = GradientMode.Fixed;
        gckR[0].color = new Color (0.996078431372549f, 0.4745098039215686f, 0.4823529411764706f);
        gckR[0].time = 0.5F;
        gckR[1].color = Color.white;
        gckR[1].time = 1.0F;
        gakR = new GradientAlphaKey[2];
        gakR[0].alpha = 0.0F;
        gakR[0].time = 0.0F;
        gakR[1].alpha = 1.0F;
        gakR[1].time = 1.0F;
        red.SetKeys(gckR, gakR);


        GradientColorKey[] gckY;
        GradientAlphaKey[] gakY;
        yellow = new Gradient();
        gckY = new GradientColorKey[2];
        yellow.mode = GradientMode.Fixed;
        gckY[0].color = new Color(1, 0.9176470588235294f, 0.33725490196078434f);
        gckY[0].time = 0.5F;
        gckY[1].color = Color.white;
        gckY[1].time = 1.0F;
        gakY = new GradientAlphaKey[2];
        gakY[0].alpha = 0.0F;
        gakY[0].time = 0.0F;
        gakY[1].alpha = 1.0F;
        gakY[1].time = 1.0F;
        yellow.SetKeys(gckY, gakY);


        GradientColorKey[] gckG;
        GradientAlphaKey[] gakG;
        green = new Gradient();
        gckG = new GradientColorKey[2];
        green.mode = GradientMode.Fixed;
        gckG[0].color =new Color(0.5607843137254902f, 0.9137254901960784f, 0.40784313725490196f);
        gckG[0].time = 0.5F;
        gckG[1].color = Color.white;
        gckG[1].time = 1.0F;
        gakG = new GradientAlphaKey[2];
        gakG[0].alpha = 0.0F;
        gakG[0].time = 0.0F;
        gakG[1].alpha = 1.0F;
        gakG[1].time = 1.0F;
        green.SetKeys(gckG, gakG);


        GradientColorKey[] gckP;
        GradientAlphaKey[] gakP;
        purple = new Gradient();
        gckP = new GradientColorKey[2];
        purple.mode = GradientMode.Fixed;
        gckP[0].color =new Color(0.6470588235294118f, 0.5294117647058824f, 0.792156862745098f);
        gckP[0].time = 0.5F;
        gckP[1].color = Color.white;
        gckP[1].time = 1.0F;
        gakP = new GradientAlphaKey[2];
        gakP[0].alpha = 0.0F;
        gakP[0].time = 0.0F;
        gakP[1].alpha = 1.0F;
        gakP[1].time = 1.0F;
        purple.SetKeys(gckP, gakP);

        GradientColorKey[] gckW;
        GradientAlphaKey[] gakW;
        white = new Gradient();
        gckW = new GradientColorKey[2];
        white.mode = GradientMode.Fixed;
        gckW[0].color = Color.white;
        gckW[0].time = 0.5F;
        gckW[1].color = Color.white;
        gckW[1].time = 1.0F;
        gakW = new GradientAlphaKey[2];
        gakW[0].alpha = 0.0F;
        gakW[0].time = 0.0F;
        gakW[1].alpha = 1.0F;
        gakW[1].time = 1.0F;
        white.SetKeys(gckW, gakW);

    }



    private void Update()
    {
        if (priTrailCount != TrailCount)
        {
            priTrailCount = TrailCount;
            Camera.main.GetComponent<camFollow>().isBoosting = true;
            StartCoroutine(Camera.main.GetComponent<camFollow>().boost());


            if (TrailCount == 0)
            {
                StartCoroutine(ResetTrail());
            }
            else if (TrailCount == 1)
            {
                StartCoroutine(ResetTrail());

                trailM.gameObject.SetActive(true);
                trailM.colorGradient = trailColors[0];

            }
            else if (TrailCount == 2)
            {
                StartCoroutine(ResetTrail());
                trailL.gameObject.SetActive(true);
                trailL.colorGradient = trailColors[0];
                trailR.gameObject.SetActive(true);
                trailR.colorGradient = trailColors[1];
            }
            else if (TrailCount == 3)
            {
                StartCoroutine(ResetTrail());
                trailL.gameObject.SetActive(true);
                trailL.colorGradient = trailColors[0];
                trailM.gameObject.SetActive(true);
                trailM.colorGradient = trailColors[1];
                trailR.gameObject.SetActive(true);
                trailR.colorGradient = trailColors[2];
            }
            else if (TrailCount == 4)
            {
                StartCoroutine(ResetTrail());
                trailL.gameObject.SetActive(true);
                trailL.colorGradient = trailColors[0];
                trailML.gameObject.SetActive(true);
                trailML.colorGradient = trailColors[1];
                trailMR.gameObject.SetActive(true);
                trailMR.colorGradient = trailColors[2];
                trailR.gameObject.SetActive(true);
                trailR.colorGradient = trailColors[3];
            }
        }
        
    }

    public void toRed()
    {
        //RYGP[0] = true;
        trailColors[TrailCount] = red;
        TrailCount++;
    }

    public void toYellow()
    {
        //RYGP[1] = true;
        trailColors[TrailCount] = yellow;
        TrailCount++;
    }

    public void toGreen()
    {
        //RYGP[2] = true;
        trailColors[TrailCount] = green;
        TrailCount++;
    }
     public void toPurple()
    {
        //RYGP[3] = true;
        trailColors[TrailCount] = purple;
        TrailCount++;
    }

    public void hitBarrier()
    {
        if (TrailCount > 0)
        {

            //if (trailColors[TrailCount-1].colorKeys[0].color == red.colorKeys[0].color) RYGP[0] = false;
            //if (trailColors[TrailCount - 1].colorKeys[0].color == yellow.colorKeys[0].color) RYGP[1] = false;
            //if (trailColors[TrailCount - 1].colorKeys[0].color == green.colorKeys[0].color) RYGP[2] = false;
            //if (trailColors[TrailCount - 1].colorKeys[0].color == purple.colorKeys[0].color) RYGP[3] = false;
          


            trailColors[TrailCount - 1] = white;
            TrailCount--;
        }

    }

}
