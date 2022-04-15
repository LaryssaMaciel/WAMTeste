using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EggSpawn : MonoBehaviour
{
    public GameObject egg, panel;
    public float timer = 1f, timerGame = 30f, currentGameTimer, currentTimer, score = 0;
    public Slider slider;
    private bool canSpawn = true;
    public Text scoretxt;

    void Start()
    {
        currentGameTimer = timerGame; // configura timer geral
        panel = GameObject.Find("Panel");
        panel.SetActive(false);
        scoretxt = GameObject.Find("Scoretxt").GetComponent<Text>();
    }

    void Update()
    {
        slider.value = currentGameTimer / timerGame;
        scoretxt.text = score.ToString();

        if (currentGameTimer <= 0)
        {
            panel.SetActive(true);
            scoretxt = GameObject.Find("Scoretxt1").GetComponent<Text>();
            scoretxt.text = score.ToString();
        }

        // timer geral 
        if (currentGameTimer > 0) 
        { 
            currentGameTimer -= Time.deltaTime; // diminui o timer 
        } 
        else { canSpawn = false; }

        if (canSpawn == true) { StartCoroutine("SpawnEgg", .5f); }
        
    }

    public IEnumerator SpawnEgg()
    {
        var bounds = this.gameObject.GetComponent<BoxCollider2D>().bounds;
        float px = Random.Range(bounds.min.x, bounds.max.x);
        Vector2 pos = new Vector3(px, transform.position.y, 0);
        canSpawn = false;
        Instantiate(egg, pos, Quaternion.identity);
        yield return new WaitForSecondsRealtime(timer); // espera
        canSpawn = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("EGG");
    }
}
