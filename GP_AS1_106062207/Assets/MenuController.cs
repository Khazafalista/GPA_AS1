using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Canvas menuCanvas;
    static bool gameOver;
    static bool firstStart = true;
    // Start is called before the first frame update
    void Start()
    {
        if(firstStart) {
            menuCanvas.enabled = true;
        }
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Player") {
            gameOver = true;
            menuCanvas.enabled = true;
        }
        firstStart = false;
    }

    public void CloseMenu() {
        menuCanvas.enabled = false;
        if(gameOver) {
            SceneManager.LoadSceneAsync("SampleScene");
        }
    }

    public void Exit() {
        Application.Quit();
    }
}
