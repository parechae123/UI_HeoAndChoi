using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    public Vector2[] dragStart = new Vector2[2];
    public LayerMask UItarget;
    List<RaycastResult> results = new List<RaycastResult>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, UItarget);
            if (hit.collider != null)
            {
                switch (Managers.instance.UIManager.checkedEditorTools)
                {
                    case EdditerType.None:
                        Debug.Log(Managers.instance.UIManager.checkedEditorTools);
                        break;
                    case EdditerType.Scale:
                        Debug.Log(Managers.instance.UIManager.checkedEditorTools);
                        break;
                    case EdditerType.RotCloakDir:
                        Debug.Log(Managers.instance.UIManager.checkedEditorTools);
                        break;
                    case EdditerType.RotCloakReverseDir:
                        Debug.Log(Managers.instance.UIManager.checkedEditorTools);
                        break;
                    case EdditerType.Cut:
                        Debug.Log(Managers.instance.UIManager.checkedEditorTools);
                        break;
                }
                dragStart[0] = Input.mousePosition;
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                dragStart[1] = Input.mousePosition;
            }
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;


            EventSystem.current.RaycastAll(pointerEventData, results);

            // 감지된 UI 요소의 이름을 콘솔에 출력합니다.
            for (int i = 0; i < results.Count; i++)
            {
                
                if (results[i].gameObject != null)
                {
                    Debug.Log("UI Element Clicked: " + results[i].gameObject.name);
                }
            }
        }
    }
}
