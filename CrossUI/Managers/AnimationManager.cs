﻿using System.Collections.Generic;
using System.Linq;
using CrossUI.Enumerations;
using CrossUI.Objects.Animations;
using SFML.Graphics;
using SFML.System;

namespace CrossUI.Managers
{
    public static class AnimationManager
    {
        public static List<BaseAnimation> Animations { get; set; } = new List<BaseAnimation>();

        public static void UpdateAll()
        {
            if (!Animations.Any())
            {
                return;
            }
            
            foreach (var animation in Animations.Where(x => x.State == AnimationState.Playing).ToList())
            {
                animation.Update();
                if (animation.State == AnimationState.Finished)
                {
                    Animations.Remove(animation);
                }
            }
        }
    }

    public static class AnimationExtensions
    {
        public static void AnimateColorChange(this Shape shape, Color color, float duration)
        {
            var animation = new ColorAnimation(duration, shape, color);
            AnimationManager.Animations.Add(animation);
            animation.Play();
        }

        public static void AnimateElasticMove(this Transformable target, Vector2f finalPosition, float duration)
        {
            var animation = new ElasticAnimation(duration, target, finalPosition);
            AnimationManager.Animations.Add(animation);
            animation.Play();
        }
    }
}