using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    [SerializeField]static Managers s_instance;
    public static Managers instance { get{ Init(); return s_instance; } }
    // Start is called before the first frame update
    public static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
            Debug.Log("게임 메니저 생성");
        }
    }
    [SerializeField]private UIManager uiManager = new UIManager();
    public UIManager UIManager { get { return uiManager; } }
}
