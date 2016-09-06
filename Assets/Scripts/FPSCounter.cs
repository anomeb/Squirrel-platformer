using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FPSCounter : MonoBehaviour {

    Text text;
    float lastTime;
    int iterations = 0;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        ++iterations;
        float time = Time.time;
        if (time - lastTime > 1.0f) {
            lastTime = time;
            text.text = iterations.ToString() + " fps";
            iterations = 0;
        }
        //text.text = (1.0f / Time.deltaTime).ToString();
	}
}
