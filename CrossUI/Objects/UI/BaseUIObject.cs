﻿

using System;
using SFML.Graphics;
using SFML.System;

namespace CrossUI.Objects.UI
{
    public abstract class BaseUIObject : BaseObject
    {
        public BaseUIObject(string id, Vector2f position) : base(id)
        {
            ID = id;
            Position = position;
            //DrawableObject = new RenderTexture(100,100);
        }

        public Vector2f Position { get; set; }

        public bool Hovering { get; set; }

        public delegate void ClickDelegate();
        public delegate void HoverDelegate(bool inside);

        public event ClickDelegate OnClick;
        public event HoverDelegate OnHover;
        
        public FloatRect Rect { get; protected set; }

        internal void TriggerOnClick()
        {
            OnClick?.Invoke();
        }
        
        internal void TriggerOnHover(bool value)
        {
            if (value != Hovering)
            {
                Hovering = value;
                OnHover?.Invoke(Hovering);
                Console.WriteLine($"Hover changed to {value}");
            }
        }

        internal abstract void Draw(RenderWindow window);
        protected abstract void Update();

        public bool IsInside(float x, float y)
        {
            return Rect.Contains(x, y);
        }
    }
}