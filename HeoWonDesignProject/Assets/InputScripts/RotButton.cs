using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotButton : MonoBehaviour
{
    public void OnRotButtonClockWise()
    {
        Managers.instance.UIManager.targetIMG.rotation = Quaternion.Euler(0, 0,  Managers.instance.UIManager.targetIMG.rotation.eulerAngles.z-90);
    }
    public void OnRotButtonReverseClockWise()
    {
        Managers.instance.UIManager.targetIMG.rotation = Quaternion.Euler(0, 0,  Managers.instance.UIManager.targetIMG.rotation.eulerAngles.z+90);

    }
    public void OnClickDeleteTarget()
    {
        Destroy(Managers.instance.UIManager.targetIMG.gameObject);
    }
}
