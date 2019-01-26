using Terminal.Gui;

namespace StandaloneExample.Screens {
    class BalanceView {
	public static Window generateWindow(Window baseWindow)
	{
	    Window balanceView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Balance");
	    balanceView.Add(
		    new TextField(14, 2, 40, "Welcome to BalanceView")
	    );
	    return balanceView;
	}
    }

}
