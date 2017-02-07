using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChromaLightingInterrupt.RazerDefinitions;

namespace ChromaLightingInterrupt
{
    public class SocketClient
    {
        private enum Messages : byte
        {
            KeyboardCustomEffectType = 1
        }

        public static void SendKeyEffect(Keyboard.EFFECT_TYPE effectType, Keyboard.CUSTOM_EFFECT_TYPE effect)
        {
            var effectSize = effect.Color.Length*sizeof(uint);
            var result = new byte[effectSize + 1];
            //Write header byte
            result[0] = (byte) Messages.KeyboardCustomEffectType;
            Buffer.BlockCopy(effect.Color, 0, result, 1, effectSize);

            SendMessage(result);
        }

        private static void SendMessage(byte[] buffer)
        {
            var client = new NamedPipeClientStream("ChromOverwatch");
            client.Connect();

            client.Write(buffer, 0, buffer.Length);
            client.Flush();
            client.WaitForPipeDrain();

            client.Close();
        }
    }
}
