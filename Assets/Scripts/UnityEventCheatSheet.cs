using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class UnityEventCheatSheet : MonoBehaviour
    {
        // При инициализации игры
        // Тут создаём стартовые данные для игры
        private void Awake()
        {
        }

        // на первом кадре
        // Например - ставим игрока на стартовую позицию
        private void Start()
        {
        }

        // На каждом кадре
        // Пишеи игровую логику, обабатываем ввод
        // Анимируем анимации из кода
        private void Update()
        {
            // var ob = FindObjectOfType<PickUp>(); // НЕЛЬЗЯ
            
            // МОЖНО, называется кеширование
            if (_ob == null)
            {
                _ob = FindObjectOfType<PickUp>();
            }
            Debug.Log(_ob);
        }

        private PickUp _ob;
        

        // Физический апдейт
        // по умолчанию 50 раз в секунду
        // Перемещаем объекты, которые используют физику
        private void FixedUpdate()
        {
        }

        // Одно из событий физики, работает после FixedUpdate
        private void OnCollisionEnter(Collision collision)
        {
        }

        // На каждом кадре
        // После Update
        // Двигаем камеру
        private void LateUpdate()
        {
        }

        // При включении объекта в SetActive
        private void OnEnable()
        {
        }

        // При выключении объекта в SetActive
        // На дизейбленом объекте не вызывается Update
        private void OnDisable()
        {
        }

        // При уничтожении объекта
        // Уничтожаем так же всё, что должно уйти с объектом
        // нельзя тут создавать новые объекты через Instanciate
        private void OnDestroy()
        {
        }
        
        // редактор
        
        // Каждый кадр, когда в инспекторе выбран наш объект
        private void OnGUI()
        {
        }

        // Каждый кадр, когда в инспекторе изменено значение на нашем объекте
        // делаем для написания кастомных тулзов
        private void OnValidate()
        {
        }

        // Здесь мы рисуем Gizmo для редактора
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(Vector3.zero, Vector3.one);
        }
        
        
        
        
        
        // При закрытии приложения
        // Подчищаем всё, созданное приложением
        // Не всегда работает на телефонах
        private void OnApplicationQuit()
        {
        }

        // В старой Input  системе можно отследить события мыши
        // private void OnMouseDrag()
        // private void OnMouseEnter()
        // private void OnMouseExit()

        
        
        
        // Перед тем как объект скроется из видимости
        // Прячем всё что принадлежит объекту
        private void OnPreCull()
        {
        }

        // Каждый кадр когда объект будет нарисован
        // не вызывается когда объект за Cull-ен 
        private void OnPreRender()
        {
        }
    }
}