using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockNewsModal : BaseView
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private Button buttonIncrement;
    [SerializeField] private Button buttonDecrement;

    [SerializeField] private float step = 0.0625f;

    private void Awake()
    {
        buttonIncrement.onClick.AddListener(OnClickButtonIncrement);
        buttonDecrement.onClick.AddListener(OnClickButtonDecrement);
    }

    private void OnClickButtonDecrement()
    {
        scrollbar.value = Mathf.Clamp(scrollbar.value - step, 0, 1);
    }

    private void OnClickButtonIncrement()
    {
        scrollbar.value = Mathf.Clamp(scrollbar.value + step, 0, 1);
    }
}
