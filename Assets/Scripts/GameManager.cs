using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    void Awake()
    {
        InitPlayer();

        // Fixing camera to the player
        Camera.main.transform.parent = player.transform;
    }

    void InitPlayer()
    {
        System.Type playerType = MainManager.Instance.currentRobotType;
        player = ((Robot)FindObjectOfType(playerType, true)).gameObject;

        player.SetActive(true);
        player.transform.position = new Vector3(0, 1.5f, 0);
    }
}
