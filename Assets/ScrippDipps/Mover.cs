using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody2D player;
    [SerializeField] float forceX = 1f;
    [SerializeField] float forceY = 1f;
    [SerializeField] GameObject poof;
    AudioSource audi;
    //[SerializeField] GameObject leaveDungeon;
    bool grounded = true;
    Vector2 direction = Vector2.right;
    [SerializeField] GameObject head;
    [SerializeField] GameObject body;
    Animator anni;
    Animator AnniHead;
    Animator AnniBody;
    SpriteRenderer srHead;
    SpriteRenderer srBody;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        audi = GetComponent<AudioSource>();
        AnniBody = body.GetComponent<Animator>();
        AnniHead = head.GetComponent<Animator>();
        anni = GetComponent<Animator>();
        srHead = head.GetComponent<SpriteRenderer>();
        srBody = body.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("fire"))
        {
            if (Input.GetKey(KeyCode.LeftArrow) && grounded == true)
            {
                player.AddForce(forceX * Vector2.left);
                direction = Vector2.left;
                AnniBody.SetBool("Walking", true);
                AnniHead.SetBool("Walking", true);
                srHead.flipX = true;
                srBody.flipX = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && grounded == true)
            {
                Debug.Log("going right");
                player.AddForce(forceX * Vector2.right);
                direction = Vector2.right;
                AnniBody.SetBool("Walking", true);
                AnniHead.SetBool("Walking", true);
                Debug.Log("not going the other way");
                srHead.flipX = false;
                srBody.flipX = false;
            }
            else
            {
                AnniBody.SetBool("Walking", false);
                AnniHead.SetBool("Walking", false);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded == true)
            {
                player.AddForce(forceY * Vector2.up);
                player.AddForce(forceX * direction);

                AnniHead.SetTrigger("Jump");
                audi.Play();
            }
            
            
            

            
            
        }
        else if (gameObject.CompareTag("water"))
        {
            if (Input.GetKey(KeyCode.A) && grounded == true)
            {
                player.AddForce(forceX * Vector2.left);
                direction = Vector2.left;
                AnniBody.SetBool("Walking", true);
                AnniHead.SetBool("Walking", true);
                srHead.flipX = true;
                srBody.flipX = true;
            }
            else if (Input.GetKey(KeyCode.D) && grounded == true)
            {
                Debug.Log("going right");
                player.AddForce(forceX * Vector2.right);
                direction = Vector2.right;
                AnniBody.SetBool("Walking", true);
                AnniHead.SetBool("Walking", true);
                Debug.Log("not going the other way");
                srHead.flipX = false;
                srBody.flipX = false;
            }
            else
            {
                AnniBody.SetBool("Walking", false);
                AnniHead.SetBool("Walking", false); ;
            }

            if (Input.GetKeyDown(KeyCode.W) && grounded == true)
            {
                player.AddForce(forceY * Vector2.up);
                player.AddForce(forceX * direction);
                audi.Play();
                AnniHead.SetTrigger("Jump");

            }
        }
        if (gameManager.gameDone == 2)
        {
            anni.SetBool("finished", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Mover" + collision.name);
        if (gameObject.CompareTag("water") && collision.gameObject.CompareTag("fire"))
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            Instantiate(poof, gameObject.transform.position, gameObject.transform.rotation);
            Invoke(nameof(waitUp), 1.5f);
            Destroy(gameObject);
            gameManager.playersingame -= 1;
        }
        else if(gameObject.CompareTag("fire") && collision.gameObject.CompareTag("water"))
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            Instantiate(poof, gameObject.transform.position, gameObject.transform.rotation);
            Invoke(nameof(waitUp), 1.5f);
            Destroy(gameObject);
            gameManager.playersingame -= 1;
        }
        else if(gameObject.CompareTag("acid"))
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            Instantiate(poof, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            gameManager.playersingame -= 1;
        }
        if (collision.gameObject.CompareTag("waterDiamond") && gameObject.CompareTag("water"))
        {
            
            Destroy(collision.gameObject);
            gameManager.diamondCount += 1;
        }
        if (collision.gameObject.CompareTag("fireDiamond") && gameObject.CompareTag("fire"))
        {
            
            Destroy(collision.gameObject);
            gameManager.diamondCount += 1;
        }
        if (collision.gameObject.CompareTag("diamond") && (gameObject.CompareTag("fire") || gameObject.CompareTag("water")))
        {
            Destroy(collision.gameObject);
            gameManager.diamondCount += 1;
        }
        if (collision.gameObject.CompareTag("girlDone") && gameObject.CompareTag("water"))
        {
            gameManager.gameDone += 1;
        }
        if (collision.gameObject.CompareTag("boyDone") && gameObject.CompareTag("fire"))
        {
            gameManager.gameDone += 1;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") == true)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
       
        
    }
    void waitUp()
    {
        Debug.Log("waiting...");
    }
}
