using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gun))]
[RequireComponent(typeof(HealthComponent))]
public class PlayerController : MonoBehaviour {

    Gun gunComponent;
    HealthComponent healthComponent;

    [SerializeField]
    LevelManager levelManager;

    void Start() {
        gunComponent = GetComponent<Gun>();
        healthComponent = GetComponent<HealthComponent>();
        // Resources.Load
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {

        if (hit.collider.gameObject.tag == "ai") {
            // levelmanager reset
        } else if (hit.collider.gameObject.tag == "objective") {
            hit.collider.gameObject.GetComponent<ObjectiveCollision>().OnControllerColliderHit();
        } else if (hit.collider.gameObject.tag == "ammo") {
            hit.collider.gameObject.GetComponent<AmmoCubeComponent>().OnControllerColliderHit(gunComponent);
        } else if (hit.collider.gameObject.tag == "health") {
            hit.collider.gameObject.GetComponent<HealthCubeComponent>().OnControllerColliderHit(healthComponent);
        }
    }

    void Update() {

        gunComponent.ShowOnHUD();
        healthComponent.ShowOnHUD();

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
        } else if (Input.GetKeyDown(KeyCode.R)) {
            gunComponent.Reload();
        }
    }
}
