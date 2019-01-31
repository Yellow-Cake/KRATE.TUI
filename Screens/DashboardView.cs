using System;
using Terminal.Gui;
using KrateTUI.RestClient;
using Newtonsoft.Json.Linq;

namespace KrateTUI.Screens {

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

      var transactionsRecord = (JArray)Utility.Get("http://localhost:37220/api/Wallet/spendable-transactions?WalletName=string4&AccountName=account%200")["transactions"];
      var numTransactions = transactionsRecord.Count;
	    for(int i  = 0; i < numTransactions; i+= 2) {

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

        if(numTransactions < 1) {
                var noTransactions = new TextView(new Rect(1, 2, 60, 1))
                {
                    Text = "YOU DO NOT HAVE ANY TRANSACTIONS",
                    ReadOnly = true
                };
                transWindow.Add(noTransactions);
            }

            var seeAllTransactions = new Button("See All Transactions") {
		X = 0,
		Y = 7,
        Clicked = () => {
            var subView = baseWindow.Subviews[0];
            subView.RemoveAll();

            var tView = TransactionsView.generateWindow(baseWindow);
            baseWindow.Add(tView);
            tView.FocusFirst();
            tView.LayoutSubviews();
        }
            };

            var sendKrates = new Button("Send Krates")
            {
                X = 25,
                Y = 7,
                Clicked = () =>
                {
                    var subView = baseWindow.Subviews[0];
                    subView.RemoveAll();

                    var costView = SendView.generateWindow(baseWindow);
                    baseWindow.Add(costView);
                    costView.FocusFirst();
                    costView.LayoutSubviews();
                }
            };

	    transWindow.Add(seeAllTransactions,sendKrates);

	    return transWindow;
	}


	public static Window generateWalletWindow() {
	    Window walletView = new Window(new Rect(0, 0, 65, 7), "Wallet");

	    var labelBalance = new TextView(new Rect(1, 0, 29, 1)) {
    	    Text = "Confirmed",
    		  ReadOnly = true
	    };
      var record = Utility.Get("http://localhost:37220/api/Wallet/balance?WalletName=string4");

      var confirmedBalance = record["balances"][0]["amountConfirmed"].ToString();
      var cBalance = new TextView(new Rect(1, 1, 29, 1)) {
        Text = confirmedBalance + " KRATES",
		      ReadOnly = true
	    };


	    var uLabelBalance = new TextView(new Rect(30, 0, 30, 1)) {
      		Text = "Unconfirmed",
      		ReadOnly = true
	    };

        var unconfirmedBalance = record["balances"][0]["amountUnconfirmed"].ToString();
	    var uBalance = new TextView(new Rect(30, 1, 30, 1)) {
      		Text = unconfirmedBalance + " KRATES",
      		ReadOnly = true
	    };


	    walletView.Add(
	    	labelBalance,
		cBalance,

		uLabelBalance,
		uBalance);

	    return walletView;
	}
    }
}
