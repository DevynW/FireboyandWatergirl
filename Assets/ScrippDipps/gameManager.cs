using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public static int playersingame = 2;
    [SerializeField] GameObject gameOver;
    public static int diamondCount = 0;
    public static int gameDone = 0;
    [SerializeField] GameObject endOfGame;
    public static float timePlayed;
    [SerializeField] GameObject timewon;
    [SerializeField] GameObject timelost;
    [SerializeField] GameObject diamondwon;
    [SerializeField] GameObject diamondlost;
    float currentTime;
    float timeStart;
    [SerializeField] TMP_Text timer;
    [SerializeField] GameObject door1Open;
    [SerializeField] GameObject door2Open;
    Animator anni;
    Animator anim;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.time;
        playersingame = 2;
        diamondCount = 0;
        gameDone = 0;
            anni = door1Open.GetComponent<Animator>();
            anim = door2Open.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playersingame == 2)
        {
            
            gameOver.SetActive(false);
            //Debug.Log("Game not over");
        }
        if (playersingame < 2)
        {
            Invoke(nameof(waitUp), 3f);
            
        }
        if (gameDone == 2)
        {
            anni.SetBool("gameWon", true);
            anim.SetBool("gameWon", true);
            Invoke(nameof(waitUp2), 3f);
            
            if (currentTime < 30) 
            {
                timewon.SetActive(true);
            }
            else if (currentTime >= 30)
            {
                timelost.SetActive(true);
            }
            if(diamondCount == 9)
            {
                diamondwon.SetActive(true);
            }
            else if (diamondCount < 9)
            {
                diamondlost.SetActive(true);
            }
            
        }

        currentTime = (int)Time.time - (int)timeStart;
        timer.text = currentTime.ToString();
        //Debug.Log(currentTime.ToString());
        //write time to tmp 
        
    }
    void waitUp()
    {
        gameOver.SetActive(true);
    }

    void waitUp2()
    {
        endOfGame.SetActive(true);
    }
}
