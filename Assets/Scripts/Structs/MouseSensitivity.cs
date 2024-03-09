using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct MouseSensitivity
{
    [SerializeField]
    float horizontal;

    [SerializeField]
    float vertical;

    [SerializeField]
    bool invertHorizontal;

    [SerializeField]
    bool invertVertical;

    public float getHorizontal()
    {
        return horizontal;
    }

    public float getVertical()
    {
        return vertical;
    }

    public int getInvertHorizontal()
    {
        return invertHorizontal ? 1 : -1;
    }

    public int getInvertVertical()
    {
        return invertVertical ? 1 : -1;
    }

    
}
