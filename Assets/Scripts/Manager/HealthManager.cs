﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class HealthManager : MonoBehaviour {

    public int startingHealth = 1000;

    // Use Unity's event system to decouple logic relating
    // to "dying" from managing health. This is good practice
    // for writing extensible code.
    public UnityEvent zeroHealthEvent;

    public int currentHealth;

	// Use this for initialization
	void Start () {
        this.ResetHealthToStarting();
	}

    // Reset health to original starting health
    public void ResetHealthToStarting()
    {
        currentHealth = startingHealth;
    }

    // Reduce the health of the object by a certain amount
    // If health lte zero, destroy the object
    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            this.zeroHealthEvent.Invoke();
           // ScoreManager scoreManager = GameObject.Find ("Managers").transform.Find("ScoreManager").GetComponent<ScoreManager> ();
            ScoreManager.killScore();
        }
    }

    // Get the current health of the object
    public int GetHealth()
    {
        return this.currentHealth;
    }
}
