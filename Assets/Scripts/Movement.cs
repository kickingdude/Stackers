using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    public GameObject winnerUI;
    public GameObject gameOverUI;
    public GameObject counterMenuUI;

    public static float number = 3;
    private bool collide;
    private bool move;
    private float size;
    public Rigidbody2D rb;
    public float speed;

    public static int wins;
    public static int plays;

    private IEnumerator movement()
    {
            while (move == true)
            {
                if (collide == true)
                {
                    transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                    yield return new WaitForSeconds(1f / (speed + (2 * size)));
                }
                else if (collide == false)
                {
                    transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
                    yield return new WaitForSeconds(1f / (speed + (2 * size)));
                }
            }
            
    }
    private IEnumerator level()
    {
        move = false;
        Vector2 dir = transform.TransformDirection(-Vector2.up) * 0.1f;
        transform.position = new Vector2(transform.position.x, transform.position.y);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 1.1f), dir, Color.green, 10);
        yield return new WaitForSeconds(1.5f);
        if (size == 1)
        {
            Instantiate(rb, new Vector2(transform.position.x, transform.position.y + 1), transform.rotation);
            GetComponent<Movement>().enabled = false;
        }
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1.1f), -Vector2.up, 0.1f);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 1.1f), dir, Color.green, 100);
        if (hit.collider != null)
        {
            if ((size + 1) == 11)
            {
                wins += 1;
                counterMenuUI.SetActive(false);
                winnerUI.SetActive(true);
                SaveSystem.SavePlayer();
                StopCoroutine(movement());
            }
            else
            {
                Instantiate(rb, new Vector2(transform.position.x, transform.position.y + 1), transform.rotation);
                GetComponent<Movement>().enabled = false;
            }
            
        }
        else if ((number == 1) && (hit.collider == null))
        {
            counterMenuUI.SetActive(false);
            gameOverUI.SetActive(true);
            SaveSystem.SavePlayer();
            StopCoroutine(movement());
        }
        else if ((size != 1) && (hit.collider == null))
        {
            number -= 1;
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log(number);
        size = transform.position.y - (-5.5f); //Max is 10, Starts at 1
        collide = false;
        move = true;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(movement());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
    void Update()
    {

        if (Input.GetKeyDown("space") && (StartMenu.GameStart))
        {
            StartCoroutine(level());
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if ((collide == true) && (col.gameObject.tag == "tile"))
        {
            collide = false;
        }
        else if ((collide == false) && (col.gameObject.tag == "tile"))
        {
            collide = true;
        }
    }
    public void Retry()
    {
        plays += 1;
    }
}
