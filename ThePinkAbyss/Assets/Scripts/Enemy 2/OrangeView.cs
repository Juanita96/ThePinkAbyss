using Unity.VisualScripting;
using UnityEngine;

public class OrangeView : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private OrangeEnemy_Controller orange;

    private string isChasing = "isChasing";
    private string fireActive = "fireActive";

    void Start()
    {
        animator = GetComponent<Animator>();
        orange = GetComponent<OrangeEnemy_Controller>();
    }

    void Update()
    {
        animator.SetBool(isChasing, orange.isChasing);

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(fireActive))
        {
            animator.SetBool(fireActive, orange.fireActive);
        }
        
    }
}
