using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class HealthCubeComponent : MonoBehaviour {

    private static int[] amounts = {
        25,
        50,
        75,
        100
    };

    int amount;

    void Start() {
        amount = amounts[Random.Range(0, amounts.Length)];
    }

    public void OnControllerColliderHit(HealthComponent healthComponent) {
        healthComponent.RestoreHealth(amount);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision) {
        HealthComponent healthComponent = collision.collider.gameObject.GetComponent<HealthComponent>();
        if (healthComponent != null) {

            // LevelManager = GameObject.Find("");

            healthComponent.RestoreHealth(amount);
            Destroy(gameObject);
        }
    }
}
