using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] patrolPoints; // Массив точек патрулирования
    public float moveSpeed = 3f; // Скорость перемещения
    public float rotationSpeed = 2f; // Скорость вращения

    private int currentPoint = 0; // Текущая точка патрулирования

    void Update()
    {
        // Проверяем, достигли ли текущей точки патрулирования
        if (transform.position == patrolPoints[currentPoint].position)
        {
            // Переходим к следующей точке патрулирования
            currentPoint++;

            // Если достигли конца массива, начинаем с начала
            if (currentPoint >= patrolPoints.Length)
            {
                currentPoint = 0;
            }
        }

        // Перемещаемся к текущей точке патрулирования
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);

        // Вращаемся к текущей точке патрулирования
        Quaternion targetRotation = Quaternion.LookRotation(patrolPoints[currentPoint].position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
