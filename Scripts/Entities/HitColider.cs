using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitColider : MonoBehaviour
{
    public string punchName;
    public float damage;

    public Fighter owner;

    void OnTriggerEnter(Collider other)
    {
        if (owner.attacking)
        {
            Fighter somebody = other.gameObject.GetComponent<Fighter>();
            if (somebody != null && somebody != owner)
            {
                //Debug.Log("I hit " + somebody + " with " + punchName);
                somebody.hurt(damage);
            }
        }
    }
}
