using System;
using Terminal.Gui;
using NStack;
namespace eva
{
    class Eva
    {
        static void Main(string[] args)
        {


            Application.Init();
            View v = new View();
            //v.logEvents = true;
            v.InitializeWindow();
            
        }
    }
}
