using UnityEngine;

public class PlaceObjectOnDirection : MonoBehaviour
{
    public Transform Player; // Откуда
    public Transform Enemy; // Куда
    public Transform Camera; // Что перемещать
    public float offsetDistance = 1f; // Расстояние сдвига

    void Update()
    {
        if (Player != null && Enemy != null && Camera != null)
        {
            // Получаем нормализованный вектор направления от fromObject к toObject
            Vector3 direction = Enemy.position - Player.position;

            // Обнуляем Y, чтобы учитывать только X и Z
            direction.y = 0f;

            // Нормализуем вектор снова
            direction = direction.normalized;

            // Получаем точку со сдвигом по направлению
            Vector3 newPosition = Player.position + direction * offsetDistance;

            // Обновляем позицию targetObject
            Camera.position = new Vector3(newPosition.x, Camera.position.y, newPosition.z);
        }

        Vector3 asd = Player.position - Camera.position;


        Quaternion targetRotation = Quaternion.LookRotation(asd);
        Camera.rotation = targetRotation;
    }
}