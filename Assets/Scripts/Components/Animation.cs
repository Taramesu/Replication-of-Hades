using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Animation
{
    public class PresentationGO : IComponentData
    {
        public GameObject prefab;
    }

    public class TransformGO : IComponentData
    {
        public Transform transform;
    }

    public class AnimatorGO : IComponentData
    {
        public Animator animator;
    }
}