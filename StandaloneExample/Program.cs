using Terminal.Gui;
using System;
using Mono.Terminal;

class Demo {
	class Box10x : View {
		public Box10x (int x, int y) : base (new Rect (x, y, 10, 10))
		{
		}
	}

	static void ShowEntries (View container)
	{
		var scrollView = new ScrollView (new Rect (50, 10, 20, 8)) {
			ContentSize = new Size (100, 100),
			ContentOffset = new Point (-1, -1)
		};

		// scrollView.Add (new Box10x (0, 0));

		// var progress = new ProgressBar (new Rect (68, 1, 10, 1));
		// bool timer (MainLoop caller)
		// {
		// 	progress.Pulse ();
		// 	return true;
		// }

		// Application.MainLoop.AddTimeout (TimeSpan.FromMilliseconds (300), timer);

		// A little convoluted, this is because I am using this to test the
		// layout based on referencing elements of another view:

		var login = new Label ("Login: ") { X = 3, Y = 6 };
		var password = new Label ("Password: ") {
			X = Pos.Left (login),
			Y = Pos.Bottom (login) + 1
		};
		var loginText = new TextField ("") {
			X = Pos.Right (password),
			Y = Pos.Top (login),
			Width = 40
		};

		var passText = new TextField ("") {
			Secret = true,
			X = Pos.Left (loginText),
			Y = Pos.Top (password),
			Width = Dim.Width (loginText)
		};

		// Add some content
		container.Add (
			login,
			loginText,
			password,
			passText,
			new FrameView (new Rect (3, 10, 25, 6), "Options"){
				new CheckBox (1, 0, "Remember me"),
			},
			scrollView,
			new Button ("Ok") { X = 3, Y = 19 },
			new Button ("Cancel") { X = 10, Y = 19 }
		);

	}

	static bool Quit ()
	{
		var n = MessageBox.Query (50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
		return n == 0;
	}


	public static Label ml;
	static void Main ()
	{
		Application.Init ();

		var top = Application.Top;
		var tframe = top.Frame;

		var win = new Window ("KRATE"){
			X = 0,
			Y = 1,
			Width = Dim.Fill (),
			Height = Dim.Fill () - 1
		};
		var menu = new MenuBar (new MenuBarItem [] {
			new MenuBarItem ("File", new MenuItem [] {
				new MenuItem ("Quit", "", () => { if (Quit ()) top.Running = false; })
			}),
			new MenuBarItem ("View", new MenuItem [] {
				new MenuItem ("Mining", "", null),
				new MenuItem ("Storage", "", null),
				new MenuItem ("Balance", "", null),
				new MenuItem ("Cost", "", null)
			})
		});

		ShowEntries (win);

		top.Add (win, menu);
		top.Add (menu);
		Application.Run ();
	}
}
