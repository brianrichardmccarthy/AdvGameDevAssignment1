using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gun))]
public class PlayerController : MonoBehaviour {

    Gun gunComponent;

    void Start() {
        gunComponent = GetComponent<Gun>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            var camera = GetComponentInChildren<Camera>();
            var hit = gunComponent.Shoot(camera.gameObject);
            if (hit != null) {

                var navigationComponent = hit.GetComponent<NavigationComponent>();

                if (navigationComponent != null) {
                    navigationComponent.SetTarget(gameObject);
                }

                var healthComponent = hit.GetComponent<HealthComponent>();

                if (healthComponent != null) {
                    healthComponent.TakeDamage(gunComponent.Damage);
                }

            }
        }
    }
}
