using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    private void Start()
    {
        // if (PlayerPrefs.HasKey("HP"))
        // {
            // health = PlayerPrefs.GetInt("HP");
        // }
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        // PlayerPrefs.SetInt("HP", health);
        // PlayerPrefs.Save();
    }

}
