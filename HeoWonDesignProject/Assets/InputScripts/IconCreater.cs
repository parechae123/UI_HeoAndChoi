using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class IconCreater : MonoBehaviour
{
    [SerializeField] byte iconNumber;

    public void OnClickCreateIcon()
    {
        RectTransform tempRect = Instantiate<GameObject>(Resources.Load<GameObject>("mark_" + iconNumber), transform.parent.parent).transform as RectTransform;
        tempRect.anchoredPosition = Vector3.zero;
        if (Resources.Load<GameObject>("mark_" + iconNumber) != null)
        {

        }
    }
}
