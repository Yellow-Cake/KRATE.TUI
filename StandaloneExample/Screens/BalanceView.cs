using Terminal.Gui;

namespace StandaloneExample.Screens {
    class BalanceView {
    	public static Window generateWindow(Window baseWindow)
	{
	    Window balanceView = new Window(
		    new Rect(
		    0,
			0,
			baseWindow.Frame.Width - 2,
		    height: baseWindow.Frame.Height - 2
	    ),
		"Balance") {
		new TextField(14, 2, 40, "Welcome to BalanceView")
	    };
	    foreach (var item in balanceView) {
	    }
	    return balanceView;
    	}
    }

}
