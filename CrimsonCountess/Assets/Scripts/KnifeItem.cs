/*
 * Script created by: Blake Shortland | Editor: [Null]
 */
using UnityEngine;
using VRTK;

public class KnifeItem : MonoBehaviour
{
    [SerializeField]
    HandBleed[] leftHandColliders;
    [SerializeField]
    HandBleed[] rightHandColliders;

    bool isGrabbed = false;


    public void UnGrabKnife()
    {
        isGrabbed = false;
    }

    public void GrabKnife()
    {
        VRTK_InteractableObject knifeObj = GetComponent<VRTK_InteractableObject>();
        GameObject interactingObject = knifeObj.GetGrabbingObject();

       
        switch (interactingObject.gameObject.tag)
        {
            case ("LeftController"):
                for (int i = 0; i < leftHandColliders.Length; i++)
                {
                    leftHandColliders[i].TurnOff();
                    rightHandColliders[i].TurnOn();
                }
                break;

            case ("RightController"):
                for (int i = 0; i < rightHandColliders.Length; i++)
                {
                    leftHandColliders[i].TurnOn();
                    rightHandColliders[i].TurnOff();
                }
                break;

            default:
                for (int i = 0; i < rightHandColliders.Length; i++)
                {
                    leftHandColliders[i].TurnOff();
                    rightHandColliders[i].TurnOff();
                }
                break;
        }
    }

}
