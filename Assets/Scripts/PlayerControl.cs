using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rigidbody_player;
    float horizontalInput = 0, verticalInput;
    public static bool isOver;
    public static bool isFire;
    private CoolDownBar cdBar;
    private HealthBar hpBar;

    void Start()
    {
        isOver = false;
        isFire = false;
        rigidbody_player = GetComponent<Rigidbody2D>();
        cdBar = FindObjectOfType<CoolDownBar>();
        hpBar = FindObjectOfType<HealthBar>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFire = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isFire = false;
        }
        if (isFire)
        {
            cdBar.UseMana(2);
            if(cdBar.GetCurrentValue() < 5) isFire = false;
        }
        if (!isFire) cdBar.GainMana(1);

        if(hpBar.GetCurrentValue() <= 0)
        {
            GameOver();
        }
    }
    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (!isOver)
        {
            rigidbody_player.velocity = new Vector3(horizontalInput * 4, verticalInput * 4, 0);
            if (horizontalInput < 0) transform.localScale = new Vector3(-4.5f, 4.5f, 1);
            else if (horizontalInput > 0) transform.localScale = new Vector3(4.5f, 4.5f, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HpPotTag")
        {
            hpBar.GainHP(20);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "ManaPotTag")
        {
            cdBar.GainMana(250);
            Destroy(collision.gameObject);
        }

    }

    private void GameOver()
    {
        isOver = true;
        transform.Rotate(0, 0, 3);
        rigidbody_player.AddForce(new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)));
        StartCoroutine(Restart());
        
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
