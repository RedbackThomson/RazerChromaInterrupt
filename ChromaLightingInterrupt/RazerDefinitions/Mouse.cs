using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaLightingInterrupt.RazerDefinitions
{
    class Mouse
    {
        //! Maximum number of custom LEDs (old definition to maintain backward compatibility).
        const uint MAX_LEDS = 30;

        //! Mice LED layout (old definition to maintain backward compatibility).
        uint[] RZLED_LAYOUT;

        //! Maximum number of rows of the virtual grid.
        const uint MAX_ROW = 9;

        //! Maximum number of columns of the virtual grid.
        const uint MAX_COLUMN = 7;

        //! Maximum number of LEDs of the virtual grid.
        const uint MAX_LEDS2 = MAX_ROW * MAX_COLUMN;

        //! Mice LED virtual grid layout.
        uint[][] RZLED_LAYOUT2;

        //! Mouse LED Id defintion (old definition to maintain backward compatibility).
        enum RZLED
        {
            RZLED_NONE = 0,    //!< No LED.
            RZLED_SCROLLWHEEL = 1,    //!< Scroll Wheel LED.
            RZLED_LOGO = 2,    //!< Logo LED.
            RZLED_BACKLIGHT = 3,    //!< Backlight or numpad.
            RZLED_SIDE_STRIP1 = 4,    //!< Side strip LED 1. (For Mamba TE, starts from top left hand)
            RZLED_SIDE_STRIP2 = 5,    //!< Side strip LED 2. (For Mamba TE)
            RZLED_SIDE_STRIP3 = 6,    //!< Side strip LED 3. (For Mamba TE)
            RZLED_SIDE_STRIP4 = 7,    //!< Side strip LED 4. (For Mamba TE)
            RZLED_SIDE_STRIP5 = 8,    //!< Side strip LED 5. (For Mamba TE)
            RZLED_SIDE_STRIP6 = 9,    //!< Side strip LED 6. (For Mamba TE)
            RZLED_SIDE_STRIP7 = 10,   //!< Side strip LED 7. (For Mamba TE)
            RZLED_SIDE_STRIP8 = 11,   //!< Side strip LED 8. (For Mamba TE)
            RZLED_SIDE_STRIP9 = 12,   //!< Side strip LED 9. (For Mamba TE)
            RZLED_SIDE_STRIP10 = 13,   //!< Side strip LED 10. (For Mamba TE)
            RZLED_SIDE_STRIP11 = 14,   //!< Side strip LED 11. (For Mamba TE)
            RZLED_SIDE_STRIP12 = 15,   //!< Side strip LED 12. (For Mamba TE)
            RZLED_SIDE_STRIP13 = 16,   //!< Side strip LED 13. (For Mamba TE)
            RZLED_SIDE_STRIP14 = 17,   //!< Side strip LED 14. (For Mamba TE)
            RZLED_ALL = 0xFFFF
        }

        //! Mouse LED Id defintion for the virtual grid.
        enum RZLED2
        {
            RZLED2_SCROLLWHEEL = 0x0203,  //!< Scroll Wheel LED.
            RZLED2_LOGO = 0x0703,  //!< Logo LED.
            RZLED2_BACKLIGHT = 0x0403,  //!< Backlight LED.
            RZLED2_LEFT_SIDE1 = 0x0100,  //!< Left LED 1.
            RZLED2_LEFT_SIDE2 = 0x0200,  //!< Left LED 2.
            RZLED2_LEFT_SIDE3 = 0x0300,  //!< Left LED 3.
            RZLED2_LEFT_SIDE4 = 0x0400,  //!< Left LED 4.
            RZLED2_LEFT_SIDE5 = 0x0500,  //!< Left LED 5.
            RZLED2_LEFT_SIDE6 = 0x0600,  //!< Left LED 6.
            RZLED2_LEFT_SIDE7 = 0x0700,  //!< Left LED 7.
            RZLED2_BOTTOM1 = 0x0801,  //!< Bottom LED 1.
            RZLED2_BOTTOM2 = 0x0802,  //!< Bottom LED 2.
            RZLED2_BOTTOM3 = 0x0803,  //!< Bottom LED 3.
            RZLED2_BOTTOM4 = 0x0804,  //!< Bottom LED 4.
            RZLED2_BOTTOM5 = 0x0805,  //!< Bottom LED 5.
            RZLED2_RIGHT_SIDE1 = 0x0106,  //!< Right LED 1.
            RZLED2_RIGHT_SIDE2 = 0x0206,  //!< Right LED 2.
            RZLED2_RIGHT_SIDE3 = 0x0306,  //!< Right LED 3.
            RZLED2_RIGHT_SIDE4 = 0x0406,  //!< Right LED 4.
            RZLED2_RIGHT_SIDE5 = 0x0506,  //!< Right LED 5.
            RZLED2_RIGHT_SIDE6 = 0x0606,  //!< Right LED 6.
            RZLED2_RIGHT_SIDE7 = 0x0706   //!< Right LED 7.
        }

        //! Chroma mouse effect types
        enum EFFECT_TYPE
        {
            CHROMA_NONE = 0,            //!< No effect.
            CHROMA_BLINKING,            //!< Blinking effect.
            CHROMA_BREATHING,           //!< Breathing effect.
            CHROMA_CUSTOM,              //!< Custom effect (old definition to maintain backward compatibility).
            CHROMA_REACTIVE,            //!< Reactive effect.
            CHROMA_SPECTRUMCYCLING,     //!< Spectrum cycling effect.
            CHROMA_STATIC,              //!< Static effect.
            CHROMA_WAVE,                //!< Wave effect.
            CHROMA_CUSTOM2,             //!< Custom effects using a virtual grid.
            CHROMA_INVALID              //!< Invalid effect.
        }

        //! Static effect type
        class STATIC_EFFECT_TYPE
        {
            RZLED LEDId;        //!< LED Id
            uint Color;     //!< Color of the effect.
        }

        //! Blinking effect type.
        class BLINKING_EFFECT_TYPE
        {
            RZLED LEDId;        //!< LED Id
            uint Color;     //!< Color.
        }

        //! Breathing effect.
        class BREATHING_EFFECT_TYPE
        {
            RZLED LEDId;        //!< LED Id

            //! Breathing type.
            enum Type
            {
                ONE_COLOR = 1,  //!< 1 color (Only fill Color1).
                TWO_COLORS,     //!< 2 colors.
                RANDOM_COLORS,  //!< Random colors
                INVALID         //!< Invalid type
            }

            uint Color1;    //!< First color.
            uint Color2;    //!< Second color.
        }

        //! Custom effect.
        class CUSTOM_EFFECT_TYPE
        {
            uint[] Color; //!< Array of colors.
        }

        //! Custom effect using virtual grid. 
        //! Indexes of the LED are defined in RZLED2.i.e. Row = HIBYTE(RZLED2_SCROLLWHEEL), Column = LOBYTE(RZLED2_SCROLLWHEEL)
        class CUSTOM_EFFECT_TYPE2
        {
            uint[][] Color; //!< Array of colors.
        }

        //! Reactive effect.
        class REACTIVE_EFFECT_TYPE
        {
            RZLED LEDId;        //!< LED Id

            //! Duration of the effect.
            enum Duration
            {
                DURATION_NONE = 0,    //!< No duration.
                DURATION_SHORT,     //!< Short duration.
                DURATION_MEDIUM,    //!< Medium duration.
                DURATION_LONG       //!< Long duration.
            }

            uint Color;          //!< Color of the effect.
        }

        //! No effect.
        class NO_EFFECT_TYPE
        {
            RZLED LEDId;        //!< LED Id
        }

        //! Spectrum cycling.
        class SPECTRUMCYCLING_EFFECT_TYPE
        {
            RZLED LEDId;            //!< LED id.
        }

        //! Wave effect.
        class WAVE_EFFECT_TYPE
        {
            //! Direction of the wave effect.
            enum Direction
            {
                FRONT_TO_BACK,      //!< Front to back
                BACK_TO_FRONT       //!< Back to front
            }
        }
    }
}
