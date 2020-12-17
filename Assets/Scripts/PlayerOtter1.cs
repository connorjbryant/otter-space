using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOtter1 : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody2D r2d;
    private GameObject gameUI;
    public float jumpForce = 9f;
    private Animator animator;
    [SerializeField] private int gems = 0;
    [SerializeField] private Text gemText;
    public static float healthAmount;
    public GameObject explosion;
    public GameObject showShip;
    public float rotationSpeed = 500f;

    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 1;
        r2d = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        //gameUI = GameObject.Find("GameUI");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVec = new Vector2();
        moveVec.y = Input.GetAxis("Vertical") * speed;

        if (Input.GetKey("up"))
        {
            r2d.AddRelativeForce(moveVec);
        }


        /*if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //this.gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
            r2d.velocity = new Vector2(-speed, r2d.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            r2d.velocity = new Vector2(-r2d.velocity.x, -jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            r2d.velocity = new Vector2(speed, r2d.velocity.y);
        }*/

        if (Input.GetKey("left"))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * (-1));
        }
        if (Input.GetKeyDown("space"))
        {
            r2d.AddRelativeForce(moveVec * 100);
        }

        animator.SetFloat("speed", Mathf.Abs(r2d.velocity.x));

        if (GameObject.FindGameObjectsWithTag("rock").Length <= 0)
        {
            showShip.SetActive(true);
        }

        if (healthAmount <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "rock")
        {
            Destroy(collision.gameObject);
            gems += 1;
            gemText.text = gems.ToString();

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            healthAmount -= 0.1f;

        }
    }
}
