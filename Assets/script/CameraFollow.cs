using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;


    // toutes les frames, la caméra va suivre le joueur 
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
