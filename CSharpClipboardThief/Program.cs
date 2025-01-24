using System;
using System.Runtime.InteropServices;
using static System.Net.WebRequestMethods;


namespace CSharpClipboardThief
{
    internal class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport("user32.dll")]
        static extern IntPtr GetClipboardData(uint uFormat);
        [DllImport("kernel32.dll")]
        static extern IntPtr GlobalLock(IntPtr hMem);
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GlobalUnlock(IntPtr hMem);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool CloseClipboard();

        static void Main(string[] args)
        {
            bool openCliboard = OpenClipboard(IntPtr.Zero);
            IntPtr areaDeTransferencia = GetClipboardData(13);
            IntPtr alock = GlobalLock(areaDeTransferencia);
            string texto = Marshal.PtrToStringUni(alock);
            GlobalUnlock(alock);
            CloseClipboard();
            Console.WriteLine(texto);

        }
    }
}
