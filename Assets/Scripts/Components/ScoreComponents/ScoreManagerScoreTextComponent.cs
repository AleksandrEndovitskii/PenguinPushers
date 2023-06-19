using Cysharp.Threading.Tasks;
using PenguinPushers.Components.BaseComponents;
using PenguinPushers.Managers;

namespace PenguinPushers.Components.ScoreComponents
{
    public class ScoreManagerScoreTextComponent : BaseTextComponent
    {
        protected override async void Subscribe()
        {
            base.Subscribe();

            await UniTask.WaitUntil(() => ScoreManager.Instance != null &&
                                          ScoreManager.Instance.IsInitialized);

            ScoreManager.Instance.ScoreChanged += ScoreManager_ScoreChanged;
            ScoreManager_ScoreChanged(ScoreManager.Instance.Score);
        }

        protected override void UnSubscribe()
        {
            base.UnSubscribe();

            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.ScoreChanged -= ScoreManager_ScoreChanged;
            }
        }

        private void ScoreManager_ScoreChanged(int score)
        {
            Redraw(score.ToString());
        }
    }
}
