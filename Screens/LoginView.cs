using Terminal.Gui;
using StandaloneExample.Screens;

namespace StandaloneExample.Screens {
    public class LoginView {


	public static Window generateWindow(Window baseWindow)
	{
	    Window loginView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Login");
	    var login = new Label("Wallet Name: ") { X = 3, Y = 6 };
	    var password = new Label("Wallet Password: ") {
		X = Pos.Left(login),
		Y = Pos.Bottom(login) + 1
	    };
	    var loginText = new TextField("") {
		X = Pos.Right(password),
		Y = Pos.Top(login),
		Width = 40
	    };
	    var passText = new TextField("") {
		Secret = true,
		X = Pos.Left(loginText),
		Y = Pos.Top(password),
		Width = Dim.Width(loginText)
	    };

	    var loginButton = new Button("Login") {
	    	X = 3,
	    	Y = 19,
	    	IsDefault = true,
	    	Clicked = () => {
			var subView = baseWindow.Subviews[0];
			subView.RemoveAll();

			var costView = DashboardView.generateWindow(baseWindow);
			baseWindow.Add(costView);
			costView.FocusFirst();
			costView.LayoutSubviews();
	    	}

	    };


	    loginView.Add(
		    new TextField(14, 2, 40, "Welcome to login view"),
	    		login,
			loginText,
			password,
			passText,
	    	loginButton
	    );
	    return loginView;
	}
    }
}
