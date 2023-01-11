using System;
using System.Collections;
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
        private readonly Bootstrap _bootstrap;
        private Queue<SOSentence> _sentences;
        private State _state = State.Completed;

        private enum State
        {
            Playing,
            Completed
        }

        public LinearDialogService(TMP_Text text, Image image, Bootstrap bootstrap)
        {
            _text = text;
            _image = image;
            _bootstrap = bootstrap;
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
            _bootstrap.StartCoroutine(TypeText(sentence.Sentence));
            _image.sprite = sentence.Sprites[0];
            Debug.Log(sentence);
        }

        private IEnumerator TypeText(string text)
        {
            _state = State.Playing;
            _text.text = String.Empty;
            int wordIndex = 0;
            
            while (_state != State.Completed)
            {
                _text.text += text[wordIndex];
                
                yield return new WaitForSeconds(0.05f);
                
                if (++wordIndex >= text.Length)
                {
                    _state = State.Completed;
                }
            }
        }
    }
}