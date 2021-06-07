using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image mask;
        private float originalSize;
        public static HealthBar instance{ get; private set; }

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            originalSize = mask.rectTransform.rect.width;
        }
        
        public void SetValue(float value)
        {
            mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSize * value);
        }
    }
}

