using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Gun : MonoBehaviour {

    [SerializeField]
    private int maxAmmo;

    [SerializeField]
    private int damage;

    [SerializeField]
    private float range;

    [SerializeField]
    private float fireRate;

    [SerializeField]
    private string weaponName;

    [SerializeField]
    private int currentAmmo;

    [SerializeField]
    private int numberOfMagazine;

    [SerializeField]
    private float timer;

    [SerializeField]
    private GameObject prefab;
    
    public GameObject Shoot(GameObject camera = null) {
        if (timer < fireRate || currentAmmo == 0) {
            return null;
        }


        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.forward * range * range, out RaycastHit hit, range)
            || (camera != null) && (Physics.Raycast(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), camera.transform.forward * range * range, out hit, range))) {
            timer = 0;
            currentAmmo--;
            return hit.collider.gameObject;
        }
        return null;
    }

    public void Reload() {
        if (numberOfMagazine == 0) return;
        numberOfMagazine--;
        currentAmmo = maxAmmo;
    }

    public string Name {
        get => name;
    }

    public int Damage {
        get => damage;
    }

    public void AddAmmo(int magazine) {
        numberOfMagazine += magazine;
    }

    public void Update() {
        timer += Time.deltaTime;
    }

    public override string ToString() {
        return "" + weaponName + ": " + currentAmmo + "/" + numberOfMagazine;
    }

    public static Gun CreateFromJSON(string jsonString) => JsonUtility.FromJson<Gun>(jsonString);

    public string SaveToString() => JsonUtility.ToJson(this);

}
