using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ObjectiveComponent : MonoBehaviour {

    [SerializeField]
    int maxNumberOfCollectObjectives;

    // [SerializeField]
    GameObject objectivePrefab;

    // [SerializeField]
    Text scoreText;

    int numberOfCollectObjectives;
    bool isObjectiveComplete;

    void Awake() {
        objectivePrefab = Resources.Load("Prefabs/Objective") as GameObject;
        GameObject playerHUD = GameObject.Find("playerHUD");
        scoreText = playerHUD.GetComponentsInChildren<Text>().Where(x => x.name == "score").First();
    }

    void Start() {
        Initialize();
    }

    void SpawnObjective() {
        Instantiate(objectivePrefab, new Vector3(Random.Range(-50.0f, 50.0f), 1, Random.Range(-50.0f, 50.0f)), Quaternion.identity);
    }

    public bool IsObjectiveCompleted {
        get => isObjectiveComplete;
    }

    public void PlayerCollectedObjective() {
        isObjectiveComplete = ++numberOfCollectObjectives == maxNumberOfCollectObjectives;
        SpawnObjective();
    }

    public void Initialize() {
        numberOfCollectObjectives = 0;
        isObjectiveComplete = false;
        SpawnObjective();
    }

    void Update() {
        scoreText.text = string.Format("{0}/{1}", numberOfCollectObjectives, maxNumberOfCollectObjectives);
    }
}
