/* author: Sutinder S. Saini */
using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;
using NStack;

namespace eva
{

    class View 
    {
        public bool logEvents = false;
        private EvaFile evaFile;
        public NStack.ustring[] textStream;

        private TextView textInputField;
        /* 
         * helper method to set background and foreground colors within the application
         * driver itself
         */
        public void ApplyDriverColor(Color foreground, Color background)
        {
            Colors.Base.Normal = Application.Driver.MakeAttribute(foreground, background);
        }

        /*
         * 
         * Initialize the top menu bar
         * 
         */
        public void InitializeWindow()
        {
            // create top level window
            var top = Application.Top;


            #region MenuBar
            //Initialize upper Menu bar
            var topMenuBar = new MenuBar(new MenuBarItem[] {
                new MenuBarItem("File", new MenuItem[]
                {
                    new MenuItem("Save - ", "Save a document.", ()=>{
                        if(logEvents) {
                            Console.WriteLine("`Save` called");
                        }

                        top.Running = false;
                        Application.Shutdown();

                        //
                        // Save our file
                        //
                        EvaFile.SaveFile(textInputField.Text.ToString());

                        // exit safely
                        System.Environment.Exit(1);
                    }),

                    new MenuItem("Quit - ", "Exit eva Text Editor.", ()=>{

                        if(logEvents) {
                            Console.WriteLine("Stopping eva...");
                        }

                        // Destroy top-level window
                        top.Running = false;
                    }),

                }),
            });
            top.Add(topMenuBar);
            top.ColorScheme = Colors.Error;
            #endregion MenuBar

            /* draw text window underneath menubar */
            top.Add(InitializeTextWindow());

            Application.Run();
        }

        /**
         * 
         * Render the actual text window (boredered)
         *
         */
        public Window InitializeTextWindow()
        {
            var textWindow = new Window();

            textInputField = new TextView()
            {
                /* fill the entire console */
                Height = Dim.Fill(),
                Width = Dim.Fill(),
            };

            ApplyDriverColor(Color.Black, Color.White);//set everything other than the top bar to black n white
            textWindow.Add(textInputField);

            return textWindow;
            
        }

        public Window InitializeStatusBar()
        {
            var statusBar = new Window();
            var __statusBar = new StatusBar
            {
                ColorScheme = Colors.Dialog,
            };


            statusBar.Add(__statusBar);

            return statusBar;
        }

    }
}