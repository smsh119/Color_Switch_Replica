using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleRotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed = -10f;
    [SerializeField] float destroyDistanceDifference = 6f;

    GameObject cameraTransform;

    void Start()
    {
        float startRotation = Random.Range(0f, 360f);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, startRotation);
        cameraTransform = FindObjectOfType<CameraFollowScript>().gameObject;
    }
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        if(cameraTransform.transform.position.y-transform.position.y>destroyDistanceDifference)
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
