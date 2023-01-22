using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack; //KD damage
    public float startTimeBtwAttack;

    public Transform attackPos; 
    public LayerMask enemy; // Tag enemy
    public float attackRang; // Radius damage
    public int damage;
    public Animator anim;

/*
    private void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if(Input.GetMouseButton(0))
            {
                anim.SetTrigger("Attack ");
                Collider2D[] enemis = Physics2D.OverlapCircleAll(attackPos.position, attackRang, enemy);
                for(int i=0; i < enemis.Length; i++)
                {
                    enemis[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }
        }

        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
*/

    public void OnKickButtonDown()
    {
        anim.SetTrigger("Attack ");
        Collider2D[] enemis = Physics2D.OverlapCircleAll(attackPos.position, attackRang, enemy);
        for(int i=0; i < enemis.Length; i++)
        {
            enemis[i].GetComponent<Enemy>().TakeDamage(damage);
        }
        timeBtwAttack = startTimeBtwAttack;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRang);
    }
}
