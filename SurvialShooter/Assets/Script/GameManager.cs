using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject panelGameOver;
    public TextMeshProUGUI textScore;
    int score;
    /*gestion de enemigos*/
    [Header("Array Positions")]
    public Transform[] pocitions; // array de posiciones 
    [Header("Array Enemies")]
    public GameObject[] enemyPrefab;
    [Space]
    public Transform parentEnemy; // el gameobj vacio que va a ser el padre de los clones de los enemigos
    // [Range(2,6)]
    [Tooltip("tiempo entre enemigos")]
    public float time; // cada cuanto tiempo voy a estar instanciando enemigos  
    GameObject cloneEnemy;
    void Start()
    {
        InvokeRepeating("CreateEnemy",time,time);   
    }

    void CreateEnemy(){
        int pos = Random.Range(0, pocitions.Length);
        int enemy = Random.Range(0, enemyPrefab.Length);
        cloneEnemy = Instantiate(enemyPrefab[enemy], pocitions[pos].position ,pocitions[pos].rotation);

        cloneEnemy.transform.SetParent(parentEnemy);
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);

    }
    public void loadScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
    public void Score(int scoreValue)
    {
        score += scoreValue;
        textScore.text = "Score: " + score.ToString();
    }
}
