using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System;

public class CollectAreaScript : MonoBehaviour
{
    public TextMeshPro myText;
    public int current;
    public int goal;
    private CheckPointScript checkPointScript;
    private UiControllerScript uiController;
    public Transform platform;
    public float moveSpeed;
    private Vector3 targetPosPlatform;
    public bool checker;
    public bool newChecker;
    public float timer;
    public bool startCountdown;
    private MeshRenderer meshRenderer;
    public Transform gate1;
    public Transform gate2;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        checkPointScript = GameObject.FindGameObjectWithTag("picker").GetComponent<CheckPointScript>();
        uiController = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<UiControllerScript>();
        meshRenderer = GetComponent<MeshRenderer>();
        targetPosPlatform = platform.position + new Vector3(0, 0.57f, 0);
        checker = true;
        startCountdown = false;
        newChecker = true;
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = current + "/" + goal;
        if (startCountdown && newChecker)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                startCountdown = false;
                uiController.ShowLosePanel();
                checker = false;
            }
        }
        if (current >= goal && checker)
        {
            newChecker = false;
            startCountdown = false;
            MovePlatform();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "collectable")
        {
            startCountdown = true;
            current++;
            Destroy(other.gameObject);
        }
    }
    
    void MovePlatform()
    {
        platform.position = Vector3.MoveTowards(platform.position, targetPosPlatform, moveSpeed * Time.deltaTime / 10);
        if (platform.position == targetPosPlatform)
        {
            checkPointScript.goalReached = true;
            checker = false;
            uiController.SetCheckpointIndicator();
        }

        gate1.transform.rotation = Quaternion.Lerp(Quaternion.Euler(-90, 0 ,0),  gate1.transform.rotation ,Time.deltaTime * 10f);
        gate2.transform.rotation = Quaternion.Lerp(Quaternion.Euler(-90, 0 ,0),  gate1.transform.rotation ,Time.deltaTime * 10f);
    }
}
