using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HyperGnosys.Core
{
    public class RectCalculator
    {
        private float lineHeight;
        private float margin;

        public RectCalculator(float margin, float lineHeight)
        {
            this.margin = margin;
            this.lineHeight = lineHeight;
        }

        public Rect GetFullWidthRect(Rect container)
        {
            return new Rect(container.x, container.y, container.width, lineHeight);
        }
        public (Rect, Rect) Get1to1Rects(Rect container)
        {
            Rect firstRect = new Rect(container.x, container.y, container.width / 2, lineHeight);
            Rect secondRect = new Rect(GetSecondRectX(firstRect), container.y, firstRect.width, lineHeight);
            return (firstRect, secondRect);
        }
        public (Rect, Rect) Get1to3Rects(Rect container)
        {
            Rect smallRect = new Rect(container.x, container.y, container.width / 3, lineHeight);
            Rect bigRect = new Rect(GetSecondRectX(smallRect), container.y, smallRect.width * 1.9f, lineHeight);
            return (smallRect, bigRect);
        }
        public (Rect, Rect) Get1to4Rects(Rect container)
        {
            Rect smallRect = new Rect(container.x, container.y, container.width / 4, lineHeight);
            Rect bigRect = new Rect(GetSecondRectX(smallRect), container.y, smallRect.width * 2.9f, lineHeight);
            return (smallRect, bigRect);
        }
        public (Rect, Rect) GetRectsFromFirstRectWidth(Rect container, float firstRectWidth)
        {
            Rect smallRect = new Rect(container.x, container.y, firstRectWidth, lineHeight);
            float remainingWidth = container.width - firstRectWidth;
            Rect bigRect = new Rect(GetSecondRectX(smallRect), container.y, remainingWidth *0.9f, lineHeight);
            return (smallRect, bigRect);
        }
        private float GetSecondRectX(Rect firstRect)
        {
            return firstRect.x + firstRect.width + margin;
        }
        public Rect GetNextLineContainer(Rect previousLineContainer)
        {
            return new Rect(previousLineContainer.x, previousLineContainer.y + lineHeight, previousLineContainer.width, lineHeight);
        }
        public float CalculateTotalHeigh(SerializedProperty property, Rect[] totalRects)
        {
            float addedHeight = 0;
            foreach(Rect rect in totalRects)
            {
                addedHeight += rect.height;
            }
            return EditorGUI.GetPropertyHeight(property, true) + addedHeight;
        }
    }
}