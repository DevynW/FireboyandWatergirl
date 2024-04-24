using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody2D player;
    [SerializeField] float forceX = 1f;
    [SerializeField] float forceY = 1f;
    [SerializeField] GameObject poof;
    [SerializeField] AudioSource audi;
    bool grounded = true;
    Vector2 direction = Vector2.right;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        audi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("fire"))
        {
            if (Input.GetKey(KeyCode.LeftArrow) /*&& grounded == true*/)
            {
                player.AddForce(forceX * Vector2.left);
                direction = Vector2.left;
                //anni.SetBool("Walking", true);
                //sr.flipX = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow) /*&& grounded == true*/)
            {
                Debug.Log("going right");
                player.AddForce(forceX * Vector2.right);
                direction = Vector2.right;
                // anni.SetBool("Walking", true);
                Debug.Log("not going the other way");
                //sr.flipX = false;
            }
            else
            {
                // anni.SetBool("Walking", false);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) /*&& grounded == true*/)
            {
                player.AddForce(forceY * Vector2.up);
                player.AddForce(forceX * direction);
                audi.Play();
            }
        }
        else if (gameObject.CompareTag("water"))
        {
            if (Input.GetKey(KeyCode.A) /*&& grounded == true*/)
            {
                player.AddForce(forceX * Vector2.left);
                direction = Vector2.left;
                //anni.SetBool("Walking", true);
                //sr.flipX = true;
            }
            else if (Input.GetKey(KeyCode.D) /*&& grounded == true*/)
            {
                Debug.Log("going right");
                player.AddForce(forceX * Vector2.right);
                direction = Vector2.right;
                // anni.SetBool("Walking", true);
                Debug.Log("not going the other way");
                //sr.flipX = false;
            }
            else
            {
                // anni.SetBool("Walking", false);
            }

            if (Input.GetKeyDown(KeyCode.W) /*&& grounded == true*/)
            {
                player.AddForce(forceY * Vector2.up);
                player.AddForce(forceX * direction);
                audi.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("water") && collision.gameObject.CompareTag("fire"))
        {
            Instantiate(poof);
            Destroy(gameObject);
        }
        else if(gameObject.CompareTag("fire") && collision.gameObject.CompareTag("water"))
        {
            Instantiate(poof);
            Destroy(gameObject);
        }
    }
}
