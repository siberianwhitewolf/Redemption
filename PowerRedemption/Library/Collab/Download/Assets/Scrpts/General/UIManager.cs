using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager UIManagerRef;

    public Image lifeBar;
    public Image baseLifeBar;

    private void Awake()
    {
        UIManagerRef = this;
    }
}
