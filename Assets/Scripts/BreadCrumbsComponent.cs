using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BreadCrumbsComponent : MonoBehaviour {
    List<GameObject> breadcrumbs;
    [SerializeField]
    GameObject breadCrumbPrefab;

    [SerializeField]
    float maxTime;
    [SerializeField]
    float currentTime;

    void Start() {
        breadcrumbs = new List<GameObject>();
    }

    void Update() {
        currentTime += Time.deltaTime;
        if (currentTime > maxTime) {
            currentTime = 0;
            AddBreadCrumb();
        }
    }

    public List<GameObject> BreadCrumbs => breadcrumbs;

    public void AddBreadCrumb() {
        while (breadcrumbs.Count >= 10) {
            Destroy(breadcrumbs[0]);
            breadcrumbs.RemoveAt(0);
        }

        breadcrumbs.Add(Instantiate(breadCrumbPrefab, transform.position, Quaternion.identity));

    }
}
