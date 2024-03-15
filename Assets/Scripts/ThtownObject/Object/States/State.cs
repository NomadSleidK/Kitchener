using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    public abstract void Enter();
    public abstract void Exit();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void OnMouseEnter();
    public abstract void OnMouseOver(Vector3 mousePosition);
    public abstract void OnMouseExit();
    public abstract void OnMouseDown();
    public abstract void OnMouseUp();
}
