using Cysharp.Threading.Tasks;
using PenguinPushers.Utils;
using PenguinPushers.Views;

namespace PenguinPushers.Managers
{
    public class GameplayManager : BaseManager<GameplayManager>
    {
        private int _winGameScore;
        private int _lossGameSecondsCount;

        protected override async void Initialize()
        {
            await UniTask.WaitUntil(() => PenguinsManager.Instance != null &&
                                          PenguinsManager.Instance.IsInitialized);

            _winGameScore = PenguinsManager.Instance.PenguinViewInstancesInitialCount;
            _lossGameSecondsCount = 30;

            IsInitialized = true;
        }

        protected override void UnInitialize()
        {
        }

        protected override async void Subscribe()
        {
            // TODO: fix async await of Initialize
            await UniTask.WaitUntil(() => IsInitialized);

            await UniTask.WaitUntil(() => TimeManager.Instance != null &&
                                          TimeManager.Instance.IsInitialized);
            TimeManager.Instance.SecondsPassedCountChanged += TimeManager_SecondsPassedCountChanged;
            TimeManager_SecondsPassedCountChanged(TimeManager.Instance.SecondsPassedCount);

            await UniTask.WaitUntil(() => ScoreManager.Instance != null &&
                                          ScoreManager.Instance.IsInitialized);
            ScoreManager.Instance.ScoreChanged += ScoreManager_ScoreChanged;
            ScoreManager_ScoreChanged(ScoreManager.Instance.Score);

            await UniTask.WaitUntil(() => CollisionHandlingManager.Instance != null &&
                                          CollisionHandlingManager.Instance.IsInitialized);
            CollisionHandlingManager.Instance.TriggerEnter += CollisionHandlingManager_TriggerEnter;

            StartTheGame();
        }

        protected override void UnSubscribe()
        {
            if (TimeManager.Instance != null)
            {
                TimeManager.Instance.SecondsPassedCountChanged -= TimeManager_SecondsPassedCountChanged;
            }

            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.ScoreChanged -= ScoreManager_ScoreChanged;
            }

            if (CollisionHandlingManager.Instance != null)
            {
                CollisionHandlingManager.Instance.TriggerEnter -= CollisionHandlingManager_TriggerEnter;
            }
        }

        private static void StartTheGame()
        {
            GameStateManager.Instance.GameState = GameState.InProgress;
        }

        private void TimeManager_SecondsPassedCountChanged(int secondsPassedCount)
        {
            if (secondsPassedCount == _lossGameSecondsCount)
            {
                GameStateManager.Instance.GameState = GameState.Loss;
            }
        }

        private void ScoreManager_ScoreChanged(int score)
        {
            if (score == _winGameScore)
            {
                GameStateManager.Instance.GameState = GameState.Win;
            }
        }

        private void CollisionHandlingManager_TriggerEnter(IBaseView baseView1, IBaseView baseView2)
        {
            TryHandleExitPenguinCollisionEnter(baseView1, baseView2);
        }

        private void TryHandleExitPenguinCollisionEnter(IBaseView baseView1, IBaseView baseView2)
        {
            var exitView = baseView1 as ExitView;
            var penguinView = baseView2 as PenguinView;

            if (exitView == null ||
                penguinView == null)
            {
                return;
            }

            if (ScoreManager.Instance == null ||
                !ScoreManager.Instance.IsInitialized)
            {
                return;
            }

            ScoreManager.Instance.Score++;
            Destroy(penguinView.gameObject);
        }
    }
}
