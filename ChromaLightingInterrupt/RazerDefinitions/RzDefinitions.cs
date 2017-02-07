using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChromaLightingInterrupt.RazerDefinitions;

namespace ChromaLightingInterrupt
{
    class RzDefinitions
    {
        /*//! Headsets
        namespace Headset
        {
            //! Maximum number of LEDs
            const uint MAX_LEDS = 5;

            //! Chroma headset effect types
            enum EFFECT_TYPE
            {
                CHROMA_NONE = 0,            //!< No effect.
                CHROMA_STATIC,              //!< Static effect.
                CHROMA_BREATHING,           //!< Breathing effect.
                CHROMA_SPECTRUMCYCLING,     //!< Spectrum cycling effect.
                CHROMA_CUSTOM,              //!< Custom effects.
                CHROMA_INVALID              //!< Invalid effect.
            }
            EFFECT_TYPE;

                //! Static effect type
                class STATIC_EFFECT_TYPE
            {
                uint Color;             //!< Color of the effect.
            }
            STATIC_EFFECT_TYPE;

                //! Breathing effect type.
                class BREATHING_EFFECT_TYPE
            {
                uint Color;             //!< Color.
            }
            BREATHING_EFFECT_TYPE;

                //! Custom effect type.
                class CUSTOM_EFFECT_TYPE
            {
                RZCOLOR Color[MAX_LEDS];    //!< Array of colors.
            }
            CUSTOM_EFFECT_TYPE;
            }

        //! Mousepads
        namespace Mousepad
        {
            //! Maximum number of LEDs
            const uint MAX_LEDS = 15;

            //! Chroma mousepad effect types
            enum EFFECT_TYPE
            {
                CHROMA_NONE = 0,            //!< No effect.
                CHROMA_BREATHING,           //!< Breathing effect.
                CHROMA_CUSTOM,              //!< Custom effect.
                CHROMA_SPECTRUMCYCLING,     //!< Spectrum cycling effect.
                CHROMA_STATIC,              //!< Static effect.
                CHROMA_WAVE,                //!< Wave effect.
                CHROMA_INVALID              //!< Invalid effect.
            }
            EFFECT_TYPE;

                // Chroma mousepad effects
                //! Breathing effect type.
                class BREATHING_EFFECT_TYPE
            {
                //! Breathing effects.
                enum Type
                {
                    TWO_COLORS = 1,     //!< 2 colors
                    RANDOM_COLORS,      //!< Random colors
                    INVALID
                }
                Type;
                    uint Color1;    //!< First color.
                uint Color2;    //!< Second color.
            }
            BREATHING_EFFECT_TYPE;

                //! Custom effect type.
                class CUSTOM_EFFECT_TYPE
            {
                RZCOLOR Color[MAX_LEDS];    //!< An array of colors for all the sides of the mousepad. First LED starts from top-right corner.
                                            //!< LED 0-4 right side, 5-9 bottom side, 10-14 left side.
            }
            CUSTOM_EFFECT_TYPE;

                //! Static effect type
                class STATIC_EFFECT_TYPE
            {
                uint Color;     //!< Color of the effect
            }
            STATIC_EFFECT_TYPE;

                //! Wave effect type
                class WAVE_EFFECT_TYPE
            {
                //! Direction of the wave effect.
                enum Direction
                {
                    DIRECTION_NONE = 0,           //!< No direction.
                    DIRECTION_LEFT_TO_RIGHT,    //!< Left to right.
                    DIRECTION_RIGHT_TO_LEFT,    //!< Right to left.
                    DIRECTION_INVALID           //!< Invalid direction.
                }
                Direction;                    //!< Direction of the wave.
                }
            WAVE_EFFECT_TYPE;
            }

        //! Keypads
        namespace Keypad
        {
            //! Maximum number of rows.
            const uint MAX_ROW = 4;

            //! Maximum number of columns.
            const uint MAX_COLUMN = 5;

            //! Total number of keys.
            const uint MAX_KEYS = MAX_ROW * MAX_COLUMN;

            //! Chroma keypad effect types
            enum EFFECT_TYPE
            {
                CHROMA_NONE = 0,            //!< No effect.
                CHROMA_BREATHING,           //!< Breathing effect.
                CHROMA_CUSTOM,              //!< Custom effect.
                CHROMA_REACTIVE,            //!< Reactive effect.
                CHROMA_SPECTRUMCYCLING,     //!< Spectrum cycling effect.
                CHROMA_STATIC,              //!< Static effect.
                CHROMA_WAVE,                //!< Wave effect.
                CHROMA_INVALID              //!< Invalid effect.
            }
            EFFECT_TYPE;

                // Chroma keypad effects
                //! Breathing effect type.
                class BREATHING_EFFECT_TYPE
            {
                //! Breathing effects.
                enum Type
                {
                    TWO_COLORS = 1,     //!< 2 colors
                    RANDOM_COLORS,      //!< Random colors
                    INVALID             //!< Invalid type
                }
                Type;
                    uint Color1;    //!< First color.
                uint Color2;    //!< Second color.
            }
            BREATHING_EFFECT_TYPE;

                //! Custom effect type
                class CUSTOM_EFFECT_TYPE
            {
                RZCOLOR Color[MAX_ROW][MAX_COLUMN]; //!< Custom effect.
                                                        //!< For Razer Tartarus Chroma only Color[0] is valid. Use index '0' to change the keypad color.
                }
            CUSTOM_EFFECT_TYPE;

                //! Reactive effect type
                class REACTIVE_EFFECT_TYPE
            {
                //! Duration of the effect.
                enum Duration
                {
                    DURATION_NONE = 0,    //!< No duration.
                    DURATION_SHORT,     //!< Short duration.
                    DURATION_MEDIUM,    //!< Medium duration.
                    DURATION_LONG,      //!< Long duration.
                    DURATION_INVALID    //!< Invalid duration.
                }
                Duration;             //!< The time taken for the effect to fade away.

                    uint Color;         //!< Color of the effect
            }
            REACTIVE_EFFECT_TYPE;

                //! Static effect type
                class STATIC_EFFECT_TYPE
            {
                RZCOLOR Color;  //!< Color of the effect.
            }
            STATIC_EFFECT_TYPE;

                //! Wave effect type
                class WAVE_EFFECT_TYPE
            {
                //! Direction of the wave effect.
                enum Direction
                {
                    DIRECTION_NONE = 0,           //!< No direction.
                    DIRECTION_LEFT_TO_RIGHT,    //!< Left to right.
                    DIRECTION_RIGHT_TO_LEFT,    //!< Right to left.
                    DIRECTION_INVALID           //!< Invalid direction.
                }
                Direction;                    //!< Direction of the wave.
                }
            WAVE_EFFECT_TYPE;
            }*/
    }
}
