using System.Collections.Generic;
using Assets.Code.ScriptableObjects;
using Code.Services.Interfaces;
using TMPro;
using UnityEngine;

namespace Code.Services
{
    public class LinearDialogService : ILinearDialogService
    {
        private readonly TMP_Text _text;
        private Queue<SOSentence> _sentences;

        public LinearDialogService(TMP_Text text)
        {
            _text = text;
        }
        
        public void StartDialog(SOLinerDialogue soLinerDialogue)
        {
            _sentences = new Queue<SOSentence>();

            foreach (SOSentence sentence in soLinerDialogue.Sentences)
            {
                _sentences.Enqueue(sentence);
            }
        }

        public void NextSentences()
        {
            if (TryGetNextSentence(out SOSentence sentence))
                UpdateVisual(sentence);
            else
                EndDialog();
        }

        public void EndDialog()
        {
            Debug.Log("DialogEnd");
        }

        private bool TryGetNextSentence(out SOSentence sentence)
        {
            if (_sentences.Count != 0)
            {
                sentence = _sentences.Dequeue();
                return true;
            }
            
            sentence = null;
            return false;
        }

        private void UpdateVisual(SOSentence sentence)
        {
            _text.text = sentence.Sentence;
            Debug.Log(sentence);
        }
    }
}