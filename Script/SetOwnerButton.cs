
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

[UdonBehaviourSyncMode(BehaviourSyncMode.Continuous)]
public class SetOwnerButton : UdonSharpBehaviour
{
    [SerializeField]
    private TMP_Text _ownerNameText;

    [UdonSynced]
    private int _ownerID;

    public void ButtonClick()
    {
        if(!Networking.IsOwner(Networking.LocalPlayer, gameObject))
            Networking.SetOwner(Networking.LocalPlayer, gameObject);

        _ownerID = Networking.LocalPlayer.playerId;
        RequestSerialization();
    }

    public override void OnDeserialization()
    {
        _ownerNameText.text = VRCPlayerApi.GetPlayerById(_ownerID).displayName;
    }
}
