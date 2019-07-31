using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCubeComponent : MonoBehaviour {

    private static int[] amounts = {
        5, 10, 15, 20
    };

    int amount;

    void Start() {
        amount = amounts[Random.Range(0, amounts.Length)];
    }

    public void OnControllerColliderHit(Gun gunComponent) {
        gunComponent.AddAmmo(amount);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision) {
        Gun gunComponent = collision.collider.gameObject.GetComponent<Gun>();
        
        if (gunComponent != null) {
            gunComponent.AddAmmo(amount);
            Destroy(gameObject);
        }

    }

    void Update() {

    }
}
