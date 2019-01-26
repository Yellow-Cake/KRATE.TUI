using Terminal.Gui;

namespace StandaloneExample.Screens {
    class CostView {
	public static Window generateWindow(Window baseWindow)
	{
	    Window costView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Balance");
	    costView.Add(
		    new TextField(14, 2, 40, "Welcome to Cost View")
	    );
	    return costView;
	}
    }
}
