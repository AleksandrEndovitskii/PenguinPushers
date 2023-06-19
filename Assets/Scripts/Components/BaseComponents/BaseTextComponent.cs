using TMPro;
using UnityEngine;

namespace PenguinPushers.Components.BaseComponents
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BaseTextComponent : BaseComponent
    {
        [SerializeField]
        private string _replaceblePattern = "<#>";
        [SerializeField]
        private string _prefix = "";
        [SerializeField]
        private string _suffix = "";

        protected TextMeshProUGUI _text;
        protected string _initialText;

        protected override void Initialize()
        {
            _text = this.gameObject.GetComponent<TextMeshProUGUI>();
            _initialText = _text.text;
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

        protected void Redraw(string value)
        {
            string newText;

            if (_initialText == null)
            {
                _initialText = string.Empty;
            }

            if (_initialText.Contains(_replaceblePattern))
            {
                newText = _initialText.Replace(_replaceblePattern, value);
            }
            else
            {
                newText = value;
            }

            if (!string.IsNullOrEmpty(_prefix))
            {
                newText = _prefix + newText;
            }
            if (!string.IsNullOrEmpty(_suffix))
            {
                newText = newText + _suffix;
            }

            _text.text = newText;
        }
    }
}
