using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiControllerScript : MonoBehaviour
{
    public PickerMoveScript pickerMove;
    public CheckPointScript checkPointScript;
    public GameObject winPanel;
    public GameObject startPanel;
    public GameObject losePanel;
    public bool levelCleared;
    public bool startPanelBool;
    public float speed;
    public Text currentLevelText, nextLevelText;
    public List<GameObject> checkpointIndicators;
    private int checkpointIndex;
    // Start is called before the first frame update
    void Start()
    {
        speed = pickerMove.speed;
        levelCleared = false;
        ShowStartPanel();
        startPanelBool = true;
        checkpointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPanelBool && Input.GetMouseButtonDown(0))
        {
            CloseStartPanel();
        }

        currentLevelText.text = FindObjectOfType<LevelDesignScript>().currentLevel.ToString();
        nextLevelText.text = FindObjectOfType<LevelDesignScript>().currentLevel + 1 + "";
    }
    public void ShowWinPanel()
    {
        levelCleared = true;
        winPanel.SetActive(true);
    }
    public void CloseWinPanel()
    {
        winPanel.SetActive(false);
    }
    public void ShowStartPanel()
    {
        startPanelBool = true;
        startPanel.SetActive(true);
        pickerMove.levelFinished = true;
        checkPointScript.goalReached = true;
    }
    public void CloseStartPanel()
    {
        startPanelBool = false;
        startPanel.SetActive(false);
        pickerMove.levelFinished = false;
        pickerMove.speed = speed;
    }
    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
    }
    public void CloseLosePanel()
    {
        losePanel.SetActive(false);
    }

    public void SetCheckpointIndicator()
    {
        if (checkpointIndex >= checkpointIndicators.Count) return;
        
        checkpointIndicators[checkpointIndex].GetComponent<Image>().color = Color.green;
        checkpointIndex++;
    }

    public void ResetCheckpointIndicators()
    {
        checkpointIndex = 0;
        
        foreach(var checkpointIndicator in checkpointIndicators)
        {
            checkpointIndicator.GetComponent<Image>().color = Color.white;
        }
    }
}
