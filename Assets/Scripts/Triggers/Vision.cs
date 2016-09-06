using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vision : MonoBehaviour {
    [SerializeField] GameObject ignoringGameObject;
    public List<Entity> visibleEntities = new List<Entity>();
    public List<Entity> invisibleEntities = new List<Entity>();
    public Transform distanceTransform;
    public LayerMask mask;
    
    void FixedUpdate() {
        List<Entity> toRemove = new List<Entity>();
        foreach (Entity entity in visibleEntities) {
            if (entity) {
                if (!IsVisible(entity)) {
                    toRemove.Add(entity);
                    invisibleEntities.Add(entity);
                }
            }
            else
                toRemove.Add(entity);
        }
        foreach (Entity entity in toRemove)
            visibleEntities.Remove(entity);
        foreach (Entity entity in invisibleEntities) {
            if (entity) {
                if (IsVisible(entity)) {
                    visibleEntities.Add(entity);
                    toRemove.Add(entity);
                }
            }
            else
                toRemove.Add(entity);
        }
        foreach (Entity entity in toRemove)
            invisibleEntities.Remove(entity);
    }

    void OnTriggerEnter2D(Collider2D col) {
        Entity entity = col.GetComponent<Entity>();
        if (entity)
            AddEntity(entity);
    }

    void OnTriggerStay2D(Collider2D col) {
        Entity entity = col.GetComponent<Entity>();
        if (entity)
            AddEntity(entity);
    }

    void AddEntity(Entity entity) {
        if (IsVisible(entity))
            if (!visibleEntities.Contains(entity))
                visibleEntities.Add(entity);
        else
            if (!visibleEntities.Contains(entity))
                invisibleEntities.Add(entity);
    }

    bool IsVisible(Entity entity) {
        bool isVisible = false;

        int ignoringObjectLayer = ignoringGameObject.layer;
        ignoringGameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

        Transform startPoint = transform.parent;

        Vector2 direction = entity.transform.position - startPoint.position;
        float distance = Vector2.Distance(distanceTransform.position, transform.parent.position);
        RaycastHit2D hit = Physics2D.Raycast(startPoint.position, direction.normalized, distance, mask);
        if (hit)
        if (hit.collider.gameObject.GetComponentInParent<Entity>() == entity) {
                Debug.DrawLine(startPoint.position, ((Vector2)startPoint.position + direction.normalized * distance));
                isVisible = true;
        }

        ignoringGameObject.layer = ignoringObjectLayer;
        return isVisible;
    }

    void OnTriggerExit2D(Collider2D col) {
        Entity entity = col.GetComponent<Entity>();
        if (entity) {
            invisibleEntities.Remove(entity);
            visibleEntities.Remove(entity);
        }
    }
}
