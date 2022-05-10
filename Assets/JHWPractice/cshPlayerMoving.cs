using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshPlayerMoving : MonoBehaviour
{
    //PlayerEmulator var
    private Vector3 m_velocity;
    public float m_moveSpeed = 2.0f;


    //OculusPractice var
    public int speedForward = 6;
    public int speedSide = 6;
    private float dirX = 0;
    private float dirZ = 0;
    
    void Start()
    {
        
    }
    void Update()
    {
        PlayerMove();
        //OculusPlayerMoving();
    }

    
    //PlayerMovingEmulator
    private void PlayerMove()
    {
        CharacterController controller = GetComponent<CharacterController>();

        m_velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        m_velocity = m_velocity.normalized;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            m_velocity *= 2.0f;
        }

        controller.Move(m_velocity * m_moveSpeed * Time.deltaTime);
       
    }
    

    //Oculus PlayerMoveing Emulaotr

    private void OculusPlayerMoving()
    {
        dirX = 0;
        dirZ = 0;
        if(OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            Vector2 coord = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            var absX = Mathf.Abs(coord.x);
            var absY = Mathf.Abs(coord.y);

            if(absX > absY)
            {
                //Right
                if(coord.x > 0)
                {
                    dirX = 1;
                }
                else
                {
                    dirX = -1;
                }
            }
            else
            {
                if(coord.y > 0)
                {
                    dirZ = 1;
                }
                else
                {
                    dirZ = -1;
                }
            }
            Vector3 moveDir = new Vector3(dirX * speedSide, 0, dirZ * speedForward);
            transform.Translate(moveDir * Time.smoothDeltaTime);
        }
    }
}
