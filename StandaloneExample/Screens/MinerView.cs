using Terminal.Gui;

namespace StandaloneExample.Screens {
    class MinerView {
	public static Window generateWindow(Window baseWindow)
	{
	    Window minerView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Miner");
	    minerView.Add(
		    new TextField(14, 2, 40, "Welcome to Miner View")
	    );
	    return minerView;
	}
    }

}
