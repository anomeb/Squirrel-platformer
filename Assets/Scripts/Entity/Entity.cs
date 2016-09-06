using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    [HideInInspector]public Health health;

    protected virtual void Start() {
        health = GetComponent<Health>();
    }

    public virtual void Die() {

    }

    public virtual void FixedUpdate() {

    }
}
