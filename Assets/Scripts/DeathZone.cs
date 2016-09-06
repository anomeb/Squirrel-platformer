using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
        Health health = col.gameObject.GetComponent<Health>();
        if (health)
            health.Die();
        else {
            Rigidbody2D RB = col.gameObject.GetComponent<Rigidbody2D>();
            if (RB)
                Destroy(col.gameObject);
        }
    }

}
