using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject plane;
    private MeshFilter meshFilter;
    private Animator animator;
    public float speed = 6.0f;
    public VariableJoystick variableJoystick;
    public TMP_Text playerPosition;
    private Camera mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        meshFilter = plane.GetComponent<MeshFilter>();
        Bounds bounds = meshFilter.mesh.bounds;
        Debug.Log($"bounds Size : {bounds.size}");
        Transform planeTransform = plane.GetComponent<Transform>();
        Debug.Log($"planeTransform scale : {planeTransform.localScale}");
          
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Horizontal : {variableJoystick.Horizontal} Vertical : {variableJoystick.Vertical}");

        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        Vector3 moveDir = (cameraForward * variableJoystick.Vertical) + (cameraRight * variableJoystick.Horizontal);
        //Vector3 moveDir = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        moveDir.y = 0f;

        Quaternion cameraRot = mainCamera.transform.localRotation;
        cameraRot.x = 0;
        cameraRot.z = 0;



        animator.SetFloat("Movement", moveDir.magnitude);

        if (moveDir != Vector3.zero)
        {
            //transform.rotation = Quaternion.LookRotation(moveDir) * cameraRot;
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(moveDir);
            transform.Translate(speed * Time.deltaTime * Vector3.forward);

        }
        //Debug.Log($"X : {transform.position.x} Z : {transform.position.z}");
        playerPosition.text = $"X: {transform.position.x:00}, Z: {transform.position.z:00}";

    }
}
