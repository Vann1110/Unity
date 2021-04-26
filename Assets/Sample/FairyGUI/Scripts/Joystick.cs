using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using DG.Tweening;
// 事件收發類
public class Joystick : EventDispatcher
{
    //事件監聽者
    public EventListener onMove { get; private set; }
    public EventListener onEnd { get; private set; }

    //minaUI裡的對象
    private GButton joystickButton;
    private GObject thurmb;
    private GObject touchArea;
    private GObject center;

    //搖桿屬性
    private float initX;
    private float initY;
    private float startStageX;
    private float startStageY;
    private float lastStageX;
    private float lastStageY;
    private int touchID;
    public int radius { get; private set; }
    private GTweener tweener;

    public Joystick(GComponent mainUI)
    {
        this.onMove = new EventListener(this, "onMove");
        this.onEnd = new EventListener(this, "onEnd");

        this.joystickButton = mainUI.GetChild("Joystick").asButton;
        this.joystickButton.changeStateOnClick = false;
        this.thurmb = this.joystickButton.GetChild("thurmb");
        this.touchArea = mainUI.GetChild("JoystickArea");
        this.center = mainUI.GetChild("JoystickCenter");

        this.initX = this.center.x + this.center.width / 2;
        this.initY = this.center.y + this.center.height / 2;
        this.touchID = -1;
        this.radius = 150;

        this.touchArea.onTouchBegin.Add(this.onTouchBegin);
        this.touchArea.onTouchMove.Add(this.onTouchMove);
        this.touchArea.onTouchEnd.Add(this.onTouchEnd);
    }

    private void onTouchBegin(EventContext context)
    {
        if (touchID == -1)
        {
            InputEvent inputEvent = (InputEvent)context.data;
            this.touchID = inputEvent.touchId;
            if (this.tweener != null)
            {
                this.tweener.Kill();//消除動畫
                this.tweener = null;
            }

            Vector2 localPos = GRoot.inst.GlobalToLocal(new Vector2(inputEvent.x, inputEvent.y));
            float posX = localPos.x;
            float posY = localPos.y;
            this.joystickButton.selected = true;

            this.lastStageX = posX;
            this.lastStageY = posY;
            this.startStageX = posX;
            this.startStageY = posY;

            this.center.visible = true;
            this.center.SetXY(posX - this.center.width / 2, posY - this.center.height / 2);
            this.joystickButton.SetXY(posX - joystickButton.width / 2, posY - this.joystickButton.height / 2);

            float deltaX = posX - this.initX;
            float deltaY = posY - this.initY;
            float degree = Mathf.Atan2(deltaY, deltaX) * 180 / Mathf.PI;
            this.thurmb.rotation = degree + 90;
            context.CaptureTouch();
        }
    }

    private void onTouchMove(EventContext context)
    {
        InputEvent inputEvent = (InputEvent)context.data;
        if (this.touchID != -1 && inputEvent.touchId == this.touchID)
        {
            Vector2 localPos = GRoot.inst.GlobalToLocal(new Vector2(inputEvent.x, inputEvent.y));
            float posX = localPos.x;
            float posY = localPos.y;
            float moveX = posX - this.lastStageX;
            float moveY = posY - this.lastStageY;
            this.lastStageX = posX;
            this.lastStageY = posY;
            float buttonX = this.joystickButton.x + moveX;
            float buttonY = this.joystickButton.y + moveY;

            float deltaX = buttonX + this.joystickButton.width / 2 - this.startStageX;
            float deltaY = buttonY + this.joystickButton.height / 2 - this.startStageY;

            float rad = Mathf.Atan2(deltaY, deltaX);
            float degree = rad * 180 / Mathf.PI;
            thurmb.rotation = degree + 90;

            float maxX = this.radius * Mathf.Cos(rad);
            float maxY = this.radius * Mathf.Sin(rad);
            if (Mathf.Abs(deltaX) > Mathf.Abs(maxX))
            {
                deltaX = maxX;
            }
            if (Mathf.Abs(deltaY) > Mathf.Abs(maxY))
            {
                deltaY = maxY;
            }

            buttonX = this.startStageX + deltaX;
            buttonY = this.startStageY + deltaY;

            this.joystickButton.SetXY(buttonX - this.joystickButton.width / 2, buttonY - this.joystickButton.height / 2);

            onMove.Call(degree);
        }
    }

    private void onTouchEnd(EventContext context)
    {
        InputEvent inputEvent = (InputEvent)context.data;
        if (this.touchID != -1 && inputEvent.touchId == this.touchID)
        {
            this.touchID = -1;
            this.thurmb.rotation = thurmb.rotation + 180;
            this.center.visible = false;
            this.tweener = this.joystickButton.TweenMove(new Vector2(this.initX - this.joystickButton.width / 2, this.initY - this.joystickButton.height / 2), 0.3f).OnComplete(
               () =>
               {
                   this.tweener = null;
                   this.joystickButton.selected = false;
                   thurmb.rotation = 0;
                   this.center.visible = true;
                   this.center.SetXY(this.initX - center.width / 2, this.initY - this.center.height / 2);

               }
            );
            onEnd.Call();
        }
    }
}
