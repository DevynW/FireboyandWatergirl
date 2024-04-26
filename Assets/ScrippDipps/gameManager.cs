using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playersingame < 2)
        {
            gameOver.SetActive(true);
        }
        if (gameDone == 2)
        {
            endOfGame.SetActive(true);
            if (timePlayed <= 30) 
            {
                timewon.SetActive(true);
            }
            else
            {
                timelost.SetActive(false);
            }
            if(diamondCount == 9)
            {
                diamondwon.SetActive(true);
            }
            else if (diamondCount < 9)
            {
                diamondlost.SetActive(true);
            }
            //write time to tmp 
        }



    }
}
