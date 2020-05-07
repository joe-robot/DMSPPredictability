//windyWindWind.cs
//Class that is the test script created for WindRegion.cs used for the first room (see WindRegion.cs for comments)
//By Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class windyWindWind : MonoBehaviour
{
    [SerializeField] GameObject FPSController;
    private CharacterController charController;
    private FirstPersonController controller;

    public bool windUp = false;
    public bool windDown = false;
    public bool windLeft = false;
    public bool windRight = false;

    public GameObject[] windObjects;

    private int windMode = 3;

    // Start is called before the first frame update
    void Start()
    {
        controller = FPSController.GetComponent<FirstPersonController>();
        charController = FPSController.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (true)
        {
            int windAmount = 3;
            if (windUp)
            {
                if (windMode != 0)
                {
                    //moveWind(0);
                }
                float heightMultiplier = windAmount == 3 ? 3.5f : 0.7f * windAmount;
                controller.m_GravityMultiplier = 5f - heightMultiplier;
            }
            else if (windDown)
            {
                if (windMode != 1)
                {
                    //moveWind(1);
                }
                controller.m_GravityMultiplier = (5f + 0.4f * windAmount);
            }
            else if (windLeft)
            {
                if (windMode != 2)
                {
                    //moveWind(2);
                }
                if (windAmount > 1 && !charController.isGrounded)   //Only move player if jump in wind
                {
                    Vector3 leftMove = new Vector3(2f * (windAmount - 1), 0, 0);
                    charController.Move(leftMove * Time.fixedDeltaTime);
                }
            }
            else if (windRight)    //Only move player if jump in wind
            {
                if (windMode != 3)
                {
                    //moveWind(3);
                }
                if (windAmount > 1 && !charController.isGrounded)
                {
                    Vector3 leftMove = new Vector3(-2f * (windAmount - 1), 0, 0);
                    charController.Move(leftMove * Time.fixedDeltaTime);
                }
            }
            else
            {
                controller.m_GravityMultiplier = 2;
            }
        }
        else
        {
            controller.m_GravityMultiplier = 5f;
        }
    }

   /* private void moveWind(int newWindPos)
    {
        windObjects[windMode].SetActive(false);

        windObjects[newWindPos].SetActive(true);

        windMode = newWindPos;
    }*/
}
