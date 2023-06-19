using System.Collections.Generic;
using System.Linq;
using PenguinPushers.Extensions;
using PenguinPushers.Views;
using UnityEngine;

namespace PenguinPushers.Components.MovementComponents
{
    public class MoveFromCharactersComponent : MoveFromTargetComponent
    {
        private List<CharacterView> _characterViews;

        protected override void Initialize()
        {
            base.Initialize();

            _characterViews = FindObjectsByType<CharacterView>(FindObjectsSortMode.None).ToList();
        }

        protected override void MoveFromTargetsIfTargetIsTooClose(List<Transform> targets, float moveAwayDistance)
        {
            var closestCharacterView = this.gameObject.transform.GetTransformsInRange(_characterViews, _moveAwayDistance);
            var targetTransforms = closestCharacterView.Select(characterView => characterView.transform).ToList();

            Targets = targetTransforms;

            base.MoveFromTargetsIfTargetIsTooClose(Targets, _moveAwayDistance);
        }
    }
}
