using UnityEngine;

public class CustomAIController : MonoBehaviour
{
    public float rayDistance = 100f;          // Дистанция для переднего луча
    public float sideRayDistance = 100f;      // Дистанция для боковых лучей (увеличенная длина)
    public float turnSpeed = 35f;             // Скорость поворота автомобиля
    public float maxSteerAngle = 45f;         // Максимальный угол поворота

    public float speed = 60f;                // Скорость движения вперед
    public float rotationSpeed = 100f;        // Скорость поворота при объезде препятствия
    public float rayHeightOffset = 01.5f;        // Смещение по оси Y для лучей (подъем)

    void Update()
    {
        // Передний луч
        Ray frontRay = new Ray(transform.position + Vector3.up * rayHeightOffset, transform.forward);
        Debug.DrawRay(transform.position + Vector3.up * rayHeightOffset, transform.forward * rayDistance, Color.red);

        // Боковые лучи для проверки препятствий
        Ray leftRay = new Ray(transform.position + Vector3.up * rayHeightOffset, Quaternion.AngleAxis(-45, transform.up) * transform.forward);
        Ray rightRay = new Ray(transform.position + Vector3.up * rayHeightOffset, Quaternion.AngleAxis(45, transform.up) * transform.forward);

        //Визуализация боковых лучей для отладки(зелёный слева, синий справа) с увеличенной длиной
        Debug.DrawRay(transform.position, leftRay.direction * sideRayDistance, Color.green);  // Левый луч
        Debug.DrawRay(transform.position, rightRay.direction * sideRayDistance, Color.blue);  // Правый луч

        RaycastHit hit;

        

        // Проверяем боковой луч слева
        if (Physics.Raycast(leftRay, out hit, sideRayDistance))
        {
            // Если слева есть препятствие, поворачиваем вправо
            SteerCar(1); // Положительное значение для поворота вправо
        }
        // Проверяем боковой луч справа
        else if (Physics.Raycast(rightRay, out hit, sideRayDistance))
        {
            // Если справа есть препятствие, поворачиваем влево
            SteerCar(-1); // Отрицательное значение для поворота влево
        }
        else
        {
            // Если препятствий нет, машина едет прямо
            SteerCar(0);
        }

      
    }

    // Метод для управления поворотом автомобиля
    void SteerCar(float direction)
    {
        // Рассчитываем новый угол поворота на основе направления
        float steerAngle = maxSteerAngle * direction;

        // Плавно поворачиваем машину
        transform.Rotate(Vector3.up, steerAngle * Time.deltaTime * turnSpeed);
    }

    // Метод для постоянного движения вперед
   
}
