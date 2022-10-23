using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public int spawnCount;
    public float spawnWait;
    public float spawnDelay;
    public float WaveWait;
    public Text ScoreText;
    public int score;
    public Text GameOverText;
    public Text RestartText;
    public Text QuitText;

    public bool gameover;
    public bool restart;

    void Update()
    {
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R)) { 

                SceneManager.LoadScene(0);
            }
            if(Input.GetKeyDown(KeyCode.Q)) { 
            
               Application.Quit();
            }
        }



    }

    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(spawnDelay);

        while (true)
        {
            yield return new WaitForSeconds(WaveWait);
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-4, 4), 0, 1);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);

            }
            if (gameover == true)
            {
                RestartText.text = "Press R for Restart";
                QuitText.text = "Press Q for Quit";    
                restart = true;
                break;
            }
        }
    }
        public void UpdateScore()
        {
            score += 10;
            ScoreText.text = "Puan : " + score;

        }

        public void GameOver()
        {
            GameOverText.text = "GAME OVER !";
            gameover = true;
        }
        public void Start()
        {
            GameOverText.text = "";
            RestartText.text = "";
        QuitText.text = ""; 
            gameover = false;
            restart = false;
            StartCoroutine(SpawnValues());

        }
    


}
