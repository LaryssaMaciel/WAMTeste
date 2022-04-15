using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    private Spawner spawnercs;
   
    
    void Start()
    {
        spawnercs = GameObject.Find("Spawners").GetComponent<Spawner>();
    }
    
    private void Update()
    {
        TargetInteract();
    }

    public void TargetInteract()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (Input.GetButtonDown("Fire1"))
        {
            if (hit.collider != null)
            {
                ScoreManager();
            }
        }
    }

    public void ScoreManager()
    {
        spawnercs.score += 10;
        spawnercs.scoretxt.text = spawnercs.score.ToString();
        Destroy(this.gameObject);
    }
}
