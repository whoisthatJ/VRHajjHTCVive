using UnityEngine;

public class CircularPatrolLeft : MonoBehaviour
{
    public Transform centerPoint; // ����� �����
    public float radius = 5f; // ������ �����
    public float speed = 0.5f; // �������� ��������
    public float rotationSpeed = 45f; // �������� ��������

    private float angle = 0f;

    private void Update()
    {
        // ��������� ����� ������� ������� �� �����
        float x = centerPoint.position.x + Mathf.Cos(angle) * radius;
        float z = centerPoint.position.z + Mathf.Sin(angle) * radius;

        // ������������� ����� ������� �������
        transform.position = new Vector3(x, transform.position.y, z);

        // ��������� ����������� � ����������� �����
        Vector3 targetDirection = centerPoint.position - transform.position;

        // ��������� ���������� ��������
        Quaternion rotation = Quaternion.LookRotation(targetDirection);

        // ��������� ������� � �������
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // ����������� ���� ��� ���������� �����
        angle += speed * Time.deltaTime;

        // ���� ���� ������� �� ������� 360 ��������, �������� ���
        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
