using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour {

    int health;

    public int Health {
        get => health;
        private set => health = value;
    }

    public bool IsDead {
        get => health <= 0;
    }

    public void RestoreHealth(int restore) => health += restore;
    public void TakeDamage(int damage) {
        //=> health -= damage;
        health -= damage;
        Debug.Log(health);
    }

    // Use this for initialization
    void Start () {
        health = 100;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
