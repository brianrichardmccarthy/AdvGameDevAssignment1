using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour {

    int health;

    bool canHeal;

    public int Health {
        get => health;
        private set => health = value;
    }

    public bool IsDead {
        get => health <= 0;
    }

    public void RestoreHealth(int restore) => health += restore;
    public void TakeDamage(int damage) => health -= damage;

    // Use this for initialization
    void Start () {
        health = 100;
	}

    public void ShowOnHUD() {
        GameObject playerHUD = GameObject.Find("playerHUD");
        Text gunText = playerHUD.GetComponentsInChildren<Text>().Where(x => x.name == "health").First();
        gunText.text = string.Format("Health <{0}>", health);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
