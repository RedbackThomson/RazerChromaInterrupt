using System;
using System.Runtime.InteropServices;
using ChromaLightingInterrupt.RazerDefinitions;
using RGiesecke.DllExport;

namespace ChromaLightingInterrupt
{
    public class RazerHooks
    {
        private static SocketClient client;

        [DllExport("Init", CallingConvention.Cdecl)]
        public static long Init()
        {
            return 0;
        }

        [DllExport("Uninit", CallingConvention.Cdecl)]
        public static long Uninit()
        {
            return 0;
        }

        [DllExport("CreateEffect", CallingConvention.Cdecl)]
        public static long CreateEffect(Guid DeviceId, Generic.EFFECT_TYPE Effect, IntPtr pParam, IntPtr pEffectId)
        {
            return 0;
        }

        [DllExport("CreateKeyboardEffect", CallingConvention.Cdecl)]
        public static long CreateKeyboardEffect(Keyboard.EFFECT_TYPE Effect, IntPtr pParam, IntPtr pEffectId)
        {
            if (pParam == IntPtr.Zero) return 0;

            var customEffectType = ReadUsingMarshalPtr<Keyboard.CUSTOM_EFFECT_TYPE>(pParam);

            SocketClient.SendKeyEffect(Effect, customEffectType);
            return 0;
        }

        [DllExport("CreateHeadsetEffect", CallingConvention.Cdecl)]
        public static long CreateHeadsetEffect(Generic.EFFECT_TYPE Effect, IntPtr pParam, IntPtr pEffectId)
        {
            return 0;
        }

        [DllExport("CreateMousepadEffect", CallingConvention.Cdecl)]
        public static long CreateMousepadEffect(Generic.EFFECT_TYPE Effect, IntPtr pParam, IntPtr pEffectId)
        {
            return 0;
        }

        [DllExport("CreateMouseEffect", CallingConvention.Cdecl)]
        public static long CreateMouseEffect(Generic.EFFECT_TYPE Effect, IntPtr pParam, Guid pEffectId)
        {
            return 0;
        }

        [DllExport("CreateKeypadEffect", CallingConvention.Cdecl)]
        public static long CreateKeypadEffect(Generic.EFFECT_TYPE Effect, IntPtr pParam, Guid pEffectId)
        {
            return 0;
        }

        [DllExport("SetEffect", CallingConvention.Cdecl)]
        public static long SetEffect(Guid pEffectId)
        {
            return 0;
        }

        [DllExport("DeleteEffect", CallingConvention.Cdecl)]
        public static long DeleteEffect(Guid pEffectId)
        {
            return 0;
        }

        [DllExport("RegisterEventNotification", CallingConvention.Cdecl)]
        public static long RegisterEventNotification(IntPtr hWnd)
        {
            return 0;
        }

        [DllExport("UnregisterEventNotification", CallingConvention.Cdecl)]
        public static long UnregisterEventNotification()
        {
            return 0;
        }

        [DllExport("QueryDevice", CallingConvention.Cdecl)]
        public static long QueryDevice(Guid DeviceId, Generic.DEVICE_INFO_TYPE DeviceInfo)
        {
            return 0;
        }

        public static T ReadUsingMarshalPtr<T>(IntPtr ptr) where T : struct
        {
            return (T) Marshal.PtrToStructure(ptr, typeof(T));
        }
    }
}
