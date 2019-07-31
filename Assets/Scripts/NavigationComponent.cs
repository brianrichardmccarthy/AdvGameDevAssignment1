using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavigationComponent : MonoBehaviour {

    [SerializeField]
    List<GameObject> waypoints;
    [SerializeField]
    GameObject player;

    bool fleePlayer;

    GameObject currentTarget;
    int index = 0;

    [SerializeField]
    bool randomWaypoints;

    void Start() {
        SetTarget(waypoints[index]);
        fleePlayer = false;
        player = GameObject.FindGameObjectWithTag("player");
        waypoints = new List<GameObject>();
        waypoints.AddRange(GameObject.FindGameObjectsWithTag("waypoints"));
    }

    void Update() {
        if (!fleePlayer) {
            if (currentTarget.name != "player" && Vector3.Distance(currentTarget.transform.position, transform.position) < 1) {
                if (randomWaypoints) SetRandomTargert();
                else {
                    SetTarget(waypoints[index]);
                    index = (index + 1) % waypoints.Count;
                }
            }
        } else {
            FleePlayer();
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

    public void SetRandomTargert() {
        index = Random.Range(0, waypoints.Count);
        SetTarget(waypoints[index]);
    }

    private GameObject FindHealthPack() {
        return new GameObject();
    }

    private GameObject FindAmmoPack() {
        return new GameObject();
    }

    public void FleePlayer() {
        // check if there is any health packs
            // -> go to health pack
        // check if ai needs ammo
        // check if there is any ammo packs
            // -> go to ammo pack
            // then chase the player
        // move away from the player

        // store the starting transform
        Transform startTransform = transform;

        // temporarily point the object to look away from the player
        transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);

        float multiplyBy = 3;

        // Then we'll get the position on that rotation that's multiplyBy down the path (you could set a Random.range
        // for this if you want variable results) and store it in a new Vector3 called runTo
        Vector3 runTo = transform.position + transform.forward * multiplyBy;

        //So now we've got a Vector3 to run to and we can transfer that to a location on the NavMesh with samplePosition.

        // 5 is the distance to check, assumes you use default for the NavMesh Layer name
        NavMesh.SamplePosition(runTo, out NavMeshHit hit, 5, 1 << NavMesh.GetAreaFromName("Default"));

        // reset the transform back to our start transform
        transform.position = startTransform.position;
        transform.rotation = startTransform.rotation;

        // And get it to head towards the found NavMesh position
        GetComponent<NavMeshAgent>().SetDestination(hit.position);
    }

}
