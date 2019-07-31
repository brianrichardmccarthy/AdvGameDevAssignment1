using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ObjectiveComponent))]
public class LevelManager : MonoBehaviour {

    ObjectiveComponent objectiveComponent;

    [SerializeField]
    Canvas canvas;

    [SerializeField]
    GameObject ammoPack;

    [SerializeField]
    GameObject healthPack;

    List<GameObject> ammoPacks;
    List<GameObject> healthPacks;
    
    float currentHealthTimer;
    [SerializeField]
    float healthTimer;

    [SerializeField]
    float ammoTimer;
    float currentAmmoTimer;

    float currentTimer;
    float maxTimer;

    bool gameOver;
    Text timerText;

    void Start() {
        Initialize();
    }
    
    void Update() {
        currentTimer += Time.deltaTime;
        currentAmmoTimer += Time.deltaTime;
        currentHealthTimer += Time.deltaTime;
        gameOver = currentTimer > maxTimer || objectiveComponent.IsObjectiveCompleted;
        if (gameOver) {
            Debug.Log("Game over");
        } else {
            UpdateTimer();
            if (currentAmmoTimer > ammoTimer) {
                SpawnAmmoPack();
            }
            if (currentHealthTimer > healthTimer) {
                SpawnHealthPack();
            }
        }

    }

    void UpdateTimer() {
        int min = (int)currentTimer / 60, second = (int)currentTimer % 60;
        timerText.text = string.Format("{0}:{1}", min, second);
    }
    
    public void Initialize() {
        ammoPacks = new List<GameObject>();
        healthPacks = new List<GameObject>();
        objectiveComponent = GetComponent<ObjectiveComponent>();
        currentTimer = 0.0f;
        currentHealthTimer = 0.0f;
        currentAmmoTimer = 0.0f;
        maxTimer = 300;
        gameOver = false;
        GameObject playerHUD = GameObject.Find("playerHUD");
        timerText = playerHUD.GetComponentsInChildren<Text>().Where(x => x.name == "timer").First();
    }

    void SpawnHealthPack() {

        healthPacks = healthPacks.Where(h => h != null).ToList();

        if (healthPacks.Count == 10) return;
        healthPacks.Add(Instantiate(healthPack, new Vector3(Random.Range(-50.0f, 50.0f), 1, Random.Range(-50.0f, 50.0f)), Quaternion.identity));
        currentHealthTimer = 0.0f;
    }

    void SpawnAmmoPack() {
        ammoPacks = ammoPacks.Where(h => h != null).ToList();
        if (ammoPacks.Count == 10) return;
        ammoPacks.Add(Instantiate(ammoPack, new Vector3(Random.Range(-50.0f, 50.0f), 1, Random.Range(-50.0f, 50.0f)), Quaternion.identity));
        currentAmmoTimer = 0.0f;
    }

}
