using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void Quit() {
        Application.Quit();
    }

    public void StartNewGame() {
        SceneManager.LoadScene("level1");
    }
}
