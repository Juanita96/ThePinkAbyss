using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    [Header("Visual Effects")]
    public Image fadeImage;

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

    public IEnumerator JakeCamera()
    {
        Transform camTransform = transform; 
        Vector3 originalPos = camTransform.localPosition;
        Quaternion originalRot = camTransform.localRotation;

        
        camTransform.localScale = Vector3.one * 1.05f;
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < 6; i++)
        {
            camTransform.localPosition = originalPos + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
            camTransform.localRotation = Quaternion.Euler(0, 0, Random.Range(-3f, 3f));
            yield return new WaitForSeconds(0.03f);
        }

        camTransform.localPosition = originalPos;
        camTransform.localRotation = originalRot;
        camTransform.localScale = Vector3.one;
    }

    public IEnumerator FadeOut(float duration)
    {
        float elapsedTime = 0f;
        Color currentColor = fadeImage.color;
        while (elapsedTime < duration)
        {
            float progress = elapsedTime / duration;
            currentColor.a = Mathf.Lerp(0f, 1f, progress);
            fadeImage.color = currentColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        currentColor.a = 1f;
        fadeImage.color = currentColor;
    }

    public IEnumerator FadeIn(float duration)
    {
        float elapsedTime = 0f;
        Color currentColor = Color.white;
        fadeImage.color = currentColor;
        while (elapsedTime < duration)
        {
            float progress = elapsedTime / duration;
            currentColor.a = Mathf.Lerp(1f, 0f, progress);
            fadeImage.color = currentColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        currentColor.a = 0f;
        fadeImage.color = currentColor;
    }



}

