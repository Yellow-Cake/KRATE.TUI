using Terminal.Gui;
using StandaloneExample.RestClient;

namespace StandaloneExample.Screens {
    class SendView {
	public static Window generateWindow(Window baseWindow)
	{
	    Window sendKrate = new Window(
        	new Rect(
              		0,
              		0,
              		baseWindow.Frame.Width - 2,
              		baseWindow.Frame.Height - 2
        	),
        	"Send");
	    string result = Utility.Get("http://localhost:37220/api/AddressBook");
	    sendKrate.Add(
		    new TextField(14, 2, 40, result)
	    );
	    return sendKrate;
	}
    }
}
