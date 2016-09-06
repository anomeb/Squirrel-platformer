using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour {

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            Exit();
    }

	public void NewGame() {
        SceneManager.LoadScene("Level01");
    }

    public void Exit() {
        Application.Quit();
    }
}
