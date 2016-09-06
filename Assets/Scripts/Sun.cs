using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {

    public float step = 0.01f;

    void FixedUpdate() {
        transform.Rotate(Vector3.up, step);
    }

}
