using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaLightingInterrupt.RazerDefinitions
{
    public class Generic
    {
        private const uint MAX_ROW = 30;      //!< Maximum rows for custom effects.
        private const uint MAX_COLUMN = 30;   //!< Maximum columns for custom effects.

        //! Chroma generic effects. Note: Not all devices supported the listed effects.

        public enum EFFECT_TYPE
        {
            CHROMA_NONE = 0, //!< No effect.
            CHROMA_WAVE, //!< Wave effect.
            CHROMA_SPECTRUMCYCLING, //!< Spectrum cycling effect.
            CHROMA_BREATHING, //!< Breathing effect.
            CHROMA_BLINKING, //!< Blinking effect.
            CHROMA_REACTIVE, //!< Reactive effect.
            CHROMA_STATIC, //!< Static effect.
            CHROMA_CUSTOM, //!< Custom effect. For mice, please see Mouse::CHROMA_CUSTOM2.
            CHROMA_RESERVED, //!< TODO
            CHROMA_INVALID //!< Invalid effect.
        }

        //! Device info.

        public class DEVICE_INFO_TYPE
        {
            //! Device types.
            enum DeviceType
            {
                DEVICE_KEYBOARD = 1, //!< Keyboard device.
                DEVICE_MOUSE = 2, //!< Mouse device.
                DEVICE_HEADSET = 3, //!< Headset device.
                DEVICE_MOUSEPAD = 4, //!< Mousepad device.
                DEVICE_KEYPAD = 5, //!< Keypad device.
                DEVICE_SYSTEM = 6, //!< System device.
                DEVICE_INVALID          //!< Invalid device.
            }

            uint Connected;            //!< Number of devices connected.
        }

        //! Blinking effect.

        private class BLINKING_EFFECT_TYPE
        {
            uint Size;        //!< Size of the classure. Size = sizeof(BLINKING_EFFECT_TYPE)
            uint Param;        //!< Extra parameters.

            uint Color;     //!< Blinking color
        }

        //! Breathing effect.

        private class BREATHING_EFFECT_TYPE
        {
            uint Size;        //!< Size of ths classure. Size = sizeof(BREATHING_EFFECT_TYPE)
            uint Param;        //!< Extra parameters.

            //! Breathing effect types.
            enum _Type
            {
                ONE_COLOR = 1,  //!< 1 color (Only fill Color1).
                TWO_COLORS,     //!< 2 colors.
                RANDOM_COLORS   //!< Random colors
            }

            uint Color1;    //!< First color.
            uint Color2;    //!< Second color.
        }

        //! Custom effect.

        private class CUSTOM_EFFECT_TYPE
        {
            uint Size;        //!< Size of the classure. Size = sizeof(CUSTOM_EFFECT_TYPE)
            uint Param;        //!< Extra parameters.

            uint[][] Color;
        }

        //! No effect.

        private class NO_EFFECT_TYPE
        {
            uint Size;        //!< Size of the classure. Size = sizeof(NO_EFFECT_TYPE)
            uint Param;        //!< Extra parameters.
        }

        //! Reactive effect.

        private class REACTIVE_EFFECT_TYPE
        {
            uint Size;        //!< Size of the classure. Size = sizeof(REACTIVE_EFFECT_TYPE)
            uint Param;        //!< Extra parameters.

            //! Duration of the effect.
            enum _Duration
            {
                DURATION_SHORT = 1, //!< Short duration.
                DURATION_MEDIUM,    //!< Medium duration.
                DURATION_LONG       //!< Long duration.
            }             //!< The time taken for the effect to fade away.

            uint Color;         //!< Color of the effect.
        }

        //! Spectrum cycling effect.

        private class SPECTRUMCYCLING_EFFECT_TYPE
        {
            uint Size;        //!< Size of the classure. Size = sizeof(SPECTRUMCYCLING_EFFECT_TYPE)
            uint Param;        //!< Extra parameters.
        }

        //! Starlight effect.

        private class STARLIGHT_EFFECT_TYPE
        {
            uint Size;        //!< Size of the classure. Size = sizeof(SPECTRUMCYCLING_EFFECT_TYPE)
            uint Param;        //!< Extra parameters.

            //! Starlight effect types.
            enum _Type
            {
                TWO_COLORS = 1, //!< 2 colors.
                RANDOM_COLORS   //!< Random colors
            }

            uint Color1;    //!< First color.
            uint Color2;    //!< Second color.

            //! Duration of the effect.
            enum _Duration
            {
                DURATION_SHORT = 1, //!< Short duration.
                DURATION_MEDIUM,    //!< Medium duration.
                DURATION_LONG       //!< Long duration.
            }             //!< The time taken for the effect to fade away.

        }

        //! Static effect.

        private class STATIC_EFFECT_TYPE
        {
            uint Size;        //!< Size of the classure. Size = sizeof(STATIC_EFFECT_TYPE)
            uint Param;        //!< Extra parameters.

            uint Color;     //!< Color of the effect.
        }

        //! Wave effect.

        private class WAVE_EFFECT_TYPE
        {
            uint Size;        //!< Size of the classure. Size = sizeof(WAVE_EFFECT_TYPE)
            uint Param;        //!< Extra parameters.

            //! Direction of effect.
            enum _Direction
            {
                DIRECTION_LEFT_TO_RIGHT = 1,    //!< Left to right.
                DIRECTION_RIGHT_TO_LEFT,        //!< Right to left.
                DIRECTION_FRONT_TO_BACK,        //!< Front to back
                DIRECTION_BACK_TO_FRONT         //!< Back top front
            }
        }
    }
}
