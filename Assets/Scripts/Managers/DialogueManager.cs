using UnityEngine;
using System.Collections;

public class DialogueManager : MonoBehaviour {
    public Health playerHealth;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Accept() {
        playerHealth.Die();
        GameManager.gameManager.HideDialogue();
    }

    public void Decline() {
        GameManager.gameManager.HideDialogue();
    }

}

