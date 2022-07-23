using UnityEngine;
using UnityEngine.Audio;

namespace Runtime.UI
{
    public class SoundController : MonoBehaviour
    {
        private const string MasterVolume = "MasterVolume";
        private const string MusicVolume = "MusicVolume";
        private const string SoundVolume = "SoundVolume";
        [SerializeField] private float multiplier = 80f;

        [SerializeField] private AudioMixerGroup master;
        [SerializeField] private AudioMixerGroup music;
        [SerializeField] private AudioMixerGroup soundFX;

        [SerializeField] private FloatVariable masterValue;
        [SerializeField] private FloatVariable musicValue;
        [SerializeField] private FloatVariable soundFXValue;

        private void Start()
        {
            masterValue.OnChange += ChangeMaster;
            musicValue.OnChange += ChangeMusic;
            soundFXValue.OnChange += ChangeSoundFX;

            master.audioMixer.SetFloat(MasterVolume, ValueToDB(masterValue.Value));
            music.audioMixer.SetFloat(MusicVolume, ValueToDB(musicValue.Value));
            soundFX.audioMixer.SetFloat(SoundVolume, ValueToDB(soundFXValue.Value));
        }

        private float ValueToDB(float value) => -multiplier * (1 - value);

        private void ChangeMaster(float value)
        {
            master.audioMixer.SetFloat(MasterVolume, ValueToDB(value));
        }

        private void ChangeMusic(float value)
        {
            music.audioMixer.SetFloat(MusicVolume, ValueToDB(value));
        }

        private void ChangeSoundFX(float value)
        {
            soundFX.audioMixer.SetFloat(SoundVolume, ValueToDB(value));
        }
    }
}