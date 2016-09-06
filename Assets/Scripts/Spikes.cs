using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {
    public int damage = 5;
    public float affectSpeed = 2.0f;

    void OnTriggerEnter2D(Collider2D col) {
        Health health = col.GetComponent<Health>();
        if (health) {
            if (Mathf.Abs(col.GetComponent<Rigidbody2D>().velocity.y) > affectSpeed)
                health.Damage(damage);
        }

    }

}
