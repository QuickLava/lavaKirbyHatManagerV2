﻿using System;

namespace BrawlLib.Internal.Audio
{
    public abstract class AudioDevice
    {
        internal string _description, _driver;

        public string Description => _description;
        public string Driver => _driver;

        public static AudioDevice[] PlaybackDevices
        {
            get
            {
                switch (Environment.OSVersion.Platform)
                {
                    case PlatformID.Win32NT: return wAudioDevice.PlaybackDevices;
                }

                return null;
            }
        }

        public static AudioDevice DefaultPlaybackDevice
        {
            get
            {
                switch (Environment.OSVersion.Platform)
                {
                    case PlatformID.Win32NT: return wAudioDevice.DefaultPlaybackDevice;
                }

                return null;
            }
        }

        public static AudioDevice DefaultVoicePlaybackDevice
        {
            get
            {
                switch (Environment.OSVersion.Platform)
                {
                    case PlatformID.Win32NT: return wAudioDevice.DefaultVoicePlaybackDevice;
                }

                return null;
            }
        }
    }
}