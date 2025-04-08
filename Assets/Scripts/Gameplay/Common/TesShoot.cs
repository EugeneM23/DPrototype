using UnityEngine;

public class TesShoot : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public float speed = 5f;
    public float heightFactor = 0.25f; // Чем выше значение, тем выше парабола

    private float journeyLength;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(pointA.position, pointB.position);
    }

    void Update()
    {
        // вычисляем расстояние между точками
        float distance = Vector3.Distance(pointA.position, pointB.position);

        // вычисляем сколько времени нужно, чтобы пройти это расстояние с заданной скоростью
        float duration = distance / speed;

        // t — параметр от 0 до 1, двигается туда-обратно равномерно
        float t = Mathf.PingPong((Time.time - startTime) / duration, 1f);

        // позиция объекта по параболе
        Vector3 currentPos = GetParabolaPoint(pointA.position, pointB.position, t);
        pointC.position = currentPos;
    }

    Vector3 GetParabolaPoint(Vector3 start, Vector3 end, float t)
    {
        Vector3 mid = Vector3.Lerp(start, end, t);

        float distance = Vector3.Distance(start, end);
        float height = distance * heightFactor;

        float parabola = 4 * height * t * (1 - t);
        mid.y += parabola;

        return mid;
    }
}