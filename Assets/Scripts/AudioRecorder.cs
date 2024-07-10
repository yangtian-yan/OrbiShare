using UnityEngine;
using System.IO;

public class AudioRecorder : MonoBehaviour
{
    public AudioSource audioSource;  // Assign this in the editor
    private AudioClip recordedClip;
    private string filePath;  // Initialize in Start or Awake

    void Awake() {
        // Initialize filePath in Awake to ensure it's set before any method uses it
        filePath = Application.persistentDataPath + "/yourfilename.wav";
    }

    public void StartRecording()
    {
        // Start recording from the microphone
        recordedClip = Microphone.Start(null, false, 10, 44100);
    }

    public void StopRecordingAndSave()
    {
        // Stop the microphone and save the clip
        Microphone.End(null);
        SaveAudioClipToFile(recordedClip, filePath);
    }

    public void PlayRecordedAudio()
    {
        // Load the recorded audio and play it
        byte[] wavData = File.ReadAllBytes(filePath);
        AudioClip clip = LoadWAVFromBytes(wavData);
        audioSource.clip = clip;
        audioSource.Play();
    }

    private void SaveAudioClipToFile(AudioClip clip, string path)
    {
        var samples = new float[clip.samples * clip.channels];
        clip.GetData(samples, 0);
        byte[] wavFile = ConvertToWAV(samples);
        File.WriteAllBytes(path, wavFile);
    }

    private byte[] ConvertToWAV(float[] samples)
    {
        // Convert the audio samples to WAV byte format
        // Placeholder function - You'll need to replace this with actual WAV conversion logic
        return new byte[samples.Length * 2];  // Simplified example, not a real conversion
    }

    private AudioClip LoadWAVFromBytes(byte[] wavData)
    {
        // Load AudioClip from WAV byte array
        // Placeholder function - You'll need to replace this with actual WAV loading logic
        return AudioClip.Create("recordedClip", wavData.Length, 1, 44100, false);
    }
}
