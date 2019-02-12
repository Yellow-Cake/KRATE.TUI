    using System;
    using Terminal.Gui;
    using KrateTUI.RestClient;
    namespace KrateTUI.Screens
    {
    class RecieveView
        {
            Window recieveKrateWindow = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Recieve Krates");

            var recieveFromLabel = new Label("Recieve From: ") { X = 1, Y = 1 };

            var LabelLabel = new Label("Label: ")
            {
                X = Pos.Left(recieveFromLabel),
                Y = Pos.Bottom(recieveFromLabel) + 1
            };

            var AmountLabel = new Label("Amount to Recieve: ")
            {
                X = Pos.Left(LabelLabel),
                Y = Pos.Bottom(LabelLabel) + 1
            };

            var recieveFromText = new TextField("")
            {
                X = Pos.Right(LabelLabel),
                Y = Pos.Top(recieveFromLabel),
                Width = 40
            };

            var LabelText = new TextField("")
            {
                X = Pos.Left(recieveFromText),
                Y = Pos.Top(LabelLabel),
                Width = Dim.Width(payToText)
            };

            var AmountText = new TextField("")
            {
                X = Pos.Left(LabelText),
                Y = Pos.Top(AmountLabel),
                Width = Dim.Width(LabelText)
            };

            var recieveKratesButton = new Button("Recieve")
            {
                X = Pos.Left(AmountText),
                Y = 10,
                IsDefault = true,
                Clicked = () =>
                {
                    var resp = Utility.Post("URL");
                }
            };

            var clearButton = new Button("Clear")
            {
                X = Pos.Right(recieveKratesButton) + 15,
                Y = 10,
                IsDefault = true,
                Clicked = () => {
                    var subView = baseWindow.Subviews[0];
                    subView.RemoveAll();

                    var recieveView = RecieveView.generateWindow(baseWindow);
                    baseWindow.Add(recieveView);
                    recieveView.FocusFirst();
                    recieveView.LayoutSubviews();
                }
            };

            recieveKrateWindow.Add(
            recieveFromLabel,
            LabelLabel, 
            AmountLabel, 
            recieveFromText, 
            LabelText, 
            AmountText, 
            recieveKratesButton, 
            clearButton

            );

                return recieveKrateWindow;

    }
    }
