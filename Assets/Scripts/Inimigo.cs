using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float cooldown = .5f, dano = 10, vida = 30;
    private float speed = .01f;

    private bool playerInRange = false, canAttack = true;
    public bool atacou = false;

    private GameObject player;
    public Rigidbody2D rb;
    private GameObject cam;

    void Awake()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        Ataque();
        Mover();

        if (vida <= 0)
        {
            Destroy(this.gameObject);
            ///GameObject.Find("Player").GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void Mover()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
    }

    void Ataque()
    {
        if (playerInRange && canAttack && player.GetComponent<Player>().canDano)
        {
            player.GetComponent<Player>().vida -= dano;
            atacou = true;
            StartCoroutine(AttackCooldown());
            
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        player.GetComponent<Player>().canDano = false;
        
        cam.GetComponent<CameraShake>().shake = true;

        //Vector3 direction = (player.transform.position - transform.position);
        //player.GetComponent<Player>().rb.AddForce(direction * 1000);
        //player.GetComponent<Player>().rb.AddForce(direction * 1000, ForceMode2D.Impulse);
        //player.GetComponent<Player>().rb.AddForce(direction * 1000 * Time.deltaTime, ForceMode2D.Impulse);

        yield return new WaitForSeconds(cooldown);

        player.GetComponent<Player>().canDano = true;
        canAttack = true;
        atacou = false;
    }
}
