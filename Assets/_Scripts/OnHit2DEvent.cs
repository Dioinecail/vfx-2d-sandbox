using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnHit2DEvent : MonoBehaviour
{
    public GameObject objectToSpawn;
    public bool spawnOnCollision;

    public UnityEvent onHitEvent;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        onHitEvent?.Invoke();
        if (spawnOnCollision)
        {
            int contacts = collision.contactCount;

            for (int i = 0; i < contacts; i++)
            {
                SpawnObject(objectToSpawn, collision.GetContact(i).point);
            }
        }
    }

    public void SpawnObject(GameObject go, Vector3 position)
    {
        Instantiate(go, position, go.transform.rotation);
    }
}