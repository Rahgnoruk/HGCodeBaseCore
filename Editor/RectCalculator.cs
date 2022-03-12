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
        public Rect GetHalfWidthRect(Rect container)
        {
            return new Rect(container.x, container.y, container.width / 2, lineHeight);
        }
        public Rect GetOneThirdWidthRect(Rect container)
        {
            return new Rect(container.x, container.y, container.width / 3, lineHeight);
        }
        public Rect GetNextLineContainer(Rect previousLineContainer)
        {
            return new Rect(previousLineContainer.x, previousLineContainer.y + lineHeight, previousLineContainer.width, lineHeight);
        }

        public Rect GetFollowingRectWithEqualWidthTo(Rect previousRect)
        {
            float controlXPosition = previousRect.x + previousRect.width + margin;
            return new Rect(controlXPosition, previousRect.y, previousRect.width, lineHeight);
        }
        public Rect CalculatePropertyGroupRect(Rect previousRect, Rect container)
        {
            float controlWidth = container.width / 2f;
            return new Rect(previousRect.x, previousRect.y + 16, controlWidth, 16);
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