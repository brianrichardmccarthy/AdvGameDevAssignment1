using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(NavigationComponent))]
[RequireComponent(typeof(Gun))]
[RequireComponent(typeof(DetectionComponent))]
public class TypeOneAI : MonoBehaviour {
    // Start is called before the first frame update

    DetectionComponent detectionComponent;
    NavigationComponent navigationComponent;
    HealthComponent healthComponent;
    Gun gunComponent;

    [SerializeField]
    GameObject player;

    void Start() {
        detectionComponent = GetComponent<DetectionComponent>();
        navigationComponent = GetComponent<NavigationComponent>();
        gunComponent = GetComponent<Gun>();
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.RestoreHealth(100);
    }

    // Update is called once per frame
    void Update() {

        if (healthComponent.IsDead) {
            Destroy(gameObject);
        } else {
            if (detectionComponent.DetectPlayer) {
                navigationComponent.SetTarget(player);
                var hit = gunComponent.Shoot();
                if (hit != null) {
                    var healthComponent = hit.GetComponent<HealthComponent>();

                    if (healthComponent != null) {
                        healthComponent.TakeDamage(gunComponent.Damage);
                    }
                }
            } else {
                navigationComponent.ResetTarget();
            }
        }
    }
}
