using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PickRobotButton : MonoBehaviour
{
    private Button button;

    [SerializeField]
    private Robot robotCleaner;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PickRobot);
    }

    // Update is called once per frame
    void PickRobot()
    {
        MainManager.Instance.currentRobotType = robotCleaner.GetType();
        SceneManager.LoadScene(1);
    }
}
