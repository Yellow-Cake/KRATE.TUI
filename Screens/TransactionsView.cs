using Terminal.Gui;

namespace KrateTUI.Screens {
    class TransactionsView {
		public static Window generateWindow(Window baseWindow)
		{
			Window transactionsView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Transactions View");
			
			var allTransactionsWindow = generateAllTransactionsWindow(baseWindow);
   			var optionsWindow = generateOptionsMenuWindow(baseWindow);

			transactionsView.Add(
                allTransactionsWindow,
				optionsWindow
				
			);
			
			return transactionsView;
		}

		public static Window generateAllTransactionsWindow(Window baseWindow){

			Window transactionWindow = new Window(new Rect(0, 0, 70, 14), "Transactions");

    	    var listTransactions = new ListView(new Rect(0, 1, 65, 10), new string[] {
        		"Tranaction 1",
                "Tranaction 2",
                "Tranaction 3",
                "Tranaction 4",
                "Tranaction 5",
                "Tranaction 6",
                "Tranaction 7",
            });



            transactionWindow.Add(listTransactions);
	    	return transactionWindow;
		
		}


		public static Window generateOptionsMenuWindow(Window baseWindow) { 
			Window optionsWindow = new Window(new Rect(0, 14, 70, 3), "Options");
	    	
			var option1 = new Button("Option 1"){
				X = 0,
				Y = 0
			};

            var option2 = new Button("Option 2")
            {
                X = 0,
                Y = 2
            };
            optionsWindow.Add(option1,option2);

	    	return optionsWindow;	
		}

    }

}
