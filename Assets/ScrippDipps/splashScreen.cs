using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour
{
    [SerializeField] GameObject blackBox;
    Animator ani;
   
    // Start is called before the first frame update
    void Start()
    {
        ani = blackBox.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            ani.SetTrigger("fadeOut");

            Invoke("SwitchScenes", 2f);
           

  
        }
    }

    void SwitchScenes()
    {
        SceneManager.LoadScene("LVL1");
    }
}
