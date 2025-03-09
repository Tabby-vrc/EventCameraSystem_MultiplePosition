
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class ButtonObserver : UdonSharpBehaviour
{
    public virtual void ButtonClick(Transform moveDestination){}
    public virtual void ButtonClick(Vector3 movePosition, Quaternion moveRotation){}
}
