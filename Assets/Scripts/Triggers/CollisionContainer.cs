using UnityEngine;
using System.Collections.Generic;

public class CollisionContainer <T> : MonoBehaviour where T : MonoBehaviour {

    public List<T> list = new List<T>();
    
    public void AddElement(T t) {
            if (!list.Contains(t))
                list.Add(t);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col) {
        T t = col.GetComponent<T>();
        if (t)
            AddElement(t);
    }

    protected virtual void OnTriggerStay2D(Collider2D col) {
        T t = col.GetComponent<T>();
        if (t)
            AddElement(t);
    }

    protected virtual void OnTriggerExit2D(Collider2D col) {
        T t = col.GetComponent<T>();
        if (t) {
            list.Remove(t);
        }
    }
}
