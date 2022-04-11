using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    private Spawner spawnercs;
    public Text scoretxt;
    
    void Start()
    {
        spawnercs = GameObject.Find("Spawners").GetComponent<Spawner>();
        scoretxt = GameObject.Find("Scoretxt").GetComponent<Text>();
    }

    private void Update()
    {
        scoretxt.text = spawnercs.score.ToString();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        if (hit.collider.gameObject.tag == "target")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ScoreManager();
            }
            
        }
    }

    public void ScoreManager()
    {
        spawnercs.score += 10;
        scoretxt.text = spawnercs.score.ToString();
        Destroy(this.gameObject);
        print(spawnercs.score);
    }
}
