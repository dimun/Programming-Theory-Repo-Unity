using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private int score = 0;

    public TMP_Text scoreText;

    void Awake()
    {
        InitPlayer();

        // Fixing camera to the player
        Camera.main.transform.parent = player.transform;
    }

    private void OnEnable()
    {
        player.GetComponent<Robot>().OnCleanedDust += IncreaseScore;
    }

    private void OnDisable()
    {
        player.GetComponent<Robot>().OnCleanedDust -= IncreaseScore;
    }

    private void IncreaseScore()
    {
        score += 1;
        scoreText.text = $"Score: {score}";
    }

    void InitPlayer()
    {
        System.Type playerType = MainManager.Instance.currentRobotType;
        player = ((Robot)FindObjectOfType(playerType, true)).gameObject;

        player.SetActive(true);
        player.transform.position = new Vector3(0, 1.5f, 0);
    }
}
