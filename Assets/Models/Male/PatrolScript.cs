using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f; // Скорость поворота персонажа

    private int currentPatrolIndex = 0;

    private void Update()
    {
        // Определение текущей точки патрулирования
        Transform targetPatrolPoint = patrolPoints[currentPatrolIndex];

        // Перемещение к текущей точке патрулирования
        Vector3 moveDirection = targetPatrolPoint.position - transform.position;
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.World);

        // Поворот персонажа в направлении движения
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Если достигли текущей точки, переход к следующей
        if (Vector3.Distance(transform.position, targetPatrolPoint.position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }
}
