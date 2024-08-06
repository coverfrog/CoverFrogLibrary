using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CoverFrog
{
    [RequireComponent(typeof(Image))]
    public class InputOverlay : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public delegate void OnMouseEventHandler(PointerEventData eventData);

        public static event OnMouseEventHandler OnMouseDown, OnMouseUp;
        
        private void Awake()
        {
            var image = GetComponent<Image>();
            image.color = new Color(0, 0, 0, 0);

            var rt = GetComponent<RectTransform>();
            rt.anchorMin = rt.offsetMin = rt.anchorMax = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.pivot = Vector2.one * 0.5f;
        }

        public void OnPointerDown(PointerEventData eventData) => 
            OnMouseDown?.Invoke(eventData);

        public void OnPointerUp(PointerEventData eventData) =>
            OnMouseUp?.Invoke(eventData);
    }
}
