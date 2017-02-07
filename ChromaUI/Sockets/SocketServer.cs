using System;
using System.IO.Pipes;

namespace ChromaUI.Sockets
{
    public class SocketServer
    {
        public event ClientDisconnectedHandler OnClientDisconnected;
        public event ClientMessageHandler OnClientMessage;

        public delegate void ClientDisconnectedHandler(SocketServer server);
        public delegate void ClientMessageHandler(byte[] message);

        private readonly NamedPipeServerStream _server;

        public SocketServer()
        {
            _server = new NamedPipeServerStream("ChromOverwatch", 
                PipeDirection.InOut, 10, 
                PipeTransmissionMode.Message, PipeOptions.Asynchronous);
        }

        public void Connect()
        {
            _server.BeginWaitForConnection(NewConnection, _server);
        }

        public void Dispose()
        {
            if (_server.IsConnected)
            {
                _server.Disconnect();
                _server.Close();
            }
            _server.Dispose();
        }

        private void BeginRead(Message message)
        {
            _server.BeginRead(message.Buffer, 0, Message.BufferSize, ReadCallback, message);
        }

        private void NewConnection(IAsyncResult ar)
        {
            using (var conn = (NamedPipeServerStream)ar.AsyncState)
            {
                try
                {
                    conn.EndWaitForConnection(ar);
                }
                catch (Exception)
                {
                    OnDisconnected();                    
                }

                BeginRead(new Message());
            }
        }

        private void ReadCallback(IAsyncResult ar)
        {
            var readBytes = _server.EndRead(ar);
            if (readBytes > 0)
            {
                var message = (Message)ar.AsyncState;
                OnClientMessage?.Invoke(message.Buffer);
            }

            OnDisconnected();
        }

        private void OnDisconnected()
        {
            OnClientDisconnected?.Invoke(this);
        }
    }

    class Message
    {
        public const int BufferSize = 4 * 1024; //4KB

        public readonly byte[] Buffer;

        public Message()
        {
            Buffer = new byte[BufferSize];
        }
    }
}
