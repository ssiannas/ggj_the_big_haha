using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    public class AudioManager : Singleton<AudioManager>
    {
       public List<Sound> sounds;

       private new void Awake()
       {
           base.Awake();
           foreach (var s in sounds)
           {
              s.source = gameObject.AddComponent<AudioSource>();
              s.source.clip = s.clip;
              s.source.volume = s.volume;
              s.source.pitch = s.pitch;
              s.source.loop = s.loop;
           }
       }
       
       public void Play(string soundName)
       {
           var s = sounds.Find(sound => sound.soundName == soundName);
           s.source.Play();
       }
       
       public void Stop(string soundName)
       {
           var s = sounds.Find(sound => sound.soundName == soundName);
           s.source.Stop();
       }

       public bool IsPlaying(string soundName)
       {
           var s = sounds.Find(sound => sound.soundName == soundName);
           return s.source.isPlaying;
       }
    }
}
