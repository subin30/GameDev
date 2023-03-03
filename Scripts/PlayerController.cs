using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator Anime;
    private Rigidbody2D Rg2b;

    [SerializeField]
    private float speed =20;

    [SerializeField]
    private float jumpForce = 10;

    private bool isGrounded;

    [SerializeField]
    private GameObject Dust;

    public GameObject Gizmos;


    public GameObject Bullet;

    public Transform BulletPoint;

    public float AttackRate = 2f;
    private float nextAttackTime = 0f;

    public int CurrentHealth;
    private int MaxHealth = 100;

    public HealthBar healthBar;

    public PauseButtonController pause;
    private BoxCollider2D box;

    public GameObject Level1Complete;

    public GameObject Level2Complete;

    

    private bool Left, Right;

   
    


    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        Anime = GetComponent<Animator>();
        Rg2b = GetComponent<Rigidbody2D>();

        GameObject.Find("Jump").GetComponent<Button>().onClick.AddListener(() => Jumping());


        GameObject.Find("Shoot").GetComponent<Button>().onClick.AddListener(() => Attacking());







    }
    private void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.maxHealth(MaxHealth);

    }


    void FixedUpdate()
    {
        //MoveKeyBoard();
        //Jump();
        //Attack();
        MoveJoystick();
    }

    public void MoveLeft(bool Left)
    {
        this.Left = Left;
        this.Right = !Left;
    }

    public void StopMoving()
    {
        this.Left = false;
        this.Right = false;
    }

    public void MoveJoystick()
    {
        if (Left)
        {
            Rg2b.velocity = new Vector2(-speed, Rg2b.velocity.y);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            Anime.SetBool("Walk", true);

        }
        else if (Right)
        {
            Rg2b.velocity = new Vector2(speed, Rg2b.velocity.y);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);


            Anime.SetBool("Walk", true);

        }
        else
        {
            Rg2b.velocity = new Vector2(0, Rg2b.velocity.y);
            Anime.SetBool("Walk", false);

        }


    }

    public void MoveKeyBoard()
    {
        if (Input.GetKey("a"))
        {
            Rg2b.velocity = new Vector2(-speed, Rg2b.velocity.y);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            Anime.SetBool("Walk", true);

        }
        else if (Input.GetKey("d"))
        {
            Rg2b.velocity = new Vector2(speed, Rg2b.velocity.y);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);


            Anime.SetBool("Walk", true);

        }
        else
        {
            Rg2b.velocity = new Vector2(0, Rg2b.velocity.y);
            Anime.SetBool("Walk", false);

        }


    }

    public void Jump()
    {
        if (Input.GetKey("space"))
        {


            if (isGrounded)
            {
                Rg2b.velocity = new Vector2(Rg2b.velocity.x, jumpForce);

                Instantiate(Dust, Gizmos.transform.position, Gizmos.transform.rotation);

                Anime.SetTrigger("isJumping");

            }
            isGrounded = false;

        }
    }

    public void Jumping()
    {
        if (isGrounded)
        {
            AudioScript.PlaySound("Jump");
            Rg2b.velocity = new Vector2(Rg2b.velocity.x, jumpForce);

            Instantiate(Dust, Gizmos.transform.position, Gizmos.transform.rotation);

            Anime.SetTrigger("isJumping");

        }
        isGrounded = false;
    }

    public void Attack()
    {
        if (Time.time >= nextAttackTime)
        {


            if (Input.GetKey("l"))
            {

                AudioScript.PlaySound("Shoot");
                GameObject light = Instantiate(Bullet, BulletPoint.position, BulletPoint.rotation);

                Rg2b.velocity = new Vector2(Rg2b.velocity.x, Rg2b.velocity.y);
                nextAttackTime = Time.time + 1f / AttackRate;
            }
        }
        

    }

    public void Attacking()
    {
        if (Time.time >= nextAttackTime)
        {
            
                AudioScript.PlaySound("Shoot");
                GameObject light = Instantiate(Bullet, BulletPoint.position, BulletPoint.rotation);

               Rg2b.velocity = new Vector2(Rg2b.velocity.x, Rg2b.velocity.y);
            nextAttackTime = Time.time + 1f / AttackRate;
            
          
        }
        

    }
    public void BouncePlayer(float force)
    {
        isGrounded = false;
        Rg2b.velocity = new Vector2 (0, force);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;

        }
        if (collision.gameObject.tag == "Platform")
        {
            gameObject.transform.parent = collision.gameObject.transform;
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Door")
        {
            gameObject.SetActive(false);
            AudioScript.PlaySound("Complete");
            Level1Complete.SetActive(true);
            

        }
        else
        {
            
            Level1Complete.SetActive(false);

        }

        if (collision.gameObject.tag == "Door2")
        {
            gameObject.SetActive(false);
            AudioScript.PlaySound("Complete");
            Level2Complete.SetActive(true);

        }
        else
        {
            Level2Complete.SetActive(false);

        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            gameObject.transform.parent = null;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            Damage(100);
            box.enabled = false;
            //Rg2b.velocity = new Vector2(Rg2b.velocity.x, 20f);
            //GetComponent<BoxCollider2D>().enabled = false;
            //Anime.Play("Death");
            
            //this.enabled = false;
            

        }
        if (target.tag == "ImmuneEnemy")
        {
            Damage(100);
            box.enabled = false;

        }
    }

  
    public void Damage(int damage)
    {
        CurrentHealth -= damage;
        AudioScript.PlaySound("PlayerHit");
        healthBar.setHealth(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            
            Rg2b.velocity = new Vector2(0f,0f);

           

            
            Anime.Play("Death");
            AudioScript.PlaySound("Dead");
            
            pause.PlayerDied();
            



            this.enabled = false;


        }
       

    }


}
