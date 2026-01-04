using UnityEngine;

public class AnimatedObjectDestroy : MonoBehaviour
{
    [SerializeField] private Animator animator; 
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length );
        //get destoryed one lopp of animation plays 
    }
}
