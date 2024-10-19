using UnityEngine;

public class KeepCarOnGround : MonoBehaviour
{
    public float rayDistance = 1.5f;       // ��������� ��� Raycast
    public float groundOffset = 0.5f;      // ���������� ���������� �� �����
    public LayerMask groundLayer;           // ����, �� ������� ��������� �����
    public float correctionSpeed = 5f;      // �������� ��������� �������

    private Rigidbody rb;                   // ������ �� ��������� Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>();      // �������� ��������� Rigidbody
    }

    void Update()
    {
      
    }

    bool CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayDistance, groundLayer))
        {
            float currentDistance = hit.distance;

            // ���� ������ ���� ����������� ���������� �� �����, ������������ � ���������
            if (currentDistance > groundOffset)
            {
                Vector3 targetPosition = transform.position;
                targetPosition.y = hit.point.y + groundOffset; // ������������� ������� �������
                transform.position = Vector3.Lerp(transform.position, targetPosition, correctionSpeed * Time.deltaTime);
            }
            return true; // ������ �� �����
        }
        return false; // ������ � �������
    }

    void StopCar()
    {
        // ��������� �������� ��� ������
        // ����� �������� �������������� ������, ���� ����������
    }
}