using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public Vector3 offset;

    public void FixedUpdate(){
        transform.position = target.position;
    }
}
