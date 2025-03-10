
using UdonSharp;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Utility;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class CameraPositionController : ButtonObserver
{
    /// <summary>
    /// 移動対象カメラオブジェクト
    /// </summary>
    [SerializeField]
    GameObject CameraBase;

    /// <summary>
    /// カメラ初期位置ポジション
    /// </summary>
    [SerializeField]
    InitialPosition InitCameraPosition;

    /// <summary>
    /// 移動先カメラポジション
    /// </summary>
    [SerializeField]
    CameraPosition[] CameraPositions;

    OwnerController ownerController;

    void Start()
    {
        ownerController = CameraBase.GetComponent<OwnerController>();

        InitCameraPosition.SetObserver(this);
        InitCameraPosition.SetInitialPosition(CameraBase.transform);
        
        for(int count = 0; count < CameraPositions.Length; count++)
        {
            CameraPositions[count].SetObserver(this);
        }

        if(Networking.LocalPlayer.IsUserInVR())
            SendCustomEventDelayedFrames(nameof(ToggleCameraButton), 5);
    }

    public void ToggleCameraButton()
    {
        EventCameraSystem system = transform.parent.gameObject.GetComponent<EventCameraSystem>();
        if(null == system) return;
        system.ToggleCameraButton();
    }

    public void GetOwner()
    {
        if(!Networking.IsOwner(Networking.LocalPlayer, gameObject))
            Networking.GetOwner(gameObject);
    }

    public override void ButtonClick(Transform moveDestination)
    {
        ownerController.GetOwner();
        CameraBase.transform.position = moveDestination.position;
        CameraBase.transform.rotation = moveDestination.rotation;
    }
    public override void ButtonClick(Vector3 movePosition, Quaternion moveRotation)
    {
        ownerController.GetOwner();
        CameraBase.transform.position = movePosition;
        CameraBase.transform.rotation = moveRotation;
    }
}
