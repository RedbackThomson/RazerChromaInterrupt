using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaUI.Sockets;

namespace ChromaUI
{
    class OverwatchWatcher
    {
        private readonly MainForm _form;
        private readonly MessageHandler _handler;
        private SocketServer _activeServer;

        public OverwatchWatcher()
        {
            _form = new MainForm();

            _handler = new MessageHandler();
            _handler.OnKeyboardColorUpdate += _form.UpdateKeyboardColors;
            _handler.OnChampionUpdate += _form.UpdateCurrentChampion;
        }

        public void Start()
        {
            InitializeServer();
            Application.Run(_form);
        }

        private void InitializeServer()
        {
            _activeServer = new SocketServer();
            _activeServer.OnClientMessage += _handler.HandleMessage;
            _activeServer.OnClientDisconnected += CreateNewServer;
            _activeServer.Connect();
        }

        private void CreateNewServer(SocketServer server)
        {
            _activeServer?.Dispose();
            InitializeServer();
        }
    }
}
