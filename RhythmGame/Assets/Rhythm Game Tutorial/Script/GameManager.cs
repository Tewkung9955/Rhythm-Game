using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;
    public bool startPlaying;
    public BeatSCroller theBs;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 200;

    public Text scoreText;
    public Text MultiText;

    public int currentMultiplier;
    public int multipleTracker;
    public int[] multiplierThersholds;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missHits;

    public GameObject resultScreen;
    public Text percentHitText, NormalText, GoodTexet, PerfectText, MissText, RankTexet, FinalScoreText;


    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBs.hasStarted = true;
                theMusic.Play();
            }
        }
        else
        {
            if (!theMusic.isPlaying&&!resultScreen.activeInHierarchy)
            {
                resultScreen.SetActive(true);
                NormalText.text = "" +normalHits;
                GoodTexet.text = "" + goodHits;
                PerfectText.text = "" + perfectHits;
                MissText.text = "" + missHits;

                float totalHit = normalHits + goodHits + perfectHits;
                float percenthit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percenthit.ToString("F1")+"%";

                string rankVal = "F";

                if (percenthit > 40)
                {
                    rankVal = "D";
                }else if (percenthit >60)
                {
                    rankVal = "C";
                }
                else if (percenthit > 70)
                {
                    rankVal = "B";
                }
                else if (percenthit > 80)
                {
                    rankVal = "A";
                }
                else if (percenthit >90)
                {
                    rankVal = "S";
                }
                RankTexet.text = rankVal;

                FinalScoreText.text = currentScore.ToString();
            }
        }
    }

    public void NoteHit()
    {

        //Debug.Log("Hit on Time");

        if (currentMultiplier - 1 < multiplierThersholds.Length)
        {
            multipleTracker++;



            if (multiplierThersholds[currentMultiplier - 1] <= multipleTracker)
            {
                multipleTracker = 0;
                currentMultiplier++;
            }
        }
        MultiText.text = "Multiplier: x" + currentMultiplier;
        
        currentScore += scorePerNote*currentMultiplier;
       scoreText.text = "Score: " + currentScore;


    }

    public void NormalHit()
    {
        currentScore += scorePerNote + currentMultiplier;
        NoteHit();
        normalHits++;

      
    }
    public void GoohHit()
    {

        currentScore += scorePerGoodNote + currentMultiplier;
        NoteHit();
        goodHits++;

    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote + currentMultiplier;
        NoteHit();
        perfectHits++;
    }


    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        currentMultiplier = 1;
        multipleTracker = 0;

        MultiText.text = "Multiplier: x" + currentMultiplier;
        missHits++;
    }
}
