using UnityEngine;

namespace Assets.Code.ScriptableObjects
{
    [System.Serializable]
    public class SOSentence
    {
        public string Name;
        [TextArea(3, 10)] public string Sentence;
        public Sprite[] Sprites;
        public AudioClip AudioClip;
    }
}