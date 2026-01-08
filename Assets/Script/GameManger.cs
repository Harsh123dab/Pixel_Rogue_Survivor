using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
  public static GameManger Instance;
    void Awake()
    {
        if (Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }
    public void GameOver()
    {
        StartCoroutine(ShowGameOverScreen());
    }

    IEnumerator ShowGameOverScreen(){
        yield return new WaitForSeconds(1.1f);
        UIController.Instance.gameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
