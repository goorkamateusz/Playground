using Assets.Goo.Tools.UnityHelpers;
using UnityEngine;

namespace Assets.Goo.SceneObjects
{
    public class MessageBox : SceneInteractiveElement
    {
        [SerializeField, TextArea] private string _message;

        public override void ColiderEnter(ICharacterInteraction character)
        {
            if (character.DisplayUI && UiReferenceManager.Initialized)
                UiReferenceManager.Instance.MessagePopup.Null()?.Open(_message, character);
        }

        public override void ColiderExit(ICharacterInteraction character)
        {
        }

        public override void OnKeyDown(ICharacterInteraction character)
        {
        }

        public override void OnKeyUp(ICharacterInteraction character)
        {
        }
    }
}