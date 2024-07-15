using Microsoft.MixedReality.OpenXR;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using QRTracking;
using UnityEngine;

public class TapToSetAnchor : MonoBehaviour, IMixedRealityPointerHandler
{
    public Transform ParentAnchor;
    public GameObject PlaceableObject;
    private Vector3 PostionOffset = new Vector3(0, 0, 0);
    private Quaternion RotationOffset = Quaternion.Euler(90, 90, 90);
    public GameObject seaLevel;
    private Vector3 seaLevelPos;

    public void Start()
    {
        CoreServices.InputSystem?.RegisterHandler<IMixedRealityPointerHandler>(this);
    }

    public void OnEnable()
    {
        CoreServices.InputSystem?.RegisterHandler<IMixedRealityPointerHandler>(this);
    }

    public void OnDisable()
    {
        CoreServices.InputSystem?.UnregisterHandler<IMixedRealityPointerHandler>(this);
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        //Do Nothing
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        //Do Nothing
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        //Do Nothing
    }

    /// <summary>
    /// Position's the anchor object on the QR code. This will not create an anchor to allow for rotation fine tuning
    /// The hand menu contains a create anchor option.
    ///
    /// We don't care (at least for now) what is the QR code as we assume there will be only one in sight.
    /// </summary>
    /// <param name="eventData">Event data from the pointer interaction. Not used in this method</param>
    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {


        var QRCode = GameObject.FindGameObjectWithTag("QRTag");
        if (QRCode == null)
        {
            return;
        }


        //PATCH START
        var id = QRCode.GetComponent<QRCode>().qrCode.SpatialGraphNodeId;
        SpatialGraphNode.FromStaticNodeId(id).TryLocate(FrameTime.OnUpdate, out Pose pose);
        ParentAnchor.transform.SetPositionAndRotation(pose.position + PostionOffset, pose.rotation * RotationOffset);

        //set the relative position of the sea level
        seaLevelPos = seaLevel.transform.position;
        seaLevel.transform.position = new Vector3(seaLevelPos.x, PlaceableObject.transform.position.y - 0.265f, seaLevelPos.z);

        PlaceableObject.SetActive(true);


        //ParentAnchor.transform.position = QRCode.transform.position;

        //PATCH END

        //ParentAnchor.transform.position = QRCode.transform.position;

        //ParentAnchor.transform.eulerAngles = QRCode.transform.eulerAngles;

        
//#if !UNITY_EDITOR
//        ParentAnchor.transform.rotation = Quaternion.Euler(0, QRCode.transform.rotation.eulerAngles.y-270, 0);
//#endif

        //Remove the text on the screen
        //TODO: move text creation to this script so we don't have to search for it... ugh...
        var text = GameObject.FindGameObjectWithTag("NoTagText");
        if (text != null)
        {
            Destroy(text);
        }

        //Destroy the QR Code
        Destroy(QRCode);

        //Disable the "scanner"
        var qrManager = GameObject.Find("QRCodesManager").GetComponent<QRCodesManager>();
        qrManager.StopQRTracking();


        Destroy(this);




    }

}