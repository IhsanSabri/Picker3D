using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    public PickerMoveScript pickerMove;
    public UiControllerScript uiController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "finishline")
        {
            pickerMove.levelFinished = true;
            uiController.ShowWinPanel();
        }
    }
}
