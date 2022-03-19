using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoTweenTest : MonoBehaviour
{
    public Transform sprite = null;
    public Text text = null;
    public SpriteRenderer cardFront = null;
    public Sprite a = null;
    public void play()
    {
        this.cardFront.sprite = a;
        //新建Sequence物件
        Sequence mySequence = DOTween.Sequence();
        //末尾新增補間動畫
        mySequence.Append(this.sprite.transform.DOLocalRotate(new Vector3(0, 180, 0), 3)).SetEase(Ease.Linear);
        //執行完上一個動畫，才會執行這個
        mySequence.Append(this.text.transform.DOScale(new Vector2(1, 1), 0.5f)).SetEase(Ease.OutBack);
    }
}
