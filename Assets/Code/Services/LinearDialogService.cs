using System.Collections.Generic;
using Assets.Code.ScriptableObjects;
using Code.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Services
{
    public class LinearDialogService : ILinearDialogService
    {
        private readonly ITextWritingService _textWritingService;
        private readonly Image _image;
        private Queue<SOSentence> _sentences;

        public LinearDialogService(ITextWritingService textWritingService, Image image)
        {
            _textWritingService = textWritingService;
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

        public void TryShowNextSentence()
        {
            if (_textWritingService.TrySkipTyping())
            {
                
            }
            else
            {
                NextSentences();
            }
        }


        private void NextSentences()
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
           // _textWritingService.TypeText(sentence.Sentence);
            _image.sprite = sentence.Sprites[0];
            Debug.Log(sentence);
        }
    }
}