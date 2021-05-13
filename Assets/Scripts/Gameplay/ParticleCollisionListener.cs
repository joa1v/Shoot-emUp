using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionListener : MonoBehaviour
{
    private ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public int damage;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log(other.name);
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        HpScript ship = other.GetComponent<HpScript>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            if (ship)
            {
                ship.TakeDamage(damage);
            }
            i++;
        }
    }
}
