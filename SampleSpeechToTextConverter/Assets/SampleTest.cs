using UnityEngine;
using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;
using IBM.Watson.DeveloperCloud.Logging;
using System.Collections;
using IBM.Watson.DeveloperCloud.Utilities;
using System.IO;
using System.Collections.Generic;

public class SampleTest : MonoBehaviour {
     
    private string username = "e7ae547a-2154-43d6-9e15-338e8a527ebc";
    private string url = "https://stream.watsonplatform.net/speech-to-text/api";
    private string password = "ZWfWyl5zI2Fy";

    public AudioSource _recording;
    private AudioClip _audioClip;
    private bool _recognizeTested = false;
    public SpeechToText _speechToText;
    public string _wavFilePath;

    void Start() {
        Credentials credentials = new Credentials(username, password, url);
        _speechToText = new SpeechToText(credentials);


        _speechToText.StartListening(HandleOnRecognize);
        _recording = GetComponent<AudioSource>();
        _recording.clip = Microphone.Start("Built-in Microphone", true, 20, 44100);

        //_wavFilePath = Application.dataPath + "/Watson/Examples/ServiceExamples/TestData/Recording.wav";
        //_audioClip = WaveFile.ParseWAV("testClip", File.ReadAllBytes(_wavFilePath));


        //_speechToText.OnListen(_recording.clip);

        //Runnable.Run(KeepHearing());
    }

    public IEnumerator KeepHearing() {
        _speechToText.Recognize(_audioClip, HandleOnRecognize);
        while (!_recognizeTested)
            yield return null;
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            //_recording.clip = _audioClip;
            Microphone.End(null);
            _recording.Play();
            //_audioClip.
        }
    }

    private void HandleOnRecognize(SpeechRecognitionEvent result) {
        Debug.Log(result.ToString());
        if (result != null && result.results.Length > 0) {
            foreach (var res in result.results) {
                foreach (var alt in res.alternatives) {
                    string text = alt.transcript;
                    Log.Debug("ExampleSpeechToText", string.Format("{0} ({1}, {2:0.00})\n", text, res.final ? "Final" : "Interim", alt.confidence));

                    if (res.final)
                        _recognizeTested = true;
                }

                if (res.keywords_result != null && res.keywords_result.keyword != null) {
                    foreach (var keyword in res.keywords_result.keyword) {
                        Log.Debug("ExampleSpeechToText", "keyword: {0}, confidence: {1}, start time: {2}, end time: {3}", keyword.normalized_text, keyword.confidence, keyword.start_time, keyword.end_time);
                    }
                }
            }
        }
    }
}
