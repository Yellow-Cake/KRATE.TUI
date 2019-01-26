using Terminal.Gui;

namespace StandaloneExample.Screens {
    public class LoginView {

	public static Window generateWindow(Window baseWindow)
	{
	    Window loginView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Login");
	    loginView.Add(
		    new TextField(14, 2, 40, "Welcome to login view")
	    );
	    return loginView;
	}
    }
}
