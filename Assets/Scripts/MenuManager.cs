using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Canvas gameOverCanvas;
    public Canvas pauseCanvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }
    public void ChangeScene(int sceneIndex)
    {
        Time.timeScale = 1;
        StartCoroutine(WaitForScene(sceneIndex));
    }
    private IEnumerator WaitForScene(int sceneIndex)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneIndex);
        
    }
    public void SetDificultty(int difficulty)
    {
        PlayerPrefs.SetInt("Level", difficulty);
    }
    public void GameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void UnpauseGame()
    {
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }



}
