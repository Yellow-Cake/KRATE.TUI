using Terminal.Gui;
using KrateTUI.Screens;
using KrateTUI.Utilities;

class KrateApplication {


	Window mainWindow;
	MenuBar navigationMenu;

    KrateApplication() {
        Application.Init();
        this.mainWindow = generateMainWindow(Application.Top);
        this.navigationMenu = new MenuBar(new MenuBarItem[] {
            new MenuBarItem ("_File", new MenuItem [] {
                new MenuItem ("_Quit", "", () => { Application.Top.Running = false; }),
            }),
            new MenuBarItem("Views", new MenuItem [] {
                    new MenuItem ("Dashboard", "", () => {
                        var subView = this.mainWindow.Subviews[0];
                        subView.RemoveAll();

                        var dashboardView = DashboardView.generateWindow(this.mainWindow);
                        this.mainWindow.Add(dashboardView);
                        dashboardView.FocusFirst();
                        dashboardView.LayoutSubviews();
            }),
             new MenuItem ("Miner", "", () => {
                        var subView = this.mainWindow.Subviews[0];
                        subView.RemoveAll();

                        var minerView = MinerView.generateWindow(this.mainWindow);
                        this.mainWindow.Add(minerView);
                        minerView.FocusFirst();
                        minerView.LayoutSubviews();

                }),
                new MenuItem ("Recieve Krates", "", () => {
                        var subView = this.mainWindow.Subviews[0];
                        subView.RemoveAll();

                        var recieveView = RecieveView.generateWindow(this.mainWindow);
                        this.mainWindow.Add(recieveView);
                        recieveView.FocusFirst();
                        recieveView.Layou0tSubviews();

                }),
                new MenuItem ("Send Krates", "", () => {
                        var subView = this.mainWindow.Subviews[0];
                        subView.RemoveAll();

                        var costView = SendView.generateWindow(this.mainWindow);
                        this.mainWindow.Add(costView);
                        costView.FocusFirst();
                        costView.LayoutSubviews();

                }),
                new MenuItem ("All Transactions", "", () => {
                    var subView = this.mainWindow.Subviews[0];
                    subView.RemoveAll();

                    var transactionsView = TransactionsView.generateWindow(this.mainWindow);
                    this.mainWindow.Add(transactionsView);
                    transactionsView.FocusFirst();
                    transactionsView.LayoutSubviews();

                }),
                new MenuItem ("BalanceView", "", () => {
                    var subView = this.mainWindow.Subviews[0];
                    subView.RemoveAll();

                    var balanceView = BalanceView.generateWindow(this.mainWindow);
                    this.mainWindow.Add(balanceView);
                    balanceView.FocusFirst();
                    balanceView.LayoutSubviews();

                }),
                new MenuItem ("Information","", () => {
                    var subView = this.mainWindow.Subviews[0];
                    subView.RemoveAll();

                    var infoView = InfoView.generateInfoWindow(this.mainWindow);
                    this.mainWindow.Add(infoView);
                    infoView.FocusFirst();
                    infoView.LayoutSubviews();

    });
	}



	static bool shouldQuit(){
		var n = MessageBox.Query(50,7, "Quit Demo", "Are you sure you want to quit the demo?", "Yes", "No");
		return n == 0;
	}

	static Window generateMainWindow(Terminal.Gui.Toplevel applicationTop){
		return new Window(new Rect(0,1, Constants.WIDTH, Constants.HEIGHT), "KRATE OFFICIAL");
	}

	static void Main(){
		KrateApplication TUI = new KrateApplication();
		Application.Top.Add(TUI.mainWindow);
		Application.Top.Add(TUI.navigationMenu);

		TUI.mainWindow.Add(LoginView.generateWindow(TUI.mainWindow));

		Application.Run();

	}
}
