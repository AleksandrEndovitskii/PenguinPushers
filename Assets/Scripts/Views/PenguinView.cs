using Cysharp.Threading.Tasks;
using PenguinPushers.Managers;
using PenguinPushers.Models;

namespace PenguinPushers.Views
{
    public class PenguinView : BaseView<PenguinModel>
    {
        protected override async void Initialize()
        {
            base.Initialize();

            await UniTask.WaitUntil(() => PenguinsManager.Instance != null &&
                                          PenguinsManager.Instance.IsInitialized);

            PenguinsManager.Instance.RegisterInstance(this);
        }

        protected override async void UnInitialize()
        {
            base.UnInitialize();

            await UniTask.WaitUntil(() => PenguinsManager.Instance != null &&
                                          PenguinsManager.Instance.IsInitialized);

            PenguinsManager.Instance.UnRegisterInstance(this);
        }
    }
}
