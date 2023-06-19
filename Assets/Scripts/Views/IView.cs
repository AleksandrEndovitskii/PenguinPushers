using PenguinPushers.Common;

namespace PenguinPushers.Views
{
    public interface IView<T> : IBaseView where T : IModel
    {
    }
}
