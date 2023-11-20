using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScripts : MonoBehaviour
{
    public byte num;
    public void OnEdditButtonClick()
    {
        Managers.instance.UIManager.checkedEditorTools = (EdditerType)num;

    }

}
