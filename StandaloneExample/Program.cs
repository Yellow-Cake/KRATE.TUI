using Terminal.Gui;
using System;
using Mono.Terminal;

class Demo {

	static void ShowEntries (View container)
	{
		var scrollView = new ScrollView (new Rect (50, 10, 20, 8)) {
			ContentSize = new Size (100, 100),
			ContentOffset = new Point (-1, -1)
		};

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
		Application.Init();
		var top = Application.Top;

		// Creates the top-level window to show
		var win = new Window(new Rect(0, 1, top.Frame.Width, top.Frame.Height - 1), "KRATE OFFICIAL");
		top.Add(win);

		Window LoginView = new Window(new Rect(0, 0, win.Frame.Width - 2, win.Frame.Height - 2), "Login");
		LoginView.Add(
			new TextField(14, 2, 40, "Welcome to LoginView")
		);

		Window BalanceView = new Window(new Rect(0, 0, win.Frame.Width - 2, win.Frame.Height - 2), "Balance");
		BalanceView.Add(
			new TextField(14, 2, 40, "Welcome to BalanceView")
		);

		Window StorageView = new Window(new Rect(0, 0, win.Frame.Width - 2, win.Frame.Height - 2), "Storage");
		StorageView.Add(
			new TextField(14, 2, 40, "Welcome to StorageView")
		);

		Window MinerView = new Window(new Rect(0, 0, win.Frame.Width - 2, win.Frame.Height - 2), "Miner");
		MinerView.Add(
			new TextField(14, 2, 40, "Welcome to MinerView")
		);

		Window CostView = new Window(new Rect(0, 0, win.Frame.Width - 2, win.Frame.Height - 2), "Cost");
		CostView.Add(
			new TextField(14, 2, 40, "Welcome to CostView")
		);


		var menu = new MenuBar(new MenuBarItem[] {
			new MenuBarItem ("_File", new MenuItem [] {
				new MenuItem ("_Quit", "", () => { top.Running = false; }),
			}),
			new MenuBarItem("Views", new MenuItem [] {
				new MenuItem ("Balance", "", () => {
						var subView = win.Subviews[0];
						subView.RemoveAll();

						win.Add(BalanceView);
						BalanceView.FocusFirst();
						BalanceView.LayoutSubviews();

				}),
				new MenuItem ("Storage", "", () => {
						var subView = win.Subviews[0];
						subView.RemoveAll();

						win.Add(StorageView);
						StorageView.FocusFirst();
						StorageView.LayoutSubviews();

				}),
				new MenuItem ("Miner", "", () => {
						var subView = win.Subviews[0];
						subView.RemoveAll();

						win.Add(MinerView);
						MinerView.FocusFirst();
						MinerView.LayoutSubviews();

				}),
				new MenuItem ("Cost", "", () => {
						var subView = win.Subviews[0];
						subView.RemoveAll();

						win.Add(CostView);
						CostView.FocusFirst();
						CostView.LayoutSubviews();

				})
			})
		});

		top.Add(menu);
		win.Add(LoginView);

		Application.Run();
	}
}
