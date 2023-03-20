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
            coin.transform.DOScale(Vector3.one, _animationDuration).OnComplete(
                () => 
                    coin.transform.DOMove(targetScreenPosition, _animationDuration)
                        .OnComplete(() => Destroy(coin.gameObject)));
        }

        // private async void AnimateTask(Transform animatedTransform, 
        //     Vector3 startPos,
        //     Vector3 endPos)
        // {
        //     var direction = startPos - endPos;
        //     var step = direction;
        //     
        //     
        // }
    }
}