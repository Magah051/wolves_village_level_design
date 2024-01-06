using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public int attackDamage = 10;
    public Vector2 knockback = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Ver o que será hit
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
        {
            //If parent is facing the left by localscale, our knockback x flips its value to face the left as well
            Vector2 deliveredKnockback = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
            //Hit o alvo
            bool gotHit = damageable.Hit(attackDamage, knockback);
            if (gotHit)
                Debug.Log(collision.name + " hit for " + attackDamage);
        }
    }
}
