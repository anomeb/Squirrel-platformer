using UnityEngine;
using System.Collections;

public class QuestNPC : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player")
            GameManager.gameManager.SetState(GameManager.GameState.Dialogue);
    }
}
