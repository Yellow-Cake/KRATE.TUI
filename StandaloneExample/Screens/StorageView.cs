using Terminal.Gui;

namespace StandaloneExample.Screens {
    class StorageView {
	public static Window generateWindow(Window baseWindow)
	{
	    Window storageView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Storage");
	    storageView.Add(
		    new TextField(14, 2, 40, "Welcome to StorageView")
	    );
	    return storageView;
	}
    }

}
