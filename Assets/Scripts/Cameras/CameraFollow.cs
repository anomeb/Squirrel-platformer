using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Vector2 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (target)
            transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.y);
	}
}
