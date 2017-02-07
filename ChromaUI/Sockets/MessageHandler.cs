using System;
using System.Drawing;
using ChromaUI.Overwatch;

namespace ChromaUI.Sockets
{
    class MessageHandler
    {
        public event KeyboardColorUpdateHandler OnKeyboardColorUpdate;
        public event ChampionUpdateHandler OnChampionUpdate;

        public delegate void KeyboardColorUpdateHandler(Color[,] colors);
        public delegate void ChampionUpdateHandler(Champion champion);

        private enum Messages : byte
        {
            KeyboardCustomEffectType = 1
        }

        public void HandleMessage(byte[] message)
        {
            var cutMessage = new byte[message.Length - 1];
            Buffer.BlockCopy(message, 1, cutMessage, 0, cutMessage.Length);

            switch (message[0])
            {
                case (byte) Messages.KeyboardCustomEffectType:
                    HandleKeyboardCustomEffect(cutMessage);
                    break;
                default:
                    break;
            }
        }

        private void HandleKeyboardCustomEffect(byte[] message)
        {
            var keyboardEffect = new uint[6, 22];
            MultiDemFromBytes(keyboardEffect, message);

            var colors = new Color[6, 22];
            for (var x = 0; x < colors.GetLength(0); x++)
            {
                for (var y = 0; y < colors.GetLength(1); y++)
                {
                    colors[x, y] = ColorFromUint(keyboardEffect[x, y]);
                }
            }
            OnKeyboardColorUpdate?.Invoke(colors);
            CheckForChampionUpdate(colors);
        }

        private void CheckForChampionUpdate(Color[,] colors)
        {
            var keyRow = KeyboardMapping.GetHiByte((int) RZKeys.RZKEY_W);
            var keyColumn = KeyboardMapping.GetLowByte((int) RZKeys.RZKEY_W);

            var colour = colors[keyRow, keyColumn];
            var champ = ChampionColours.GetChampion(colour);
            if (champ.HasValue)
            {
                OnChampionUpdate?.Invoke(champ.Value);
            }
        }

        public static void MultiDemFromBytes<T>(T[,] array, byte[] buffer) where T : struct
        {
            var len = Math.Min(array.GetLength(0) * array.GetLength(1) * System.Runtime.InteropServices.Marshal.SizeOf(typeof(T)), buffer.Length);
            Buffer.BlockCopy(buffer, 0, array, 0, len);
        }

        public static Color ColorFromUint(uint color)
        {
            int r = (byte) color;
            color = color >> 8;
            int g = (byte) color;
            color = color >> 8;
            int b = (byte) color;
            var newColor = Color.FromArgb(r, g, b);
            return newColor;
            //((COLORREF)(((BYTE)(r)|((WORD)((BYTE)(g))<<8))|(((DWORD)(BYTE)(b))<<16)))
        }
    }
}
