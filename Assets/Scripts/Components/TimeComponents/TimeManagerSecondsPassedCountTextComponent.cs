using Cysharp.Threading.Tasks;
using PenguinPushers.Components.BaseComponents;
using PenguinPushers.Managers;

namespace PenguinPushers.Components.TimeComponents
{
    public class TimeManagerSecondsPassedCountTextComponent : BaseTextComponent
    {
        protected override async void Subscribe()
        {
            base.Subscribe();

            await UniTask.WaitUntil(() => TimeManager.Instance != null &&
                                          TimeManager.Instance.IsInitialized);

            TimeManager.Instance.SecondsPassedCountChanged += TimeManager_SecondsPassedCountChanged;
            TimeManager_SecondsPassedCountChanged(TimeManager.Instance.SecondsPassedCount);
        }

        protected override void UnSubscribe()
        {
            base.UnSubscribe();

            if (TimeManager.Instance != null)
            {
                TimeManager.Instance.SecondsPassedCountChanged -= TimeManager_SecondsPassedCountChanged;
            }
        }

        private void TimeManager_SecondsPassedCountChanged(int secondsPassedCount)
        {
            Redraw(secondsPassedCount.ToString());
        }
    }
}
