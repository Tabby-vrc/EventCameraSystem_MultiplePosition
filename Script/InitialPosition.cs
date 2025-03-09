
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class InitialPosition : UdonSharpBehaviour
{
    private Vector3 MoveDestinationPosition;
    private Quaternion MoveDestinationRotation;

    private ButtonObserver buttonObserver;

    public void SetObserver(ButtonObserver observer)
    {
        buttonObserver = observer;
    }

    public void SetInitialPosition(Transform initialPosition)
    {
        MoveDestinationPosition = initialPosition.position;
        MoveDestinationRotation = initialPosition.rotation;
    }

    public void ButtonClick()
    {
        buttonObserver.ButtonClick(MoveDestinationPosition, MoveDestinationRotation);
    }
}
