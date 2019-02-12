using Terminal.Gui;
using KrateTUI.RestClient;

namespace KrateTUI.Screens {
    class SendView {
    	public static Window generateWindow(Window baseWindow)
    	{
            Window sendKrateWindow = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Send Krates");

            var payToLabel = new Label("Pay to: ") { X = 1, Y = 1 };
            var LabelLabel = new Label("Label: ")
            {
                X = Pos.Left(payToLabel),
                Y = Pos.Bottom(payToLabel) + 1
            };
            var AmountLabel = new Label("Amount: ")
            {
                X = Pos.Left(LabelLabel),
                Y = Pos.Bottom(LabelLabel) + 1
            };
            var payToText = new TextField("")
            {
                X = Pos.Right(LabelLabel),
                Y = Pos.Top(payLabel),
                Width = 40
            };
            var LabelText = new TextField("")
            {
                X = Pos.Left(payToText),
                Y = Pos.Top(LabelLabel),
                Width = Dim.Width(payToText)
            };
            var AmountText = new TextField("")
            {
                X = Pos.Left(LabelText),
                Y = Pos.Top(AmountLabel),
                Width = Dim.Width(LabelText)    
            };

            var subtractFreeCheckbox = new CheckBox("Subtract fee from account?", true)
            {
                X = Pos.Left(AmountLabel),
                Y = Pos.Bottom(AmountLabel) + 1
            };

            var sendKratesButton = new Button("Send")
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
                X = Pos.Right(sendKratesButton) + 15,
                Y = 10,
                IsDefault = true,
                Clicked = () => {
                    var subView = baseWindow.Subviews[0];
                    subView.RemoveAll();

                    var sendView = SendView.generateWindow(baseWindow);
                    baseWindow.Add(sendView);
                    sendView.FocusFirst();
                    sendView.LayoutSubviews();
                }
            };


            sendKrateWindow.Add(payToLabel, LabelLabel, AmountLabel, payToText, LabelText, AmountText, subtractFreeCheckbox, sendKratesButton, clearButton);

            return sendKrateWindow;
    	}
    }
}
