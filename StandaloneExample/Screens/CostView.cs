using Terminal.Gui;
using StandaloneExample.RestClient;

namespace StandaloneExample.Screens {
    class CostView {
	public static Window generateWindow(Window baseWindow)
	{
	    Window costView = new Window(
        new Rect(
              0,
              0,
              baseWindow.Frame.Width - 2,
              baseWindow.Frame.Height - 2
        ),
        "Cost");
	    string result = Utility.Get("http://localhost:37220/api/AddressBook");
	    costView.Add(
		    new TextField(14, 2, 40, result)
	    );
	    return costView;
	}
    }
}
