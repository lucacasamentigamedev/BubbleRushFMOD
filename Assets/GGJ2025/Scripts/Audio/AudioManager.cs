using FMOD.Studio;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    private static EventInstance currentBackgroundMusic;

    private static readonly Dictionary<string, AudioEvent> soundDictionary = new Dictionary<string, AudioEvent> {
        { "Test", new AudioEvent("event:/Test/Test", AudioCategory.Player) }
    };

    private static readonly Dictionary<AudioCategory, float> volumes = new Dictionary<AudioCategory, float> {
        { AudioCategory.SFX, 1.0f },
        { AudioCategory.UI, 1.0f },
        { AudioCategory.Environment, 1.0f },
        { AudioCategory.Music, 1.0f },
        { AudioCategory.Player, 1.0f }
    };

    public static void SetCategoryVolume(AudioCategory category, float volume) {
        if (volumes.ContainsKey(category)) {
            Debug.Log($"Set volume '{volume}' at '{category}'");
            volumes[category] = Mathf.Clamp01(volume);
        }
    }

    public static void PlayOneShotSound(string soundName) {
        // check if event exists
        if (soundDictionary.TryGetValue(soundName, out AudioEvent audioEvent)) {
            // get volume
            float categoryVolume = volumes.GetValueOrDefault(audioEvent.Category, 1.0f);
            var instance = audioEvent.CreateInstance();
            instance.setVolume(categoryVolume);
            // play sound
            Debug.Log($"Play sound '{soundName}' at volume '{categoryVolume}'");
            instance.start();
            instance.release();
        } else {
            Debug.LogWarning($"Sound '{soundName}' not found in the dictionary");
        }
    }

    public static void PlayBackgroundMusic(string soundPath) {
        // stop actual bg
        if (currentBackgroundMusic.isValid()) {
            currentBackgroundMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        // get event
        if (soundDictionary.TryGetValue(soundPath, out AudioEvent audioEvent)) {
            // get volume
            float categoryVolume = volumes.GetValueOrDefault(audioEvent.Category, 1.0f);
            // play
            currentBackgroundMusic = audioEvent.CreateInstance();
            currentBackgroundMusic.setVolume(categoryVolume);
            currentBackgroundMusic.start();
        }
    }
}