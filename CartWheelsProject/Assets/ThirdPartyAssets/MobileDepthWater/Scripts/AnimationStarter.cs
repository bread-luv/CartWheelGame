namespace Assets.MobileOptimizedWater.Scripts
{
    using UnityEngine;

    public class AnimationStarter : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Motion _animation;

        public void Awake()
        {
            animator.Play(_animation.name);
        }
    }
}
