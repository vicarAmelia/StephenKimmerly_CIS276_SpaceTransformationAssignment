using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransform : MonoBehaviour
{
    public Vector2 worldSpacePoint;
    public Transform localObjectTransform;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.up);

        Gizmos.color = Color.blue;
        
        Gizmos.DrawSphere(worldSpacePoint, 0.15f);

        localObjectTransform.localPosition = WorldToLocal(worldSpacePoint);
    }

    // Vector2 LocalToWorld(Vector2 localPoint)
    // {
    //     Vector2 worldOffset = (transform.right * localPoint.x) + (transform.up * localPoint.y);
    //     return (Vector2)transform.position + worldOffset;
    // }
    
    Vector2 WorldToLocal(Vector2 worldPoint)
    {
        Vector2 relativePoint = worldPoint - (Vector2)transform.position;
        float x = Vector2.Dot(relativePoint, transform.right);
        float y = Vector2.Dot(relativePoint, transform.up);

        return new Vector2(x,y);
    }
}