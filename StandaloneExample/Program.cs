using Terminal.Gui;
using System;
using Mono.Terminal;
using System.Net;
using System.IO;

// Variable format was something like application.xxx.yyy
// must be HTTP Rest API. Need to build into levelDB as Alpha Version. JSON?

class KrateApplication {

	Window mainWindow;
	MenuBar navigationMenu;

	KrateApplication(){
		Application.Init();
		this.mainWindow = generateMainWindow(Application.Top);
		this.navigationMenu = new MenuBar(new MenuBarItem[] {
					new MenuBarItem ("_File", new MenuItem [] {
						new MenuItem ("_Quit", "", () => { Application.Top.Running = false; }),
					}),
					new MenuBarItem("Views", new MenuItem [] {
						new MenuItem ("Balance", "", () => {
								var subView = this.mainWindow.Subviews[0];
								subView.RemoveAll();

								var balanceView = BalanceView.generateWindow(this.mainWindow);
								this.mainWindow.Add(balanceView);
								balanceView.FocusFirst();
								balanceView.LayoutSubviews();

						}),
						new MenuItem ("Storage", "", () => {
								var subView = this.mainWindow.Subviews[0];
								subView.RemoveAll();

								var storageView = StorageView.generateWindow(this.mainWindow);
								this.mainWindow.Add(storageView);
								storageView.FocusFirst();
								storageView.LayoutSubviews();

						}),
						new MenuItem ("Miner", "", () => {
								var subView = this.mainWindow.Subviews[0];
								subView.RemoveAll();

								var minerView = MinerView.generateWindow(this.mainWindow);
								this.mainWindow.Add(minerView);
								minerView.FocusFirst();
								minerView.LayoutSubviews();

						}),
						new MenuItem ("Cost", "", () => {
								var subView = this.mainWindow.Subviews[0];
								subView.RemoveAll();

								var costView = CostView.generateWindow(this.mainWindow);
								this.mainWindow.Add(costView);
								costView.FocusFirst();
								costView.LayoutSubviews();

						})
					})
			});
	}



	static bool shouldQuit(){
		var n = MessageBox.Query(50,7, "Quit Demo", "Are you sure you want to quit the demo?", "Yes", "No");
		return n == 0;
	}

	static Window generateMainWindow(Terminal.Gui.Toplevel applicationTop){
		return new Window(new Rect(0,1, applicationTop.Frame.Width, applicationTop.Frame.Height -1), "KRATE OFFICIAL");
	}

	static void Main(){
		KrateApplication TUI = new KrateApplication();
		Application.Top.Add(TUI.mainWindow);
		Application.Top.Add(TUI.navigationMenu);

		TUI.mainWindow.Add(LoginView.generateWindow(TUI.mainWindow));

		Application.Run();

	}
}

class LoginView {
	public static Window generateWindow(Window baseWindow){
		Window loginView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Login");
		loginView.Add(
			new TextField(14,2,40, "Welcome to login view")
		);
		return loginView;
	}
}

class BalanceView {
	public static Window generateWindow(Window baseWindow){
		Window balanceView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Balance");
		balanceView.Add(
			new TextField(14, 2, 40, "Welcome to BalanceView")
		);
		return balanceView;
	}
}

class StorageView {
	public static Window generateWindow(Window baseWindow){
		Window storageView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Storage");
		storageView.Add(
			new TextField(14, 2, 40, "Welcome to StorageView")
		);
		return storageView;
	}
}

class MinerView {
	public static Window generateWindow(Window baseWindow){
		Window minerView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Miner");
		minerView.Add(
			new TextField(14, 2, 40, "Welcome to Miner View")
		);
		return minerView;
	}
}

class CostView {
	public static Window generateWindow(Window baseWindow){
		Window costView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Balance");
		costView.Add(
			new TextField(14, 2, 40, "Welcome to Cost View")
		);
		return costView;
	}
}
