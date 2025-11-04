using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Settings")]
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    [Header("Current Target")]
    public Transform target;
    public GameObject player;
    public GameObject playerGreen;
    public GameObject playerBlue;
    public GameObject playerOrange;
    public GameObject playerViolet;


    private bool playerActive = false;
    private bool playerGreenActive = false;
    private bool playerBlueActive = false;
    private bool playerOrangeActive = false;
    private bool playerVioletActive = false;

   
    void LateUpdate()
    {
        FindTarget();
        if (target == null) return;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    private void FindTarget()
    {

        if (player != null && player.gameObject.activeInHierarchy && !playerActive)
        {
            SetTargetIfDifferent(player.transform);
            return;
        }
        else if (playerGreen != null && playerGreen.gameObject.activeInHierarchy && !playerGreenActive)
        {
            SetTargetIfDifferent(playerGreen.transform);
            return;
        }
        else if (playerBlue != null && playerBlue.gameObject.activeInHierarchy && !playerBlueActive)
        {
            SetTargetIfDifferent(playerBlue.transform);
            return;
        }
        else if (playerOrange != null && playerOrange.gameObject.activeInHierarchy && !playerOrangeActive)
        {
            SetTargetIfDifferent(playerOrange.transform);
            return;
        }
        else if (playerViolet != null && playerViolet.gameObject.activeInHierarchy && !playerVioletActive)
        {
            SetTargetIfDifferent(playerViolet.transform);
            return;
        }
    }

    private void SetTargetIfDifferent(Transform newTarget)
    {
        if (target != newTarget) SetTarget(newTarget);
    }

}

