using System;

namespace JGEmulator
{
    public class UIMessage
    {
        public string Message { get; set; }
        public UIMessageType UIMessageType { get; set; }
        public string Source { get; set; }

        public UIMessage(UIMessageType uiMessageType, string message, string source)
        {
            Message = message;
            UIMessageType = uiMessageType;
            Source = source;
        }
    }
}


