using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] patrolPoints; // ������ ����� ��������������
    public float moveSpeed = 3f; // �������� �����������
    public float rotationSpeed = 2f; // �������� ��������

    private int currentPoint = 0; // ������� ����� ��������������

    void Update()
    {
        // ���������, �������� �� ������� ����� ��������������
        if (transform.position == patrolPoints[currentPoint].position)
        {
            // ��������� � ��������� ����� ��������������
            currentPoint++;

            // ���� �������� ����� �������, �������� � ������
            if (currentPoint >= patrolPoints.Length)
            {
                currentPoint = 0;
            }
        }

        // ������������ � ������� ����� ��������������
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);

        // ��������� � ������� ����� ��������������
        Quaternion targetRotation = Quaternion.LookRotation(patrolPoints[currentPoint].position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
