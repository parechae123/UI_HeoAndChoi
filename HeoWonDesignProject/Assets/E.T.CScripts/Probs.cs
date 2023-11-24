using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Probs
{


}
public enum EdditerType
{
    None,Scale,RotCloakDir,RotCloakReverseDir,Cut
}
public enum RenderState
{
    none,front,back
}
[System.Serializable]
public class RenderCL
{
    [SerializeField]private RectTransform front;
    [SerializeField]private RectTransform back;
    [SerializeField]private RectTransform frontIcon;
    [SerializeField]private RectTransform backIcon;
    [SerializeField] private RectTransform activatedFace;
    [SerializeField] private Vector2[] originPos = new Vector2[3];
    
    public void Init()
    {
        originPos[1] = frontIcon.anchoredPosition;
        originPos[2] = backIcon.anchoredPosition;
        float tempX = originPos[2].x - originPos[1].x;
        originPos[0] = new Vector2(originPos[1].x-tempX, originPos[1].y);
    }

    private RenderState state;
    public RenderState State
    {
        get
        {
            return state;
        }
        set
        {
            ChangeState(value);
            state = value;
        }
    }
    private void ChangeState(RenderState aa)
    {
        switch (aa)
        {
            case RenderState.none:
                frontIcon.anchoredPosition = originPos[1];
                front.gameObject.SetActive(false);
                backIcon.anchoredPosition = originPos[2];
                back.gameObject.SetActive(false);
                Managers.instance.UIManager.targetClothFace = null;
                break;
            case RenderState.front:
                frontIcon.DOAnchorPos(originPos[1],0.2f);
                front.gameObject.SetActive(true);
                backIcon.DOAnchorPos(originPos[2],0.2f);
                back.gameObject.SetActive(false);
                Managers.instance.UIManager.targetClothFace = front;
                break; 
            case RenderState.back:
                frontIcon.DOAnchorPos(originPos[0], 0.2f);
                front.gameObject.SetActive(false);
                backIcon.DOAnchorPos(originPos[1], 0.2f);
                back.gameObject.SetActive(true);
                Managers.instance.UIManager.targetClothFace = back;
                break;
        }
    }
}
//0 = 크기조절 1 = 시계방향으로 회전 2 = 반시계방향 회전 3 = 이미지 오리기