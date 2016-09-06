using UnityEngine;
using System.Collections;

public class SetAsTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Collider2D>().isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
