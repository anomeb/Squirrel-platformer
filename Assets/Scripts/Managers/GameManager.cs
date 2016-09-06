using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public enum GameState {
        Game,
        Dialogue,
        Pause
    }
    public static GameManager gameManager;
    public GameState gameState;
    public GameObject gameCanvas, dialogueCanvas, pauseCanvas;
    public Joystick joystick;
    // Use this for initialization
	void Start () {
        gameManager = this;
        SetState(gameState);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameState == GameState.Game)
                PauseGame();
            else
            if (gameState == GameState.Pause)
                ResumeGame();
        }
    }


    public void StartGame() {
        gameState = GameState.Game;
        pauseCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void HideDialogue() {
        dialogueCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }

    public void ResumeGame() {
        gameState = GameState.Game;
        pauseCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void PauseGame() {
        gameState = GameState.Pause;
        pauseCanvas.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void OpenMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void SetState(GameState gameState) {
        if (gameState == GameState.Game)
            StartGame();
        if (gameState == GameState.Pause)
            PauseGame();
        if (gameState == GameState.Dialogue)
            StartDialogue();
    }

    void StartDialogue() {
        gameCanvas.SetActive(false);
        dialogueCanvas.SetActive(true);
    }


}
