using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    public Vector2[] dragStart = new Vector2[2];
    List<RaycastResult> results = new List<RaycastResult>();
    public RectTransform targetIMGTR;
    public RectTransform targetParent;
    public UnityEngine.UI.Image parentIMG;
    public Vector2 targetOriginValue;
    public RectTransform menuBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MenuBarMovement();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isOnBTNUI())
            {
                FindTarget();
                switch (Managers.instance.UIManager.checkedEditorTools)
                {
                    case EdditerType.None:
                        dragStart[0] = Vector3.zero;

                        break;
                    case EdditerType.Scale:
                        dragStart[0] = Input.mousePosition;
                        if (targetIMGTR != null)
                        {
                            targetOriginValue = new Vector2(targetIMGTR.rect.width, targetIMGTR.rect.height);
                        }
                        break;
                    case EdditerType.RotCloakDir:
                        dragStart[0] = Input.mousePosition;
                        break;
                    case EdditerType.RotCloakReverseDir:
                        dragStart[0] = Input.mousePosition;
                        break;
                    case EdditerType.Cut:
                        dragStart[0] = Input.mousePosition;
                        break;
                }
            }
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            if (isOnBTNUI())
            {
                Vector2 relVa = dragStart[1] - dragStart[0];
                switch (Managers.instance.UIManager.checkedEditorTools)
                {
                    case EdditerType.None:
                        if (targetParent != null)
                        {
                            dragStart[1] = Input.mousePosition;
                            relVa = dragStart[1] - dragStart[0];
                            targetParent.position = relVa; 
                        }
                        break;
                    case EdditerType.Scale:
                        dragStart[1] = Input.mousePosition;
                        if (targetIMGTR !=null)
                        {
                            if ((Managers.instance.UIManager.targetIMG.rotation.eulerAngles/180).z == 0)
                            {
                                targetIMGTR.sizeDelta = targetOriginValue + (relVa * NormalizedVec());
                                targetParent.sizeDelta = targetIMGTR.sizeDelta;
                            }
                            else
                            {
                                Vector2 normalTempVec = targetOriginValue + (relVa * NormalizedVec());

                                targetIMGTR.sizeDelta = new Vector2(normalTempVec.y, normalTempVec.x);
                                targetParent.sizeDelta = targetIMGTR.sizeDelta;
                            }

                        }
                        break;
                    case EdditerType.RotCloakDir:
                        dragStart[1] = Input.mousePosition;
                        break;
                    case EdditerType.RotCloakReverseDir:
                        dragStart[1] = Input.mousePosition;
                        break;
                    case EdditerType.Cut:
                        dragStart[1] = Input.mousePosition;
                        break;
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            switch (Managers.instance.UIManager.checkedEditorTools)
            {
                case EdditerType.None:
                    dragStart[1] = Vector3.zero;
                    break;
                case EdditerType.Scale:
                    dragStart[1] = Input.mousePosition;
                    break;
                case EdditerType.RotCloakDir:
                    dragStart[1] = Input.mousePosition;
                    break;
                case EdditerType.RotCloakReverseDir:
                    dragStart[1] = Input.mousePosition;
                    break;
                case EdditerType.Cut:
                    dragStart[1] = Input.mousePosition;
                    break;
            }
        }

    }
    public void MenuBarMovement()
    {
        if (targetIMGTR != null)
        {
            if (!menuBar.gameObject.activeSelf)
            {
                menuBar.gameObject.SetActive(true);
            }
            menuBar.anchoredPosition = targetParent.anchoredPosition-(Vector2.up*(((targetIMGTR.sizeDelta.y+ menuBar.sizeDelta.y) / 2)));
        }
        else
        {
            if (menuBar.gameObject.activeSelf)
            {
                menuBar.gameObject.SetActive(false);
            }
        }
    }
    PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
    public bool isOnBTNUI()
    {

        pointerEventData.position = Input.mousePosition;


        EventSystem.current.RaycastAll(pointerEventData, results);

        // 감지된 UI 요소의 이름을 콘솔에 출력합니다.
        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.layer == 6)
            {
                return false;
            }
        }
        return true;
    }
    public void FindTarget()
    {
        pointerEventData.position = Input.mousePosition;
        EventSystem.current.RaycastAll(pointerEventData, results);
        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.layer == 7)
            {
                if (targetIMGTR == null)
                {
                    targetIMGTR = results[i].gameObject.transform as RectTransform;
                    targetParent = targetIMGTR.parent as RectTransform;
                    Managers.instance.UIManager.targetIMG = targetParent;
                    targetOriginValue = new Vector2(targetIMGTR.rect.width, targetIMGTR.rect.height);
                    parentIMG = targetParent.GetComponent<UnityEngine.UI.Image>();
                    Color tempColor = Color.white;
                    tempColor.a = 255;
                    parentIMG.color = tempColor;
                }
                else
                {
                    Color tempColor = Color.white;
                    tempColor.a = 0;
                    parentIMG.color = tempColor;
                    targetIMGTR = null;
                    targetParent = null;
                    targetIMGTR = results[i].gameObject.transform as RectTransform;
                    targetParent = targetIMGTR.parent as RectTransform;
                    Managers.instance.UIManager.targetIMG = targetParent;
                    targetOriginValue = new Vector2(targetIMGTR.rect.width, targetIMGTR.rect.height);
                    parentIMG = targetParent.GetComponent<UnityEngine.UI.Image>();
                    Color tempColorTwo = Color.white;
                    tempColorTwo.a = 255;
                    parentIMG.color = tempColorTwo;
                }
                break;
            }
            else
            {
                Color tempColor = Color.white;
                tempColor.a = 0;
                Managers.instance.UIManager.checkedEditorTools = EdditerType.None;
                if (parentIMG != null)
                {
                    parentIMG.color = tempColor;
                }
                Managers.instance.UIManager.targetIMG = null;
                targetIMGTR = null;
                targetParent = null;
            }
        }
    }
    public Vector2 NormalizedVec()
    {
        if (targetIMGTR != null)
        {
            Vector2 tempVec = dragStart[0]-(Vector2)targetIMGTR.position;
            return tempVec.normalized;
        }
        return Vector2.zero;
    }
}
