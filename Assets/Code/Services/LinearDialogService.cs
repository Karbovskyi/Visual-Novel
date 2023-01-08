using System.Collections.Generic;
using Assets.Code.ScriptableObjects;
using Code.Services.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Services
{
    public class LinearDialogService : ILinearDialogService
    {
        private readonly TMP_Text _text;
        private readonly Image _image;
        private Queue<SOSentence> _sentences;

        public LinearDialogService(TMP_Text text, Image image)
        {
            _text = text;
            _image = image;
        }
        
        public void StartDialog(SOLinerDialogue soLinerDialogue)
        {
            _sentences = new Queue<SOSentence>();

            foreach (SOSentence sentence in soLinerDialogue.Sentences)
            {
                _sentences.Enqueue(sentence);
            }
            
            NextSentences();
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
            _image.sprite = sentence.Sprites[0];
            Debug.Log(sentence);
        }
    }
}