using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableObject : MonoBehaviour
{
    public abstract void OnClick(GameObject clicker);

    public abstract void OnRelease(GameObject clicker);
}
