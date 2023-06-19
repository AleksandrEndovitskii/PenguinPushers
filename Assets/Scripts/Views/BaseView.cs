using PenguinPushers.Common;
using PenguinPushers.Components.BaseComponents;

namespace PenguinPushers.Views
{
    public class BaseView<T> : BaseComponent, IView<T> where T : IModel
    {
        protected override void Initialize()
        {
        }

        protected override void UnInitialize()
        {
        }

        protected override void Subscribe()
        {
        }

        protected override void UnSubscribe()
        {
        }
    }
}
