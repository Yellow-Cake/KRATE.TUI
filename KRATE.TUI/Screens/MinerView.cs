using Terminal.Gui;
using KrateTUI.RestClient;

namespace KrateTUI.Screens {
    class MinerView {
    	public static Window generateWindow(Window baseWindow)
    	{
    	    Window minerView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Miner View");


            var record = Utility.Get("http://localhost:37220/api/Wallet/balance?WalletName=string4");
            var confirmedBalance = record["balances"][0]["amountConfirmed"].ToString();

            Window walletWindow = new Window(new Rect(0,2,26,5), "Wallet");
            var minerBalance = new TextView(new Rect(1, 1, 21, 1))
            {
                Text = confirmedBalance + " KRATES",
                ReadOnly = true
            };
            walletWindow.Add(minerBalance);

            Window networkWindow = new Window(new Rect(0, 8, 26, 5), "Network Status");
            var status = new TextView(new Rect(1, 1, 21, 1))
            {
                Text = "STATUS: OK",
                ReadOnly = true
            };
            networkWindow.Add(status);

            Window minerStatsWindow = new Window(new Rect(27, 2, 48, 10), "Miner Status");
            var krateCoin = new TextView(new Rect(1, 1, 21, 1))
            {
                Text = "Krate Coin",
                ReadOnly = true
            };
            var address = new TextView(new Rect(1, 2, 45, 1))
            {
                Text = "Address: 1F1VUjcVHuhwSG9prQ7RC6Bwk1BeMZRVwg",
                ReadOnly = true
            };
            var krateVersion = new TextView(new Rect(1, 3, 45, 1))
            {
                Text = "Krate Version: v1.0.1",
                ReadOnly = true
            };
            var hashRate = new TextView(new Rect(1, 4, 45, 1))
            {
                Text = "Hash rate: 555.6/K",
                ReadOnly = true
            };
            var difficulty = new TextView(new Rect(1, 5, 45, 1))
            {
                Text = "Difficulty: Expert",
                ReadOnly = true
            };
            var percentMined = new TextView(new Rect(1, 6, 45, 1))
            {
                Text = "Percent Mined: 43%",
                ReadOnly = true
            };
            var blocksMined = new TextView(new Rect(1, 7, 45, 1))
            {
                Text = "Blocks Mined: 43",
                ReadOnly = true
            };
            minerStatsWindow.Add(krateCoin,address,krateVersion, hashRate, difficulty, percentMined,blocksMined);


            minerView.Add(walletWindow,networkWindow, minerStatsWindow);
            return minerView;
    	}
    }

}
