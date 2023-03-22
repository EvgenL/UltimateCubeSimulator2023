using System.IO;
using Cysharp.Threading.Tasks;
using DefaultNamespace.Ui;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class CoinAnimationManager : SingletonMonoBehaviour<CoinAnimationManager>
    {
        [SerializeField] private AnimatedScoreDisplay _scoreDisplay;
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private float _animationDuration = 1f;
        [SerializeField] private float _spread = 50f;

        public void Animate(int amount, Vector3 startPosition)
        {
            var coinAmount = amount / 10;

            for (int i = 0; i < coinAmount; i++)
            {
                CreateCoinAtRandomPosition(startPosition);
            }

        }

        private void CreateCoinAtRandomPosition(Vector3 startPosition)
        {
            var coin = Instantiate(_coinPrefab, _canvas.transform);

            var startScreenPosition = Camera.main.WorldToScreenPoint(startPosition);
            var targetScreenPosition = _scoreDisplay.transform.position;

            startScreenPosition += new Vector3(
                Random.Range(-_spread, _spread),
                Random.Range(-_spread, _spread)
            );
            coin.transform.position = startScreenPosition;
            
            coin.transform.localScale = Vector3.zero;
            
            // 1 Последовательность анимаций через стрелочную функцию (лямбда функцию)
            // coin.transform.DOScale(Vector3.one, _animationDuration).OnComplete(
            //     () => 
            //         coin.transform.DOMove(targetScreenPosition, _animationDuration)
            //             .OnComplete(() => Destroy(coin.gameObject)));
            
            // 2 через Sequence
            var sequence = DOTween.Sequence();
            sequence.Append(coin.transform.DOScale(Vector3.one, _animationDuration));
            sequence.Append(coin.transform.DOMove(targetScreenPosition, _animationDuration));
            sequence.OnComplete(() => Destroy(coin.gameObject));
            
            // 3 самодельная анимация
            // AnimateTask(coin.transform, targetScreenPosition, _animationDuration);
        }

        // private async void AnimateTask(Transform animatedTransform, Vector3 endPos, float animationDuration)
        // {
        //     var startPos = animatedTransform.position;
        //
        //     var step = 1f / animationDuration;
        //
        //     // Идём от 0 до 1 на протяжении "animationDuration" секунд
        //     for (float t = 0f; t <= 1f; t += step * Time.deltaTime)
        //     {
        //         var middlePosition = Vector3.Lerp(startPos, endPos, t);
        //         animatedTransform.position = middlePosition;
        //         
        //         await UniTask.WaitForEndOfFrame();
        //     }
        // }
    }
}