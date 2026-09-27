using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    Vector3 offset;


    void Start()
    {
        offset = transform.position - target.position;
    }


    void LateUpdate()
    {
        transform.position = target.position + target.rotation * offset;
        transform.LookAt(target);
    }
}
