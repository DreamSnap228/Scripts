using UnityEngine;

public class KeepCarOnGround : MonoBehaviour
{
    public float rayDistance = 1.5f;       // Дистанция для Raycast
    public float groundOffset = 0.5f;      // Допустимое расстояние от земли
    public LayerMask groundLayer;           // Слой, на котором находится земля
    public float correctionSpeed = 5f;      // Скорость коррекции позиции

    private Rigidbody rb;                   // Ссылка на компонент Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>();      // Получаем компонент Rigidbody
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

            // Если машина выше допустимого расстояния от земли, корректируем её положение
            if (currentDistance > groundOffset)
            {
                Vector3 targetPosition = transform.position;
                targetPosition.y = hit.point.y + groundOffset; // Устанавливаем целевую позицию
                transform.position = Vector3.Lerp(transform.position, targetPosition, correctionSpeed * Time.deltaTime);
            }
            return true; // Машина на земле
        }
        return false; // Машина в воздухе
    }

    void StopCar()
    {
        // Остановка движения при взлете
        // Можно добавить дополнительную логику, если необходимо
    }
}