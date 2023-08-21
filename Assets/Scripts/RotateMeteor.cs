using UnityEngine;

public class RotateMeteor : MonoBehaviour
{

    [SerializeField] private float rotateSpeed = 0.01f;

    private void Start()
    {
        if (Random.value >= 0.5)
        {
            rotateSpeed *= -1f;
        }
    }

    void Update()
    {

        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
