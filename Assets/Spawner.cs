using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public Sprite[] sprite;
    public float timer = 4f, timerGame = 20f, currentGameTimer, currentTimer;
    public GameObject target;
    public bool canSpawn = false;
    public Slider slider;
    
    void Start()
    {
        //for (int i = 0; i < 3; i++) // vai pegar os pontos de spawn automaticamente
        //{
        //    spawnPoints[i] = 
        //}

        // fazer os pontos

        currentGameTimer = timerGame; // configura timer geral
        canSpawn = true; // pode iniciar spawn
    }

    void Update()
    {
        slider.value = currentGameTimer ;

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
        yield return new WaitForSecondsRealtime(.5f); // delay antes de outro spawn
        canSpawn = true; // pode respawnar
    }
}
