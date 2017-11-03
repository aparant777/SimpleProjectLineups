using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class STT : MonoBehaviour {

    //public DictationRecognizer dictationRecognizer;


    //private void Start() {
    //    dictationRecognizer = new DictationRecognizer();

    //    dictationRecognizer.Start();
    //}

    //private void Subscribe() {
    //    dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
    //    dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
    //    dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;
    //    dictationRecognizer.DictationError += DictationRecognizer_DictationError;
    //    dictationRecognizer.Start();
    //}

    //private void Unsubscribe() {
    //    dictationRecognizer.DictationResult -= DictationRecognizer_DictationResult;
    //    dictationRecognizer.DictationHypothesis -= DictationRecognizer_DictationHypothesis;
    //    dictationRecognizer.DictationComplete -= DictationRecognizer_DictationComplete;
    //    dictationRecognizer.DictationError -= DictationRecognizer_DictationError;
    //    dictationRecognizer.Dispose();
    //}

    //private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence) {
    //    Debug.Log(text);
    //}

    //private void DictationRecognizer_DictationHypothesis(string text) {
    //    Debug.Log("adad");
    //}

    //private void DictationRecognizer_DictationComplete(DictationCompletionCause cause) {
    //    Debug.Log("adadaddad");
    //}

    //private void DictationRecognizer_DictationError(string error, int hresult) {
    //    Debug.Log("adaadadadadadad");
    //}


    KeywordRecognizer keywordRecognizer;
    // keyword array
    public string[] Keywords_array;

    // Use this for initialization
    void Start() {
        // Change size of array for your requirement
        Keywords_array = new string[2];
        Keywords_array[0] = "testing";
        Keywords_array[1] = "go";

        // instantiate keyword recognizer, pass keyword array in the constructor
        keywordRecognizer = new KeywordRecognizer(Keywords_array);
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        // start keyword recognizer
        keywordRecognizer.Start();
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args) {
        Debug.Log("Keyword: " + args.text + "; Confidence: " + args.confidence + "; Start Time: " + args.phraseStartTime + "; Duration: " + args.phraseDuration);
        // write your own logic
    }
}
    