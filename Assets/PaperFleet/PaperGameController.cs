using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PaperGameController : MonoBehaviour
{
    public Text sizeText;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AirplaneAdded() {
        Invoke("UpdateUI", 0.1f);
    }

    public void AirplaneCrashed(bool primary) {
        Invoke("UpdateUI", 0.5f);
        if (primary) {
            gameOverPanel.SetActive(true);
        }
    }

    void UpdateUI() {
        int count = GameObject.FindGameObjectsWithTag("airplane").Length;
        sizeText.text = "Fleet Size: " + count;
    }

    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() {
        SceneManager.LoadScene("MenuScene");
    }
}
