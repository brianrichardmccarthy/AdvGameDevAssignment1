using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCollision : MonoBehaviour {

    void Start() {
    }

    void Update() {
    }

    public void OnControllerColliderHit() {
        GameObject.FindGameObjectWithTag("levelmanager").GetComponent<ObjectiveComponent>().PlayerCollectedObjective();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }

}
