using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    Vector3 touchPos, dir;
    Rigidbody2D rb;
    float movSpeed = 15f;
    EggSpawn eggcs;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        eggcs = GameObject.Find("EggSpawn").GetComponent<EggSpawn>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;
            dir = (touchPos - transform.position);
            rb.velocity = new Vector2(dir.x, rb.velocity.y) * movSpeed;

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "target")
        {
            eggcs.score += 10;
            Destroy(col.gameObject);
        }
    }
}
