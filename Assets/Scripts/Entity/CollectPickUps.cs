using UnityEngine;
using System.Collections;

public class CollectPickUps : MonoBehaviour {

    protected Shooter shooter;

    protected virtual void Start() {
        shooter = GetComponent<Shooter>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Take(collision);
    }

    void OnCollisionStay2D(Collision2D collision) {
        Take(collision);
    }

    void Take(Collision2D collision) {
        PickUp pickUp = collision.gameObject.GetComponent<PickUp>();
        if (shooter && shooter.missilesQuantity < shooter.maxMissilesQuantity && pickUp is Missile && !((Missile)pickUp).isDestroyed) {
            ((Missile)pickUp).isDestroyed = true;
            ++shooter.missilesQuantity;
            Destroy(pickUp.gameObject);
        }
    }
}
