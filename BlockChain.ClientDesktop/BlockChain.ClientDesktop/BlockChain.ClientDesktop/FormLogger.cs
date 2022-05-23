using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BlockChain.Core;

namespace BlockChain.ClientDesktop
{
    public class FormLogger : IClientLogger
    {
        private readonly TextBox _textBox;
        private readonly Queue<string> _queueMessage;

        public int LineCount { get; set; } = 5;

        public FormLogger(TextBox textBox)
        {
            _textBox = textBox;
            _queueMessage = new Queue<string>();
        }

        public void LogDebug(string message)
        {
            var messageFormatted = GetMessageFormatted("Dedug", message);
            ShowMessage(messageFormatted);
        }

        public void LogError(string message)
        {
            var messageFormatted = GetMessageFormatted("Error", message);
            ShowMessage(messageFormatted);
        }

        public void LogError(string message, Exception ex)
        {
            var messageFormatted = GetMessageFormatted("Error", message);
            ShowMessage($"{messageFormatted} {ex.Message}");
        }

        private void ShowMessage(string message)
        {
            if (LineCount <= 0)
                return;

            _queueMessage.Enqueue(message);
            while(_queueMessage.Count>LineCount)
            {
                _queueMessage.Dequeue();
            }


            if (_textBox.InvokeRequired)
            {
                Action writer =  () => {
                    _queueMessage.Reverse().ToArray();
                };
                
                _textBox.Invoke(writer);
            }
            else
                _textBox.Lines = _queueMessage.Reverse().ToArray();


        }   

        private string GetMessageFormatted(string type, string message)
        {
            return $"[{type}:{DateTime.Now.ToString("HH.mm.ss")}] {message}";
        }

    }
}
