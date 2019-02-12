        using System;
        using KrateTUI.RestClient;

        namespace KrateTUI.Screens
        {
            public class InfoView
            {
                public InfoView()
                {
                public static Window generateWindow( Window baseWindow)
                    {
                        Window InfoView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Information View");

                        var InfoWindow = generateInfoWindow(baseWindow);
                        var GeneralWindow = generateGeneralWindow(baseWindow);
                        var NetworkWindow = generateNetworkWindow(baseWindow);
                        var BlockChainWindow = generateBlockchainWindow(baseWindow);
                        var MemoryPoolWindow = generateMemoryPoolWindow(baseWindow);
                        var OptionWindow = generateOptionsWindow(baseWindow);

                        InfoView.Add(
                           InfoWindow,
                           GeneralWindow,
                           NetworkWindow,
                           BlockChainWindow,
                           MemoryPoolWindow,
                           OptionsWindow

                        );

                        return InfoView;
                    }

                    public static Window generateInfoWindow(Window baseWindow)
                    {

                        Window transactionWindow = new Window(new Rect(0, 0, 70, 14), "Information Overview");

                        var GeneralList = new ListView(new Rect(0, 1, 60, 10), new string[] {
                        "Client Version",
                        "User Agent",
                        "Datadir",
                        "Last Used"


                    });
                        var NetworkList = new ListView(new Rect(0, 1, 30, 10), new String[] {
                            "Name",
                            "Number of Connections"
                        });

                var BlockchainList = new ListView(new Rect(0, 1, 20, 10), new String[] { 
                    "Current number of Blocks",
                    "Last Block Time",
                    "Block Difficulty"       
            });

            transactionWindow.Add(GeneralList, NetworkList, BlockchainList);              
            return transactionWindow;

                    public static Window generateInfoWindow(Window baseWindow)
                    {
                        Window optionsWindow = new Window(new Rect(0, 14, 70, 3), "Options");

                        var option1 = new Button("Console")
                        {
                            X = 0,
                            Y = 0
                        };

                        var option2 = new Button("Network Traffic")
                        {
                            X = 0,
                            Y = 2
                        };

                        var option3 = new Button("Peers")
                        {
                            X = 0,
                            Y = 4
                        };

                        optionsWindow.Add(option1, option2, option3);

                        return optionsWindow;
                    }

                
            }
            }
        }
