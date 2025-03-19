using System.Net.Security;

namespace WebAssemblyDemo.Client
{
    public class ContainerStorage
    {
        private string _message = string.Empty;

        public string GetMesssage() { return _message; }   

        public void SetMessage(string message) { _message = message; }
    }
}
