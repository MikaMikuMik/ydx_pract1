using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SphereScript : MonoBehaviour
{
    public GameObject SphereShadow;
    public GameObject EnemyCube;
    public GameObject PointsCube;

    public float SphereMoveFwdSpeed = 1.0f;
    public float SphereMoveUpSpeed = 0.01f;
    
    bool isGameActive = false;
    int pointsCount = 0;
    float translateY= 0.0f;
    float traversedDist = 0.0f;

    GameUIScript uiGameObject;
    MainCameraScript mainCameraScript;

    // Start is called before the first frame update
    void Start()
    {
        uiGameObject = GameObject.FindObjectOfType<GameUIScript>();
        mainCameraScript = GameObject.FindObjectOfType<MainCameraScript>();
    }

    public void ChangeGameActiveMode(bool inIsActive)
    {
        isGameActive = inIsActive;

        if (isGameActive)
        {
            // скрываем сообщение
            uiGameObject.ChangeStartGameMsgVisibility(false);
            // сбрасываем счёт
            pointsCount = 0;
            uiGameObject.ChangePointsCount(pointsCount);
            // ставим скорость для камеры
            mainCameraScript.SetCameraSpeed(SphereMoveFwdSpeed);
            // начинается игра
        }
        else
        {
            // ставим шарик в начальную позицию
            transform.position = new Vector3(-8.0f, 0.0f, 0.0f);
            // сбрасываем его скорость по Y
            translateY = 0.0f;
            // сбрасываем счётчик пройденного расстония
            traversedDist = 0.0f;
            // ставим камеру в начальную позицию и останавливаем её
            mainCameraScript.SetInitPosition();
            mainCameraScript.SetCameraSpeed(0.0f);
            // выводим сообщение нажми пробел для начала игры
            uiGameObject.ChangeStartGameMsgVisibility(true);
            // убираем лишние препятствия с уровня
            CleanCubes();
        }
    }

    void CleanCubes()
    {
        foreach(var obj in GameObject.FindObjectsOfType<CubeEnemyScript>())
        {
            GameObject.Destroy(obj.gameObject);
        }

        foreach (var obj in GameObject.FindObjectsOfType<CubePointsScript>())
        {
            GameObject.Destroy(obj.gameObject);
        }
    }

    void GenerateEnemyCubes()
    {
        float enemyYPos = Random.Range(0, 6) * Mathf.RoundToInt(Random.Range(-1, 1));

        var enemyPosition = transform.position + new Vector3(16 + 10, enemyYPos, 0.0f);

        GameObject.Instantiate(EnemyCube, enemyPosition, Quaternion.identity);

        var pointsPosition = transform.position + new Vector3(16 + 15, enemyYPos, 0.0f);

        GameObject.Instantiate(PointsCube, pointsPosition, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<CubeEnemyScript>(out var CubeScriptComp))
        {
            ChangeGameActiveMode(false);
        }

        if (other.gameObject.TryGetComponent<CubePointsScript>(out var CubePointsScript))
        {
            pointsCount++;
            uiGameObject.ChangePointsCount(pointsCount);

            GameObject.Destroy(CubePointsScript.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive == false)
        {

            if (Input.GetKey(KeyCode.Space))
            {
                ChangeGameActiveMode(true);
            }

            return;
        }

        if (Mathf.Abs(transform.position.y) > 6.0f)
        {
            ChangeGameActiveMode(false);
        }

        // todo: жить будет, но можно сделать пул объектов для скорости
        GameObject.Instantiate(SphereShadow, transform.position, Quaternion.identity);

        if (Input.GetKey(KeyCode.Space))
        {
            translateY += SphereMoveUpSpeed;
        }
        else
        {
            translateY -= SphereMoveUpSpeed;
        }

        transform.Translate(SphereMoveFwdSpeed, translateY, 0);

        traversedDist += SphereMoveFwdSpeed;

        if (Mathf.RoundToInt(traversedDist) / 20 == 1)
        {
            GenerateEnemyCubes();

            traversedDist = 0.0f;
        }
    }
}
