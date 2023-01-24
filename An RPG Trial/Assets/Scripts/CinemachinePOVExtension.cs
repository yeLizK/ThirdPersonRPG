using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtension : CinemachineExtension
{
    private InputManager inputManager;
    private Vector3 startingRotation;

    [SerializeField]
    private float clampAngle = 34f;
    [SerializeField]
    private float horizontalSpeed = 10f, verticalSpeed = 10f;



    protected override void Awake()
    {
        inputManager = InputManager.Instance;
        base.Awake();
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                if (startingRotation == null) startingRotation = transform.localRotation.eulerAngles;
                startingRotation = CharacterMovement.Instance.gameObject.transform.rotation.eulerAngles;
                state.RawOrientation = Quaternion.Euler(startingRotation.x, startingRotation.y, 0f);
            }
        }
    }

}
