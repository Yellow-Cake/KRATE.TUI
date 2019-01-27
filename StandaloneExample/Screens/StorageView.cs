using Terminal.Gui;

namespace StandaloneExample.Screens {
    class StorageView {
		public static Window generateWindow(Window baseWindow)
		{
			Window storageView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Storage");
			
			var currenFilesWindow = generateCurrentFilesWindow(baseWindow);
   			var optionsWindow = generateOptionsMenuWindow(baseWindow);
	    		var statisticsWindow = generateStatisticsWindow(baseWindow);

			storageView.Add(
				currenFilesWindow,
				optionsWindow,
				statisticsWindow
				
			);
			
			return storageView;
		}

		public static Window generateCurrentFilesWindow(Window baseWindow){
			Window fileStored = new Window(new Rect(0, 0, 70, 14), "Current Files");

			
	    	fileStored.Add(
				new TextField(0, 1, 20, "Homework.docx"),
				new TextField(0, 2, 20, "FamilyPhotos.png"),
				new TextField(0, 3, 20, "TakeOverTheWorld.pdf")

				);
			return fileStored;
		}


		public static Window generateOptionsMenuWindow(Window baseWindow) { 
			Window optionsWindow = new Window(new Rect(0, 14, 70, 3), "Options");
	    	
			var uploadButton = new Button("Upload"){
				X = 0,
				Y = 0
			};
			optionsWindow.Add(uploadButton);

	    	return optionsWindow;	
		}

		public static Window generateStatisticsWindow(Window baseWindow) { 
			Window statsWindow = new Window(new Rect(0, 17, 70, 3), "Statistics");
	    	
				var costPerDay = new TextView( new Rect(0,0,70,1)){
					Text = "0.12 K/day"
				};
				statsWindow.Add(costPerDay);		

	    		return statsWindow;	
		}
    }

}
