using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static int playersingame = 2;
    [SerializeField] GameObject gameOver;
    public static int diamondCount = 0;
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



    }
}
