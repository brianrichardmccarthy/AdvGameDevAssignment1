using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionComponent : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float sightCastingDistance;

    [SerializeField]
    private float smellMinDistance;

    public bool Sight() {
        Ray ray = new Ray {
            origin = transform.position + Vector3.up
        };
        ray.direction = transform.forward * sightCastingDistance;
        Debug.DrawRay(ray.origin, ray.direction * sightCastingDistance);

        return Physics.Raycast(ray.origin, ray.direction * sightCastingDistance, out RaycastHit hit, sightCastingDistance);
    }

    public bool DetectPlayer => Sight() || Hear || Smell();

    public bool Hear {
        get {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            return distance < 6;
        }
    }

    public bool Smell() {
        
        foreach (var breadCrumbs in player.GetComponent<BreadCrumbsComponent>().BreadCrumbs) {
            if (Vector3.Distance(transform.position, breadCrumbs.transform.position) < smellMinDistance) {
                return true;
            }
        }

        return false;
    }

}
