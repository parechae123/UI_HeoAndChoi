using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class IconCreater : MonoBehaviour
{
    [SerializeField] byte iconNumber;

    public void OnClickCreateIcon()
    {
        if (Managers.instance.UIManager.targetClothFace != null)
        {
            RectTransform tempRect = Instantiate<GameObject>(Resources.Load<GameObject>("mark_" + iconNumber), Managers.instance.UIManager.targetClothFace).transform as RectTransform;
            tempRect.anchoredPosition = Vector3.zero;
        }
    }
}
