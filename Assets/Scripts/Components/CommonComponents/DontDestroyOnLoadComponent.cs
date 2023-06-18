using PenguinPushers.Components.BaseComponents;

namespace PenguinPushers.Components.CommonComponents
{
    public class DontDestroyOnLoadComponent : BaseComponent
    {
        protected override void Initialize()
        {
            DontDestroyOnLoad(gameObject);
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
