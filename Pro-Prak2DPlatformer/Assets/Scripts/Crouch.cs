using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Crouch : MonoBehaviour
{
    private Animator ani;
    public bool IsCrouch = false;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            IsCrouch = !IsCrouch;
            CrouchFunction();
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            ani.SetTrigger("dash");
        }
        else
        {
            ani.ResetTrigger("dash");
        }
    }

    void CrouchFunction()
    {
        if (IsCrouch == true)
        {
            ani.SetBool("crouch", true);
        }
        else
        {
            ani.SetBool("crouch", false);
        }
    }

    void DashFunction()
    {

    }
}