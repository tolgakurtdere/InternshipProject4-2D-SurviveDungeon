using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform player;
    private int velocity = 0;
    private int waitTime = 0;
    private bool isStart = false;
    public int hp = 2;
    public int hpLoseAmount = 10;
    private CameraControl cameraControl;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        waitTime = Random.Range(0, 5);
        velocity = Random.Range(2, 6);
        StartCoroutine(Wait(waitTime));
    }

    void Update()
    {
        if(isStart) transform.position = Vector2.MoveTowards(transform.position, player.position, velocity * Time.deltaTime);
        if(player.position.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(-4, transform.localScale.y, 1);
        }
        
        if(hp <= 0)
        {
            this.enabled = false;
            StartCoroutine(Die());
        }
    }

    IEnumerator Wait(float t)
    {
        isStart = false;
        yield return new WaitForSeconds(t);
        isStart = true;
    }

    public void TakeDamage()
    {
        hp--;
        StartCoroutine(cameraControl.Shake(0.1f, 0.15f));
        if(hp > 0)
        {
            if (transform.localScale.x > 0)
            {
                transform.position = transform.position + new Vector3(3, 0, 0);
                StartCoroutine(Wait(0.5f));
            }
            else
            {
                transform.position = transform.position - new Vector3(3, 0, 0);
                StartCoroutine(Wait(0.5f));
            }
        }
    }

    public IEnumerator Die()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        spriteRenderer.color = new Color(1, 1, 1, 200 / 255f);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(1, 1, 1, 150 / 255f);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(1, 1, 1, 100 / 255f);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(1, 1, 1, 50 / 255f);
        yield return new WaitForSeconds(0.1f);
        Destroy(transform.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SwordTag")
        {
            TakeDamage();
        }
        else if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<HealthBar>().LoseHP(hpLoseAmount);
        }
    }

}
