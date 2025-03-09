
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class CameraPosition : UdonSharpBehaviour
{
    [SerializeField]
    private Transform MoveDestinationPosition;

    private ButtonObserver buttonObserver;

    public void SetObserver(ButtonObserver observer)
    {
        buttonObserver = observer;
    }

    public void ButtonClick()
    {
        buttonObserver.ButtonClick(MoveDestinationPosition);
    }
}
