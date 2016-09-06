using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
    public Health health;
    public GameObject HPRectangle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScale();
	}

    public void UpdateScale() {
        Vector3 scale = HPRectangle.transform.localScale;
        scale.x = (float)health.amount / health.maxAmount;
        HPRectangle.transform.localScale = scale;
    }
}
