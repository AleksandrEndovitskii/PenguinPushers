using Cysharp.Threading.Tasks;
using PenguinPushers.Views;

namespace PenguinPushers.Managers
{
    public class GameplayManager : BaseManager<GameplayManager>
    {
        protected override void Initialize()
        {
            IsInitialized = true;
        }

        protected override void UnInitialize()
        {
        }

        protected override async void Subscribe()
        {
            await UniTask.WaitUntil(() => CollisionHandlingManager.Instance != null &&
                                          CollisionHandlingManager.Instance.IsInitialized);

            CollisionHandlingManager.Instance.TriggerEnter += CollisionHandlingManager_TriggerEnter;
        }

        protected override void UnSubscribe()
        {
            if (CollisionHandlingManager.Instance != null)
            {
                CollisionHandlingManager.Instance.TriggerEnter -= CollisionHandlingManager_TriggerEnter;
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
