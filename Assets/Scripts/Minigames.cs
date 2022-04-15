using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigames : MonoBehaviour
{
    public void cena(string name)
    {
        SceneManager.LoadScene(name);
    }
}
