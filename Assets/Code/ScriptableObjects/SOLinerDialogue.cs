using UnityEngine;

namespace Assets.Code.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New LinerDialogue", menuName = "LinerDialogue")]
    public class SOLinerDialogue : ScriptableObject
    {
        public SOSentence[] Sentences;
    }
}