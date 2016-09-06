using UnityEngine;
using System.Collections.Generic;

public class LayerCollisionList : MonoBehaviour {

    public List<Collider2D> list = new List<Collider2D>();

    public int layer;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.layer == layer)
            AddElement(col);
    }
    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.layer == layer)
            AddElement(col);
    }
    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.layer == layer)
            list.Remove(col);
    }

    public void AddElement(Collider2D col) {
        if (!list.Contains(col))
            list.Add(col);
    }
}
