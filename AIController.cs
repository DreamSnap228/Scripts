using UnityEngine;

public class CustomAIController : MonoBehaviour
{
    public float rayDistance = 100f;          // ��������� ��� ��������� ����
    public float sideRayDistance = 100f;      // ��������� ��� ������� ����� (����������� �����)
    public float turnSpeed = 35f;             // �������� �������� ����������
    public float maxSteerAngle = 45f;         // ������������ ���� ��������

    public float speed = 60f;                // �������� �������� ������
    public float rotationSpeed = 100f;        // �������� �������� ��� ������� �����������
    public float rayHeightOffset = 01.5f;        // �������� �� ��� Y ��� ����� (������)

    void Update()
    {
        // �������� ���
        Ray frontRay = new Ray(transform.position + Vector3.up * rayHeightOffset, transform.forward);
        Debug.DrawRay(transform.position + Vector3.up * rayHeightOffset, transform.forward * rayDistance, Color.red);

        // ������� ���� ��� �������� �����������
        Ray leftRay = new Ray(transform.position + Vector3.up * rayHeightOffset, Quaternion.AngleAxis(-45, transform.up) * transform.forward);
        Ray rightRay = new Ray(transform.position + Vector3.up * rayHeightOffset, Quaternion.AngleAxis(45, transform.up) * transform.forward);

        //������������ ������� ����� ��� �������(������ �����, ����� ������) � ����������� ������
        Debug.DrawRay(transform.position, leftRay.direction * sideRayDistance, Color.green);  // ����� ���
        Debug.DrawRay(transform.position, rightRay.direction * sideRayDistance, Color.blue);  // ������ ���

        RaycastHit hit;

        

        // ��������� ������� ��� �����
        if (Physics.Raycast(leftRay, out hit, sideRayDistance))
        {
            // ���� ����� ���� �����������, ������������ ������
            SteerCar(1); // ������������� �������� ��� �������� ������
        }
        // ��������� ������� ��� ������
        else if (Physics.Raycast(rightRay, out hit, sideRayDistance))
        {
            // ���� ������ ���� �����������, ������������ �����
            SteerCar(-1); // ������������� �������� ��� �������� �����
        }
        else
        {
            // ���� ����������� ���, ������ ���� �����
            SteerCar(0);
        }

      
    }

    // ����� ��� ���������� ��������� ����������
    void SteerCar(float direction)
    {
        // ������������ ����� ���� �������� �� ������ �����������
        float steerAngle = maxSteerAngle * direction;

        // ������ ������������ ������
        transform.Rotate(Vector3.up, steerAngle * Time.deltaTime * turnSpeed);
    }

    // ����� ��� ����������� �������� ������
   
}
