using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DefaultNamespace
{
    public class ResourcesTextureLoader : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        
        private async UniTaskVoid Start()
        {
            // 1 Асинхронно - современно, модно, молодёжно
            // var texture = await Resources.LoadAsync<Texture>("Textures/GrassTexture");
            //
            // _renderer.material.SetTexture("_MainTex", (Texture)texture);
            
            
            // 2 Самый древний способ - синхронно. Вешает игру ненадолго
            // var texture = Resources.Load("Textures/GrassTexture");
            //
            // _renderer.material.SetTexture("_MainTex", (Texture)texture);
            
            // 3 Норм, но устаревший способ через корутину
            StartCoroutine(LoadTexture());
        }

        private IEnumerator LoadTexture()
        {
            var operation = Resources.LoadAsync<Texture>("Textures/GrassTexture");

            // пассивное ожидание - класс
            // yield return operation;
            
            // активное ожидание - древность // UnityWebRequest
            while (!operation.isDone)
            {
                // Ждать пассивно до следующего кадра
                yield return null;
            }
            
            _renderer.material.SetTexture("_MainTex", (Texture)operation.asset);
        }
    }
}