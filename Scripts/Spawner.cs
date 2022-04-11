using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public Sprite[] sprite;
    public float timer = 1f, timerGame = 30f, currentGameTimer, currentTimer, score = 0;
    public GameObject target;
    public bool canSpawn = false;
    public Slider slider;

    public float vida = 100;
    public GameObject panel;
    
    void Start()
    {
        //for (int i = 0; i < 3; i++) // vai pegar os pontos de spawn automaticamente
        //{
        //    spawnPoints[i] = transform.GetChild(i).GetComponent<GameObject>();
        //}

        currentGameTimer = timerGame; // configura timer geral
        panel = GameObject.Find("Panel");
        panel.SetActive(false);
        canSpawn = true; // pode iniciar spawn
    }

    void Update()
    {
        slider.value = currentGameTimer / timerGame;

        if (currentGameTimer <= 0)
        {
            panel.SetActive(true);
        }

        // timer geral 
        if (currentGameTimer > 0) 
        { 
            currentGameTimer -= Time.deltaTime; // diminui o timer 
        } 
        else 
        {   // fim de fase
            print("End Game!"); 
            canSpawn = false; 
        }

        if (canSpawn == true) {  StartCoroutine("SpawnTimer", 2f); } // spawna (mas so 1 por vez por enquanto)
    }

    private IEnumerator SpawnTimer()
    {
        canSpawn = false; // para spawns momentaneamente 
        int num = Random.Range(0, 2); // numero do sprite
        int num_ = Random.Range(0, 2); // numero do spawn
        GameObject obj = Instantiate(target, spawnPoints[num_].transform.position, Quaternion.identity); // spawna o objeto no ponto sorteado
        obj.GetComponent<SpriteRenderer>().sprite = sprite[num]; // sorteia sprite
        yield return new WaitForSecondsRealtime(timer); // espera
        Destroy(obj); // destroi
        yield return new WaitForSecondsRealtime(.1f); // delay antes de outro spawn
        canSpawn = true; // pode respawnar
    }

    public void Restart()
    {
        SceneManager.LoadScene("WAM");
    }
}
