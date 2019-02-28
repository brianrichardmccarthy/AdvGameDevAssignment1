using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavigationComponent : MonoBehaviour {

    [SerializeField]
    List<GameObject> waypoints;

    GameObject currentTarget;
    int index = 0;

    void Start() {
        SetTarget(waypoints[index]);
    }

    void Update() {
        if (currentTarget.name != "player" && Vector3.Distance(currentTarget.transform.position, transform.position) < 1) {
            index = (index + 1) % waypoints.Count;
            SetTarget(waypoints[index]);
        }
    }

    public void ResetTarget() {

        if (currentTarget.name != "player") return;

        index = (index + 1) % waypoints.Count;
        SetTarget(waypoints[index]);
    }

    public void SetTarget(GameObject newtarget) {
        currentTarget = newtarget;
        GetComponent<NavMeshAgent>().SetDestination(newtarget.transform.position);
    }

}
