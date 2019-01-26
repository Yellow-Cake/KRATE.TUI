using Terminal.Gui;
using StandaloneExample.Screens;

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
