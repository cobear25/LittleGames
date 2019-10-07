using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenURL(string url) {
        Application.OpenURL(url);
    }
}
