using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] CharacterMovement characterMovement;
    [SerializeField] Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RunBoolArrangement();
    }

    void RunBoolArrangement()
    {
        if (characterMovement.running)
        {
            animator.SetBool("Running", true); 
        }
        else
        {
            animator.SetBool("Running", false);

        }
    }

     void DownBoolArrangement()
    {

    }
    void UpBoolArrangement()
    {

    }
}
