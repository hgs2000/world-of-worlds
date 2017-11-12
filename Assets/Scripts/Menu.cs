using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour {

    public void Quit() {
        Application.Quit();
    }

    public void StartNewGame() {
        Application.LoadLevel("level1");
    }
}
