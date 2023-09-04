using UnityEngine;

public class CircularPatrolLeft : MonoBehaviour
{
    public Transform centerPoint; // Центр круга
    public float radius = 5f; // Радиус круга
    public float speed = 0.5f; // Скорость движения
    public float rotationSpeed = 45f; // Скорость поворота

    private float angle = 0f;

    private void Update()
    {
        // Вычисляем новую позицию объекта на круге
        float x = centerPoint.position.x + Mathf.Cos(angle) * radius;
        float z = centerPoint.position.z + Mathf.Sin(angle) * radius;

        // Устанавливаем новую позицию объекта
        transform.position = new Vector3(x, transform.position.y, z);

        // Вычисляем направление к центральной точке
        Vector3 targetDirection = centerPoint.position - transform.position;

        // Вычисляем кватернион поворота
        Quaternion rotation = Quaternion.LookRotation(targetDirection);

        // Применяем поворот к объекту
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // Увеличиваем угол для следующего кадра
        angle += speed * Time.deltaTime;

        // Если угол выходит за пределы 360 градусов, обнуляем его
        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
