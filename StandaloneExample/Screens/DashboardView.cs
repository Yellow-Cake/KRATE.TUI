using System;
using Terminal.Gui;

namespace StandaloneExample.Screens {

    public class DashboardView {
	public static Window generateWindow(Window baseWindow)
	{
	    Window dashboardView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Dashboard");

	    var wallet = generateWalletWindow();
	    var transactions = generateTransactionsWindow(baseWindow);

	    dashboardView.Add(
		wallet,
		transactions
	    );
	    return dashboardView;
	}

	public static Window generateTransactionsWindow(Window baseWindow) {
	    Window transWindow = new Window(new Rect(0, 7, 65, 10), "Recent Transactions");


	    for(int i  = 0; i < 4; i+= 2) {

		var transactionAmount = new TextView(new Rect(1, i == 0 ? i : i+1, 40, 1)) {
		    Text = "-5.0000 KRATE(S)",
		    ReadOnly = true
		};

		transWindow.Add(transactionAmount);

		var transactionRecipient = new TextView(new Rect(1, i == 0 ? (i+1) : i+1+1, 40, 1)) {
		    Text = "To: c652076704f4c1d4ea6dd75adac850ff",
		    ReadOnly = true
		};

		transWindow.Add(transactionRecipient);

		var transactionDateTime = new Label(new Rect(20, i == 0 ? i : i + 1, 20, 1), "01.20.2019 17:01") {
		    TextAlignment = TextAlignment.Right
		};

		transWindow.Add(transactionDateTime);

	    }

	    var seeAllTransactions = new Button("See All Transactions") {
		X = 0,
		Y = 7
	    };

	    var sendKrates = new Button("Send Krates") {
		X = 25,
		Y = 7,
		Clicked = () => {
		    var subView = baseWindow.Subviews[0];
		    subView.RemoveAll();

		    var costView = SendView.generateWindow(baseWindow);
		    baseWindow.Add(costView);
		    costView.FocusFirst();
		    costView.LayoutSubviews();
		}
	    };

	    var recieveKrates = new Button("Recieve Krates") {
		X = 40,
		Y = 7,
	    };

	    transWindow.Add(seeAllTransactions,sendKrates,recieveKrates);

	    return transWindow;
	}


	public static Window generateWalletWindow() {
	    Window walletView = new Window(new Rect(0, 0, 65, 7), "Wallet");

	    var labelBalance = new TextView(new Rect(1, 0, 29, 1)) {
		Text = "Balance",
		ReadOnly = true
	    };
	    var cBalance = new TextView(new Rect(1, 1, 29, 1)) {
		Text = "863.05307190 KRATES",
		ReadOnly = true
	    };

	    var cConversionBalance = new TextView(new Rect(1, 2, 29, 1)) {			
		Text = "0.25028539 BTC ($885.51)",
		ReadOnly = true
	    };

	    var uLabelBalance = new TextView(new Rect(30, 0, 30, 1)) {
		Text = "Unconfirmed",
		ReadOnly = true
	    };
	    var uBalance = new TextView(new Rect(30, 1, 30, 1)) {
		Text = "863.05307190 KRATES",
		ReadOnly = true
	    };

	    var uConversionBalance = new TextView(new Rect(30, 2, 30, 1)) {
		Text = "0.2502853988551)",
	
		CanFocus = false,
		ReadOnly = true
	    };

	    walletView.Add(
	    	labelBalance,
		cBalance,
		cConversionBalance,

		uLabelBalance,
		uBalance,
		uConversionBalance);

	    return walletView;
	}
    }
}
